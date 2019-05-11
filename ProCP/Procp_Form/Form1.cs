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
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Procp_Form.Visuals;

namespace Procp_Form
{
    public partial class Baggager : Form
    {
        Grid thisGrid;

        bool buildModeActive;
        string buildModeType;

        bool isBuildingConveyor;
        bool isConnectingTiles;
        GridTile selectedTile;
        Engine Engine = new Engine();
        
        public Baggager()
        {
            InitializeComponent();
            thisGrid = new Grid(animationBox.Width, animationBox.Height);

            buildModeActive = false;
            cmBoxNodeToBuild.Visible = false;
            isBuildingConveyor = false;
            isConnectingTiles = false;
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
                lblTest.Text = buildModeActive.ToString();
                cmBoxNodeToBuild.Visible = true;

                buildModeType = cmBoxNodeToBuild.Text;
                thisGrid.HideArea(buildModeType);
            }
            else
            {
                buildModeActive = false;
                lblTest.Text = buildModeActive.ToString();
                cmBoxNodeToBuild.Visible = false;

                buildModeType = null;
                thisGrid.HideArea(buildModeType);
            }

            animationBox.Invalidate();
        }

        private void CmBoxNodeToBuild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmBoxNodeToBuild.Text == "CheckIn")
            {
                buildModeType = "CheckIn";
            }
            else if(cmBoxNodeToBuild.Text == "Conveyor")
            {
                buildModeType = "Conveyor";
            }
            else if(cmBoxNodeToBuild.Text == "DropOff")
            {
                buildModeType = "DropOff";
            }
            thisGrid.HideArea(buildModeType);

            animationBox.Invalidate();
        }

        private void AnimationBox_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);

            selectedTile = t;

            if (buildModeActive)
            {
                if (t is EmptyTile && t.Unselectable == false)
                {
                    if (buildModeType == "Conveyor")
                    {
                        Conveyor conveyor = new Conveyor();
                        selectedTile = thisGrid.AddConveyorLineAtCoordinates(t, conveyor);
                        Engine.AddConveyorPart(conveyor);
                        isBuildingConveyor = true;
                    }
                    else if (buildModeType == "CheckIn")
                    {
                        CheckIn checkin = new CheckIn();
                        selectedTile = thisGrid.AddCheckInAtCoordinates(t, checkin);
                        Engine.AddCheckIn(checkin);
                    }
                    else if (buildModeType == "DropOff")
                    {
                        DropOff dropoff = new DropOff();
                        selectedTile = thisGrid.AddDropOffAtCoordinates(t, dropoff);
                        Engine.AddDropOff(dropoff);
                    }
                }
                else if(!(t is EmptyTile))
                {
                    isConnectingTiles = true;
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

            if (buildModeActive && buildModeType == "Conveyor" && isBuildingConveyor)
            {
                System.Diagnostics.Debug.WriteLine("moving " + t.Column + " " + t.Row);
            }

            if (isBuildingConveyor)
            {              
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1)) {
                   if (t is EmptyTile && t.Unselectable == false)
                   {
                       Conveyor conveyor = new Conveyor();
                       GridTile created = thisGrid.AddConveyorLineAtCoordinates(t, conveyor);
                       Engine.AddConveyorPart(conveyor);

                       Engine.LinkTwoNodes(selectedTile.nodeInGrid, created.nodeInGrid);
                       selectedTile = created;
                   }
                }
            }
            if (isConnectingTiles)
            {
                if ((Math.Abs(t.Column - selectedTile.Column) == 1 && Math.Abs(t.Row - selectedTile.Row) == 0) || (Math.Abs(t.Column - selectedTile.Column) == 0 && Math.Abs(t.Row - selectedTile.Row) == 1))
                {
                    if(!(t is EmptyTile))
                    {
                        Engine.LinkTwoNodes(selectedTile.nodeInGrid, t.nodeInGrid);
                    }
                }
            }

            animationBox.Invalidate();
        }

        private void AnimationBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (buildModeActive && buildModeType == "Conveyor")
            {
                System.Diagnostics.Debug.WriteLine("uppress");
            }
            isBuildingConveyor = false;
            isConnectingTiles = false;
            selectedTile = null;
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            DateTime date = (Convert.ToDateTime(tbFlightTime.Text));
            string flightNr = tbFlightNr.Text;
            int flightBaggage = Convert.ToInt32(tbFlightBaggage.Text);
            Engine.AddFlight(date, flightNr, flightBaggage);
            lbFlights.Items.Add($"[#{flightNr}] {date.ToString()} ({flightBaggage})");
        }

        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Engine.AddCheckInDispatcher(new CheckInDispatcher());
            Engine.Run();
        }
    }
}
