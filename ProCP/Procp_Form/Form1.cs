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

                thisGrid.HideArea(buildModeType);

            }
            else
            {
                buildModeActive = false;
                lblTest.Text = buildModeActive ? "[On]" : "[Off]";
                gbBuildType.Visible = false;
                chbDeleteMode.Checked = false;
                chbDeleteMode.Visible = false;
                buildModeType = null;
                thisGrid.HideArea(buildModeType);
            }
            animationBox.Invalidate();
        }

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
            thisGrid.HideArea(buildModeType);
            animationBox.Invalidate();
        }

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

            thisGrid.HideArea(buildModeType);
            animationBox.Invalidate();
        }

        private void AnimationBox_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);

            SelectTile(t);

            if (buildModeActive)
            {
                if (t is EmptyTile && t.Unselectable == false)
                {
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

                        GridTile temp = thisGrid.AutoConnectToPrev(selectedTile, thisGrid.GetTilesIn4Directions);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(temp.nodeInGrid, selectedTile.nodeInGrid);
                        }

                        temp = thisGrid.AutoConnectToNext(selectedTile, thisGrid.GetTilesIn4Directions);
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
                        thisGrid.AddMPA(t, mpa);
                        engine.AddMPA(mpa);

                        SelectTile(thisGrid.FindTileInRowColumnCoordinates(t.Column, t.Row));
                        List<GridTile> tempMPA = thisGrid.GetMPA(selectedTile);
                        foreach (GridTile m in tempMPA)
                        {
                            GridTile temp = thisGrid.AutoConnectToPrev(m, thisGrid.GetTilesIn4Directions);
                            if (temp != null)
                            {
                                engine.LinkTwoNodes(temp.nodeInGrid, m.nodeInGrid);
                            }
                            temp = thisGrid.AutoConnectToNext(m, thisGrid.GetTilesIn4Directions);
                            if (temp != null && temp.nodeInGrid is Conveyor)
                            {
                                mpa.AddNextNode(temp.nodeInGrid as Conveyor);
                            }
                        }

                    }
                }
                else if (!(t is EmptyTile) && deleteMode == false)
                {
                    isConnectingTiles = true;
                }
                else if (!(t is EmptyTile) && deleteMode == true)
                {
                    if (t is ConveyorTile)
                    {
                        ConveyorTile first = thisGrid.RemoveConveyorLine(t);
                        engine.Remove(t.nodeInGrid);

                        if (engine.mainProcessArea != null)
                        {
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
            //gbDropOffSettings.Visible = false;
            animationBox.Invalidate();
        }

        private void AnimationBox_MouseMove(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);

            if (isBuildingConveyor)
            {
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1))
                {
                    if (t is EmptyTile && t.Unselectable == false)
                    {
                        //Conveyor conveyor = new Conveyor();
                        GridTile created = thisGrid.AddConveyorLineAtCoordinates(t);
                        //Engine.AddConveyorPart(conveyor);
                        conveyorBuilding.Add((ConveyorTile)created);

                        thisGrid.ConnectTiles(selectedTile, t);
                        // Engine.LinkTwoNodes(selectedTile.nodeInGrid, created.nodeInGrid);
                        SelectTile(created);

                    }
                }
            }
            if (isConnectingTiles)
            {
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1))
                {
                    if (selectedTile is ConveyorTile && !(t is EmptyTile) && !(t is ConveyorTile) && !(t is CheckInTile))
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
                    else if (selectedTile is ConveyorTile && t is SecurityTile)
                    {
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        thisGrid.ConnectTiles(selectedTile, t);
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
            if (buildModeActive && isBuildingConveyor)
            {
                Conveyor conveyor = new Conveyor(conveyorBuilding.Count, 0);
                engine.AddConveyorPart(conveyor);
                System.Diagnostics.Debug.WriteLine("uppress");
                int i = 0;
                foreach (ConveyorTile t in conveyorBuilding)
                {
                    t.nodeInGrid = conveyor;
                    t.PositionInLine = i;
                    if (t.PositionInLine == 0)
                    {
                        GridTile tt = thisGrid.AutoConnectToPrev(t, thisGrid.GetTilesIn4Directions);
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

                GridTile temp = thisGrid.AutoConnectToNext(selectedTile, thisGrid.GetTilesIn4Directions);
                if (temp != null)
                {
                    engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                    if (temp is DropOffTile)
                    {
                        Conveyor selectedConveyor = selectedTile.nodeInGrid as Conveyor;
                        DropOff selectedDropOff = temp.nodeInGrid as DropOff;
                        selectedConveyor.DestinationGate = selectedDropOff.DestinationGate;
                    }
                }
            }

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
                //buildModeType = null;
                gbBuildType.Visible = false;
                thisGrid.HideArea(buildModeType);

            }
            else
            {
                deleteMode = false;
                thisGrid.HideArea(buildModeType);
                gbBuildType.Visible = true;
            }
            animationBox.Invalidate();
        }


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
            //var scalesY = 0;

            //cartesianChartTimes.Series.Add(PopulateCartesianTimesChart(engine.GetFlightDepartureTimes(), "Flight time", scalesY++));
            //cartesianChartTimes.Series.Add(PopulateCartesianTimesChart(engine.GetLastBaggageTimes(), "Baggage time", scalesY++));


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

