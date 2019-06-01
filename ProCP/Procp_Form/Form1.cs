using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Procp_Form.CoreAbstraction;
using Procp_Form.Visuals;
using System.Timers;
using LiveCharts;
using LiveCharts.Wpf;
using Procp_Form.Airport;

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
        GridTile selectedTile;
        List<ConveyorTile> conveyorBuilding;
        Engine engine = new Engine();
        int checkinCounter = 0;

        System.Timers.Timer aTimer;

        public Baggager()
        {
            InitializeComponent();
            thisGrid = new Grid(animationBox.Width, animationBox.Height);

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

                        GridTile temp = thisGrid.AutoConnectNext(selectedTile);
                        if(temp != null)
                        {
                            engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                        }
                    }
                    else if (buildModeType == "Security Scanner")
                    {
                        Security security = new Security();
                        SelectTile(thisGrid.AddSecurityAtCoordinates(t, security));
                        engine.AddSecurity(security);

                        GridTile temp = thisGrid.AutoConnectToPrevious(selectedTile);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(temp.nodeInGrid, selectedTile.nodeInGrid);
                        }

                        temp = thisGrid.AutoConnectNext(selectedTile);
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

                        GridTile temp = thisGrid.AutoConnectToPrevious(selectedTile);
                        if (temp != null)
                        {
                            engine.LinkTwoNodes(temp.nodeInGrid, selectedTile.nodeInGrid);
                        }
                    }
                    else if (buildModeType == "MPA")
                    {
                        MPA mpa = new MPA();
                        thisGrid.AddMPA(t, mpa);
                        engine.AddMPA(mpa);
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
                        thisGrid.RemoveConveyorLine(t);
                        engine.Remove(t.nodeInGrid);
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

                        selectedTile.ConnectNext(created);

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
                            selectedTile.ConnectNext(t);
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
                        selectedTile.ConnectNext(t);
                    }
                    else if (selectedTile is CheckInTile && t is ConveyorTile)
                    {
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        selectedTile.ConnectNext(t);
                    }
                    else if (selectedTile is SecurityTile && t is ConveyorTile)
                    {
                        engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        selectedTile.ConnectNext(t);
                    }
                    else if (selectedTile is MPATile && t is ConveyorTile)
                    {
                        var selectedMPA = selectedTile.nodeInGrid as MPA;
                        selectedMPA.AddNextNode(t.nodeInGrid as Conveyor);
                        //engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                        selectedTile.ConnectNext(t);
                    }
                }
            }

            animationBox.Invalidate();
        }

        private void AnimationBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (buildModeActive && isBuildingConveyor)
            {
                Conveyor conveyor = new Conveyor(conveyorBuilding.Count, 1);
                engine.AddConveyorPart(conveyor);
                int i = 0;
                foreach (ConveyorTile t in conveyorBuilding)
                {
                   
                    t.nodeInGrid = conveyor;
                    if (t.PositionInLine == 0)
                    {
                        GridTile igiveuponthisshittycodefuckthisyesiknowiwroteitbutthebackendisalsogarbagethiswholeprojectis = thisGrid.AutoConnectToPrevious(t);
                        if (igiveuponthisshittycodefuckthisyesiknowiwroteitbutthebackendisalsogarbagethiswholeprojectis != null)
                        {
                            engine.LinkTwoNodes(igiveuponthisshittycodefuckthisyesiknowiwroteitbutthebackendisalsogarbagethiswholeprojectis.nodeInGrid, t.nodeInGrid);
                        }
                    }
                    t.PositionInLine = i;
                    i++;
                }
                conveyorBuilding.Last().isLastTile = true;

                GridTile temp = thisGrid.AutoConnectNext(selectedTile);
                if (temp != null)
                {
                    engine.LinkTwoNodes(selectedTile.nodeInGrid, temp.nodeInGrid);
                }
            }

            isBuildingConveyor = false;
            isConnectingTiles = false;
            if (selectedTile != null)
            {
                selectedTile.selected = false;
                selectedTile = null;
            }
            conveyorBuilding.Clear();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (engine.dispatcher == null)
            {
                engine.AddDispatcher();
            }
            engine.Run();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimerSequence);
            aTimer.Interval = 1;
            aTimer.Start();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            engine.Pause();
        }
        private void buttonResume_Click(object sender, EventArgs e)
        {
            engine.Resume();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            engine.Stop();
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
                        btnAddCheckinToFlight.Enabled = true;
                        btnEditFlight.Enabled = true;
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
                RefreshFlightsList();
            }
        }

        private void btnDeleteFlight_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            if (selectedFlight != null)
            {
                if (!(engine.RemoveFlight(selectedFlight.FlightNumber)))
                {
                    MessageBox.Show("Flight not found.");
                }
                else
                {
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

        private void buttonLoadChartBaggageThroughCheckin_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            checkinCounter = 0;
            foreach (var number in engine.GetCheckInStats())
            {
                checkinCounter++;
                series.Add(new ColumnSeries() { Title = $"Checkin {checkinCounter.ToString()}", Values = new ChartValues<int> { number } });
            }
            cartesianChartBaggageProcessedByCheckin.Series = series;
        }

        private void buttonFailedSecurityCheck_Click(object sender, EventArgs e)
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

        private void buttonRefreshPercentageFailedBags_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            double failed = engine.GetCalculatePercentageFailedBaggage();
            double successed = engine.GetCalculateSuccessedBaggage();
            series.Add(new PieSeries() { Title = "Failed", Values = new ChartValues<double> { failed }});
            series.Add(new PieSeries() { Title = "Successed ", Values = new ChartValues<double> { successed } });

            pieChartPercentageAllFailedBaggage.Series = series;
        }

        private void BtnClearGrid_Click(object sender, EventArgs e)
        {
            thisGrid.ClearGrid();
            RefreshCheckInCombobox();
            RefreshDropOffCombobox();
            animationBox.Invalidate();
        }

    }
}

