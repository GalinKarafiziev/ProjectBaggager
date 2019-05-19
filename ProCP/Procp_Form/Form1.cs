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
        SeriesCollection series = new SeriesCollection();
        int queueCounter = 0;

        System.Timers.Timer aTimer;

        public Baggager()
        {
            InitializeComponent();
            thisGrid = new Grid(animationBox.Width, animationBox.Height);

            chbDeleteMode.Visible = false;
            buildModeActive = false;
            deleteMode = false;
            cmBoxNodeToBuild.Visible = false;
            isBuildingConveyor = false;
            isConnectingTiles = false;
            conveyorBuilding = new List<ConveyorTile>();

            cartesianChartBaggageProcessedByCheckin.Series = series;
            cbDropOffDest.DataSource = engine.dropOffs;
        }

        private void AnimationBox_Paint(object sender, PaintEventArgs e)
        {
            thisGrid.DrawGrid(e);
        }

        private void ChbBuildMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBuildMode.Checked)
            {
                cmBoxNodeToBuild.SelectedIndex = 0;

                buildModeActive = true;
                lblTest.Text = buildModeActive ? "[On]" : "[Off]";
                cmBoxNodeToBuild.Visible = true;
                chbDeleteMode.Visible = true;

                buildModeType = cmBoxNodeToBuild.Text;
                thisGrid.HideArea(buildModeType);

            }
            else
            {
                buildModeActive = false;
                lblTest.Text = buildModeActive ? "[On]" : "[Off]";
                cmBoxNodeToBuild.Visible = false;
                chbDeleteMode.Checked = false;
                chbDeleteMode.Visible = false;

                //hide area with null will make everything non hidden
                //you call HideArea() to remove all of the hiding
                //im a fuckin idiot - Boris Georgiev
                //PS: it works doe
                buildModeType = null;
                thisGrid.HideArea(buildModeType);
            }
            animationBox.Invalidate();
        }

        private void CmBoxNodeToBuild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBoxNodeToBuild.Text == "CheckIn")
            {
                buildModeType = "CheckIn";
            }
            else if (cmBoxNodeToBuild.Text == "Security Scanner")
            {
                buildModeType = "Security Scanner";
            }
            else if (cmBoxNodeToBuild.Text == "Conveyor")
            {
                buildModeType = "Conveyor";
            }
            else if (cmBoxNodeToBuild.Text == "DropOff")
            {
                buildModeType = "DropOff";
            }
            else if(cmBoxNodeToBuild.Text == "MPA")
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
                    }
                    else if (buildModeType == "Security Scanner")
                    {
                        Security security = new Security();
                        SelectTile(thisGrid.AddSecurityAtCoordinates(t, security));
                        engine.AddSecurity(security);
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
                    }
                    else if(buildModeType == "MPA")
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
                }
            }

            animationBox.Invalidate();
        }

        private void AnimationBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (buildModeActive && isBuildingConveyor)
            {
                Conveyor conveyor = new Conveyor(conveyorBuilding.Count, 1500);
                engine.AddConveyorPart(conveyor);
                System.Diagnostics.Debug.WriteLine("uppress");
                int i = 0;
                foreach (ConveyorTile t in conveyorBuilding)
                {
                    t.nodeInGrid = conveyor;
                    t.PositionInLine = i;
                    i++;
                }
                conveyorBuilding.Last().isLastTile = true;
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
            DateTime date = (Convert.ToDateTime(tbFlightTime.Text));
            string flightNr = tbFlightNr.Text;
            int flightBaggage = Convert.ToInt32(tbFlightBaggage.Text);
            var selectedDropOff = cbDropOffDest.SelectedItem as DropOff;
            int destGate = selectedDropOff.DestinationGate;
            if (!(engine.AddFlight(date, flightNr, flightBaggage, destGate)))
            {
                MessageBox.Show("This flight already exists or the drop-off destination is already taken.");
            }
            else
            {
                RefreshFlightsListBox();
                btnDeleteFlight.Enabled = true;
                btnEditFlight.Enabled = true;
            }
        }

        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            DateTime date = (Convert.ToDateTime(tbFlightTime.Text));
            string flightNr = tbFlightNr.Text;
            int flightBaggage = Convert.ToInt32(tbFlightBaggage.Text);
            var selectedDropOff = cbDropOffDest.SelectedItem as DropOff;
            int destGate = selectedDropOff.DestinationGate;

            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            if (!(engine.EditFlight(selectedFlight.FlightNumber, flightNr, flightBaggage, date, destGate)))
            {
                MessageBox.Show("Flight not found.");
            }
            else
            {
                RefreshFlightsListBox();
            }
        }

        private void btnDeleteFlight_Click(object sender, EventArgs e)
        {
            Flight selectedFlight = lbFlights.SelectedItem as Flight;
            if (!(engine.RemoveFlight(selectedFlight.FlightNumber)))
            {
                MessageBox.Show("Flight not found.");
            }
            else
            {
                RefreshFlightsListBox();
                if (!(engine.CheckFlights()))
                {
                    btnDeleteFlight.Enabled = false;
                    btnEditFlight.Enabled = false;
                }
            }
        }
        
        public void RefreshFlightsListBox()
        {
            lbFlights.DataSource = null;
            lbFlights.DataSource = engine.flights;
        }
        public void RefreshDropOffCombobox()
        {
            cbDropOffDest.DataSource = null;
            cbDropOffDest.DataSource = engine.dropOffs;
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

        private void buttonShowProcessedBaggage_Click(object sender, EventArgs e)
        {
            //engine.GetCheckInStats().ForEach(x =>
            //{
            //    checkinCounter++;
            //    this.listBox1.Items.Add($"checkin: {checkinCounter}, {x}");
            //});
        }

        private void buttonShowQueuedBaggage_Click(object sender, EventArgs e)
        {
            //engine.GetQueueCounter().ForEach(x =>
            //{
            //    queueCounter++;
            //    this.listBox1.Items.Add($"queues: {queueCounter}, {x}");
            //});
        }

        private void ChbDeleteMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeleteMode.Checked)
            {
                deleteMode = true;
                buildModeType = null;
                thisGrid.HideArea(buildModeType);
                cmBoxNodeToBuild.Visible = false;
            }
            else
            {
                deleteMode = false;
                buildModeType = cmBoxNodeToBuild.Text;
                thisGrid.HideArea(buildModeType);
                cmBoxNodeToBuild.Visible = true;
            }
            animationBox.Invalidate();
        }

        private void buttonLoadChartBaggageThroughCheckin_Click(object sender, EventArgs e)
        {
            series.Clear();
            checkinCounter = 0;
            foreach (var number in engine.GetCheckInStats())
            {
                checkinCounter++;
                series.Add(new ColumnSeries() {Title = $"Checkin {checkinCounter.ToString()}", Values = new ChartValues<int> { number }});   
            }
        }
    }
}

