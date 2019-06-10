using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Procp_Form.CoreAbstraction;
using Procp_Form.Visuals;
using System.Timers;
using LiveCharts;
using LiveCharts.Wpf;
using Procp_Form.Airport;
using Brushes = System.Windows.Media.Brushes;
using Brush = System.Windows.Media.Brush;

namespace Procp_Form
{
    public partial class Baggager : Form
    {
        Grid thisGrid;

        bool buildModeActive;
        string buildModeType;
        bool deleteMode;
        bool isBuildingConveyor;
        bool isConnectingTiles;
        DropOff selectedDropOffForSettings;
        GridTile selectedTile;
        List<ConveyorTile> conveyorBuilding;
        Engine engine;
        int checkinCounter = 0;
        int dropOffCounter = 0;

        System.Timers.Timer aTimer;

        public Baggager()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            thisGrid = new Grid(animationBox.Width, animationBox.Height);
            engine = new Engine();
            chbDeleteMode.Visible = false;
            buildModeActive = false;
            deleteMode = false;
            isBuildingConveyor = false;
            isConnectingTiles = false;
            conveyorBuilding = new List<ConveyorTile>();
        }

        private void AnimationBox_Paint(object sender, PaintEventArgs e)
        {
            thisGrid.DrawGrid(e);
        }

        // entering and exiting build mode
        private void ChbBuildMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBuildMode.Checked)
            {
                buildModeActive = true;
                lblTest.Text = buildModeActive ? "[On]" : "[Off]";
                gbBuildType.Visible = true;
                chbDeleteMode.Visible = true;
                rbCheckIn.Checked = true;
                buildModeType = "CheckIn";

                thisGrid.HideAndUnhideArea(buildModeType);

            }
            else
            {
                buildModeActive = false;
                lblTest.Text = buildModeActive ? "[On]" : "[Off]";
                gbBuildType.Visible = false;
                chbDeleteMode.Checked = false;
                chbDeleteMode.Visible = false;
                buildModeType = null;
                thisGrid.HideAndUnhideArea(buildModeType);
            }
            animationBox.Invalidate();
        }

        //setting the type of tile with node that is going to be build
        private void BuildType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCheckIn.Checked)
            {
                buildModeType = "CheckIn";
            }
            else if (rbSecurity.Checked)
            {
                buildModeType = "Security Scanner";
            }
            else if (rbConveyor.Checked)
            {
                buildModeType = "Conveyor";
            }
            else if (rbDropOff.Checked)
            {
                buildModeType = "DropOff";
            }
            else if (rbMPA.Checked)
            {
                buildModeType = "MPA";
            }
            thisGrid.HideAndUnhideArea(buildModeType);
            animationBox.Invalidate();
        }

        //changing conveyor speed
        private void ConveyorSpeed_CheckedChanged(object sender, EventArgs e)
        {
            int speed = 0;

            if (rbConvSpeed1.Checked)
            {
                speed = 1;
            }
            else if (rbConvSpeed2.Checked)
            {
                speed = 2;
            }
            else if (rbConvSpeed3.Checked)
            {
                speed = 3;
            }
            else if (rbConvSpeed4.Checked)
            {
                speed = 4;
            }
            engine.ChangeConveyorSpeed(speed);
            thisGrid.HideAndUnhideArea(buildModeType);
            animationBox.Invalidate();
        }
        /**
        // I intended to comment these methods to explain them 
        // I also hoped I would be able to make the code better
        // I did not plan my time well
        // - Boris Georgiev
        **/
        private void AnimationBox_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);

            SelectTile(t);

            if (buildModeActive)
            {
                //here we build the different elements
                if (t is EmptyTile && t.Unselectable == false && deleteMode == false)
                {
                    //because a single conveyor can consist of many tiles, we do not add the nodes when we begin building it, unlike the other elements
                    if (buildModeType == "Conveyor")
                    {
                        SelectTile(thisGrid.AddConveyorLineAtCoordinates(t));
                        conveyorBuilding.Add((ConveyorTile)selectedTile);

                        isBuildingConveyor = true;
                    }
                    else if (buildModeType == "CheckIn")
                    {
                        CheckIn checkin = new CheckIn();
                        SelectTile(thisGrid.AddCheckInAtCoordinates(t, checkin));
                        engine.AddCheckIn(checkin);
                        RefreshCheckInCombobox();

                        GridTile temp = thisGrid.AutoConnectToNext(selectedTile, thisGrid.GetBottomNeighbour);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                        }
                    }
                    else if (buildModeType == "Security Scanner")
                    {
                        Security security = new Security();
                        SelectTile(thisGrid.AddSecurityAtCoordinates(t, security));
                        engine.AddSecurity(security);

                        GridTile temp = thisGrid.AutoConnectToPrev(selectedTile, thisGrid.GetNeighboursIn4Directions);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(temp.nodeInGrid, selectedTile.nodeInGrid);
                        }

                        temp = thisGrid.AutoConnectToNext(selectedTile, thisGrid.GetNeighboursIn4Directions);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                        }
                    }
                    else if (buildModeType == "DropOff")
                    {
                        DropOff dropoff = new DropOff();
                        SelectTile(thisGrid.AddDropOffAtCoordinates(t, dropoff));
                        engine.AddDropOff(dropoff);
                        RefreshDropOffCombobox();
                        if (btnAddFlight.Enabled != true)
                        {
                            btnAddFlight.Enabled = true;
                        }

                        GridTile temp = thisGrid.AutoConnectToPrev(selectedTile, thisGrid.GetTopNeighbour);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(temp.nodeInGrid, selectedTile.nodeInGrid);
                            //each conveyor can contain the destination gate of the drop off it is connected too
                            //here we assign the destination gate to the previous conveyor
                            if (temp is ConveyorTile)
                            {
                                Conveyor selectedConveyor = temp.nodeInGrid as Conveyor;
                                DropOff selectedDropOff = selectedTile.nodeInGrid as DropOff;
                                selectedConveyor.DestinationGate = selectedDropOff.DestinationGate;
                            }
                        }
                    }

                    else if (buildModeType == "MPA")
                    {
                        MPA mpa = new MPA();
                        // AddMPA() first checks if there is available space to build it from the selected starting point
                        if (thisGrid.AddMPA(t, mpa))
                        {
                            engine.AddMPA(mpa);

                            SelectTile(thisGrid.FindTileInRowColumnCoordinates(t.Column, t.Row));
                            List<GridTile> tempMPA = thisGrid.GetMPA(selectedTile);
                            foreach (GridTile m in tempMPA)
                            {
                                GridTile temp = thisGrid.AutoConnectToPrev(m, thisGrid.GetNeighboursIn4Directions);
                                if (temp != null)
                                {
                                    engine.LinkTwoNodes(temp.nodeInGrid, m.nodeInGrid);
                                }
                                temp = thisGrid.AutoConnectToNext(m, thisGrid.GetNeighboursIn4Directions);
                                if (temp != null && temp.nodeInGrid is Conveyor)
                                {
                                    mpa.AddNextNode(temp.nodeInGrid as Conveyor);
                                }
                            }
                            // we disable the ability to create another MPA
                            rbMPA.Visible = false;
                            rbCheckIn.Checked = true;
                        }
                    }
                }
                /**
                // isConnectingTiles is used in the MouseMove Event
                // since delete mode is enabled only if build mode is enabled, 
                // we must ensure delete mode is not enabled when attempting to connect elements
                **/
                else if (!(t is EmptyTile) && deleteMode == false)
                {
                    isConnectingTiles = true;
                }
                //here we delete tiles
                else if (!(t is EmptyTile) && deleteMode == true)
                {
                    if (t is ConveyorTile)
                    {
                        ConveyorTile first = thisGrid.RemoveConveyorLine(t);
                        engine.Remove(t.nodeInGrid);
                        if (engine.mainProcessArea != null)
                        {
                            //here we check if the main process area is linked to the deleted conveyor and remove any connections
                            foreach (Conveyor c in engine.mainProcessArea.nextNodes.ToList())
                            {
                                if (c == first.nodeInGrid)
                                {
                                    engine.mainProcessArea.nextNodes.Remove(c);
                                }
                            }
                        }
                    }
                    else if (t is MPATile)
                    {
                        thisGrid.RemoveMPA(t);
                        engine.Remove(t.nodeInGrid);
                        rbMPA.Visible = true;
                    }
                    else
                    {
                        engine.Remove(t.nodeInGrid);
                        thisGrid.RemoveNode(t);
                    }
                    RefreshCheckInCombobox();
                    RefreshDropOffCombobox();
                }
            }
            //getting information about the clicked tile when not building (buildModeActive == false)
            else
            {
                if (!(t is EmptyTile))
                {
                    Node n = thisGrid.ReturnNodeOnPosition(t);
                    lblNodeType.Text = n.GetType().Name;
                    lblBagStatus.Text = n.Status.ToString();
                    if (t.nodeInGrid.NextNode == null)
                    {
                        lblNextNode.Text = "null";
                    }
                    else
                    {
                        lblNextNode.Text = t.nodeInGrid.NextNode.ToString();
                    }
                }
            }
            lblColRow.Text = t.Column + " " + t.Row;

            //accessing special options for dropoffs
            if (selectedTile is DropOffTile)
            {
                selectedDropOffForSettings = selectedTile.nodeInGrid as DropOff;
                cbCapacity.Text = Convert.ToString(selectedDropOffForSettings.baggages.Capacity);
                cbEmployees.Text = Convert.ToString(selectedDropOffForSettings.EmployeeSpeed);
                gbDropOffSettings.Text = $"DropOff {selectedDropOffForSettings.DestinationGate} Settings";
                gbDropOffSettings.Visible = true;
            }
            else
            {
                gbDropOffSettings.Visible = false;
            }
            animationBox.Invalidate();
        }

        private void AnimationBox_MouseMove(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);

            //each conveyor can consist of multiple tiles with one node, as opposed to the other elements(checkin, security, dropoff) 
            //which all take a single position on the grid, with the exception of the MPA
            if (isBuildingConveyor)
            {
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1))
                {
                    if (t is EmptyTile && t.Unselectable == false)
                    {
                        GridTile created = thisGrid.AddConveyorLineAtCoordinates(t);
                        conveyorBuilding.Add((ConveyorTile)created);

                        thisGrid.ConnectTiles(selectedTile, t);
                        SelectTile(created);
                    }
                }
            }
            if (isConnectingTiles)
            {
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1))
                {
                    /**
                    //it is impossible to connect one conveyor to the middle of the other
                    //you must connect the end of the conveyor with the beginning of the next one
                    //that is why we have special checks
                     **/
                    if(selectedTile is ConveyorTile && t is ConveyorTile) {
                        ConveyorTile tempEnd = selectedTile as ConveyorTile;
                        ConveyorTile tempBeg = t as ConveyorTile;
                        if(tempEnd.isLastTile && tempBeg.PositionInLine == 0)
                        {
                            thisGrid.ConnectTiles(selectedTile, t);
                            engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        }
                    }
                    //here we must ensure that the selected conveyor tile is the last tile in the conveyor
                    else if (selectedTile is ConveyorTile && !(t is EmptyTile)&& !(t is CheckInTile))
                    {
                        ConveyorTile temp = (ConveyorTile)selectedTile;
                        if (temp.isLastTile)
                        {
                            engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                            thisGrid.ConnectTiles(selectedTile, t);
                            if (t is DropOffTile)
                            {
                                var selectedConveyor = selectedTile.nodeInGrid as Conveyor;
                                var tNode = t.nodeInGrid as DropOff;
                                selectedConveyor.DestinationGate = tNode.DestinationGate;
                            }
                        }
                    }
                    else if (selectedTile is CheckInTile && t is ConveyorTile)
                    {
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        thisGrid.ConnectTiles(selectedTile, t);
                    }
                    else if (selectedTile is SecurityTile && t is ConveyorTile)
                    {
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        thisGrid.ConnectTiles(selectedTile, t);
                    }
                    //since the mpa is the only element that can have multiple nextNodes, special checking needs to be performed
                    else if (selectedTile is MPATile && t is ConveyorTile)
                    {
                        var selectedMPA = selectedTile.nodeInGrid as MPA;
                        selectedMPA.AddNextNode(t.nodeInGrid as Conveyor);
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        thisGrid.ConnectTiles(selectedTile, t);
                    }
                }
            }

            animationBox.Invalidate();
        }

        private void AnimationBox_MouseUp(object sender, MouseEventArgs e)
        {
            //if a conveyor has been built, there are a number of things that need checking
            if (buildModeActive && isBuildingConveyor)
            {
                Conveyor conveyor = new Conveyor(conveyorBuilding.Count, 0);
                engine.AddConveyorPart(conveyor);
                System.Diagnostics.Debug.WriteLine("uppress");
                int i = 0;
                /**
                //foreach tile in the newly build conveyor we:
                // add a node - the same node for all of course
                // assing positions to each tile in the conveyor
                // check if there are any tiles connected to the beginning and end of the conveyor
                //and automatically connect to them
                // for the other elements, auto connection checks and adding the node is performed on the mouse down event
                // the hature of the conveyor requires this different implementation 
                **/
                foreach (ConveyorTile t in conveyorBuilding)
                {
                    t.nodeInGrid = conveyor;
                    t.PositionInLine = i;
                    if (t.PositionInLine == 0)
                    {
                        GridTile tt = thisGrid.AutoConnectToPrev(t, thisGrid.GetNeighboursIn4Directions);
                        //if the previous tile was a mpa
                        if (tt != null && tt is MPATile)
                        {
                            MPA tempMPA = tt.nodeInGrid as MPA;
                            tempMPA.AddNextNode(t.nodeInGrid as Conveyor);
                        }
                        else if (tt != null)
                        {
                            engine.LinkTwoNodes(tt.nodeInGrid, t.nodeInGrid);
                        }
                    }
                    i++;
                }
                conveyorBuilding.Last().isLastTile = true;

                GridTile temp = thisGrid.AutoConnectToNext(selectedTile, thisGrid.GetNeighboursIn4Directions);
                if (temp != null)
                {
                    engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                    //setting the destination gate of the conveyor if it connects to any drop offs
                    if (temp is DropOffTile)
                    {
                        Conveyor selectedConveyor = selectedTile.nodeInGrid as Conveyor;
                        DropOff selectedDropOff = temp.nodeInGrid as DropOff;
                        selectedConveyor.DestinationGate = selectedDropOff.DestinationGate;
                    }
                }
            }

            // resetting all values needed to return the user to the state before the mouse down 
            isConnectingTiles = false;
            if (selectedTile != null)
            {
                selectedTile.selected = false;
                selectedTile = null;
            }
            isBuildingConveyor = false;
            conveyorBuilding.Clear();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            gbDropOffSettings.Visible = false;
            if (engine.dispatcher == null)
            {
                engine.AddDispatcher();
            }
            engine.Run();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimerSequence);
            aTimer.Interval = 1;
            aTimer.Start();
            btnRun.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            buttonResume.Enabled = false;
            btnCompare.Enabled = true;
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            engine.Pause();
            buttonResume.Enabled = true;
            btnPause.Enabled = false;
        }
        private void buttonResume_Click(object sender, EventArgs e)
        {
            engine.Resume();
            buttonResume.Enabled = false;
            btnPause.Enabled = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            engine.Stop();
            engine.ResetCheckInDestinationGates();
            RefreshFlightsList();
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            buttonResume.Enabled = false;
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            int flightBaggage = 0;

            if (tbFlightNr.Text != "" && tbFlightBaggage.Text != "")
            {
                DateTime date = (Convert.ToDateTime(tbFlightTime.Text));
                string flightNr = tbFlightNr.Text;

                try
                {
                    flightBaggage = Convert.ToInt32(tbFlightBaggage.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("The number of baggages must be a valid positive number.");
                    return;
                }

                var selectedCheckIn = cbCheckInFlight.SelectedItem as CheckIn;
                var selectedDropOff = cbDropOffDest.SelectedItem as DropOff;
                int destGate = selectedDropOff.DestinationGate;

                if (!(engine.AddFlight(date, flightNr, flightBaggage, destGate)))
                {
                    MessageBox.Show("This flight already exists or the drop-off destination is already taken.");
                }
                else
                {
                    if (selectedCheckIn.HasDestinationGate())
                    {
                        MessageBox.Show("This check-in is already taken by another flight.");
                    }
                    else
                    {
                        RefreshFlightsList();
                        selectedCheckIn.DestinationGate = destGate;
                        btnDeleteFlight.Enabled = true;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please fill-in all required fields correctly");
            }
        }

        private void btnAddCheckinToFlight_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            var selectedCheckIn = cbCheckInFlight.SelectedItem as CheckIn;
            if (selectedCheckIn.HasDestinationGate())
            {
                MessageBox.Show("This check-in is already taken by another flight.");
            }
            else
            {
                selectedCheckIn.DestinationGate = selectedFlight.DestinationGate;

            }
        }

        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            DateTime date = (Convert.ToDateTime(tbFlightTime.Text));
            string flightNr = tbFlightNr.Text;
            int flightBaggage = Convert.ToInt32(tbFlightBaggage.Text);
            var selectedCheckIn = cbCheckInFlight.SelectedItem as CheckIn;
            var selectedDropOff = cbDropOffDest.SelectedItem as DropOff;
            int destGate = selectedDropOff.DestinationGate;

            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            if (!(engine.AddFlight(date, flightNr, flightBaggage, destGate)))
            {
                MessageBox.Show("This flight already exists or the drop-off destination is already taken.");
                if (selectedCheckIn.HasDestinationGate())
                {
                    MessageBox.Show("This check-in is already taken by another flight.");
                }
            }
            else
            {
                selectedCheckIn.DestinationGate = selectedFlight.DestinationGate;
                RefreshFlightsList();
            }
        }

        private void btnDeleteFlight_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            var selectedCheckIn = cbCheckInFlight.SelectedItem as CheckIn;
            if (selectedFlight != null)
            {
                if (!(engine.RemoveFlight(selectedFlight.FlightNumber)))
                {
                    MessageBox.Show("Flight not found.");
                }
                else
                {
                    selectedCheckIn.DestinationGate = 0;
                    lbFlights.DataSource = null;
                    lbFlights.DataSource = engine.flights;
                }
            }
            else
            {
                MessageBox.Show("Select a flight first!");
            }
        }

        public void RefreshFlightsList()
        {
            lbFlights.DataSource = null;
            lbFlights.DataSource = engine.flights;
        }
        public void RefreshDropOffCombobox()
        {
            cbDropOffDest.DataSource = null;
            cbDropOffDest.DataSource = engine.dropOffs;
        }
        public void RefreshCheckInCombobox()
        {
            cbCheckInFlight.DataSource = null;
            cbCheckInFlight.DataSource = engine.checkIns;
        }

        private void TimerSequence(object source, ElapsedEventArgs e)
        {
            animationBox.Invalidate();
        }

        //because each tile is responsible for knowing what to draw about itself
        //each tile contains a selected boolean
        //when a tile is selected, it will know to give the appropriate visual feedback
        private void SelectTile(GridTile t)
        {
            if (selectedTile != null)
            {
                selectedTile.selected = false;
            }
            selectedTile = t;
            selectedTile.selected = true;
        }

        private void ChbDeleteMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeleteMode.Checked)
            {
                deleteMode = true;
                gbBuildType.Visible = false;
                thisGrid.HideAndUnhideArea(null);
            }
            else
            {
                deleteMode = false;
                thisGrid.HideAndUnhideArea(buildModeType);
                gbBuildType.Visible = true;
            }
            animationBox.Invalidate();
        }

        //clearing the grid
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            gbDropOffSettings.Visible = false;
            thisGrid.ClearGrid();
            this.engine = new Engine();
            RefreshCheckInCombobox();
            RefreshDropOffCombobox();
            RefreshFlightsList();
            animationBox.Invalidate();
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {

            SeriesCollection series = new SeriesCollection();
            int dropOffCounter = 0;

            foreach (var index in Enumerable.Range(0, engine.GetFlightDepartureTimes().Count))
            {
                dropOffCounter++;
                series.Add(new ColumnSeries() { Title = $"Estimated Departure time flight {dropOffCounter.ToString()}", Values = new ChartValues<int> { engine.GetFlightDepartureTimes()[index].Minute } });
                series.Add(new ColumnSeries() { Title = $"Actual Departure time flight {dropOffCounter.ToString()}", Values = new ChartValues<int> { engine.GetLastBaggageTimes()[index].AddMinutes(engine.GetTransferTime()[index].Seconds).Minute } });
            }

            cartesianChartTimes.Series = series;
            btnCompare.Enabled = false;
        }

        private LineSeries PopulateCartesianTimesChart(List<DateTime> values, string lineTitle, int scalesY)
        {
            var lineSeries = new LineSeries() { Title = lineTitle, ScalesYAt = scalesY, Values = new ChartValues<int>() };
            var colors = new List<Brush>() { Brushes.DodgerBlue, Brushes.HotPink };
            var axisTitles = new List<string>() { "Estimated departure time", "Actual departure time" };

            values.ForEach(v => lineSeries.Values.Add(v.Minute));
            AddCartesianTimesChartAxis(axisTitles[scalesY], colors[scalesY]);

            return lineSeries;
        }

        private void AddCartesianTimesChartAxis(string title, Brush color)
        {
            cartesianChartTimes.AxisY.Add(new Axis
            {
                Foreground = color,
                Title = title,
                Position = AxisPosition.LeftBottom
            });
        }
        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            engine.GetGridTiles(thisGrid);
            engine.WriteToFile();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var message = engine.LoadFromFile();
            if (message != "")
            {
                MessageBox.Show(message);
            }
            else
            {
                thisGrid.LoadGrid(engine.tiles);
                RefreshCheckInCombobox();
                RefreshDropOffCombobox();
                RefreshFlightsList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            double failed = engine.GetCalculatePercentageFailedBaggage();
            double successed = engine.GetCalculateSuccessedBaggage();
            series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<double> { failed } });
            series.Add(new PieSeries() { Title = "Successed ", Values = new ChartValues<double> { successed } });

            pieChartPercentageAllFailedBaggage.Series = series;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            int securityCounter = 0;
            foreach (var number in engine.GetSecurityStats())
            {
                securityCounter++;
                series.Add(new ColumnSeries() { Title = $"Security {securityCounter.ToString()}", Values = new ChartValues<int> { number } });
            }
            cartesianChartFailedToPassBaggage.Series = series;
        }

        private void buttonTransTimePerFlight_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            int dropOffCounter = 0;

            engine.GetTransferTime().ForEach(x =>
            {
                dropOffCounter++;
                series.Add(new ColumnSeries() { Title = $"Flight {dropOffCounter.ToString()}", Values = new ChartValues<int> { x.Seconds } });
            });

            cartesianChartBaggageProcessedByCheckin.Series = series;
        }

        private void cbCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDropOffForSettings.baggages.Capacity = Convert.ToInt32(cbCapacity.Text);
        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDropOffForSettings.SetNumberEmployees(Convert.ToInt32(cbEmployees.Text));
        }
    }
}

