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
        public Baggager()
        {
            InitializeComponent();
            thisGrid = new Grid(animationBox.Width, animationBox.Height);


            buildModeActive = false;
            cmBoxNodeToBuild.Visible = false;
        }

        private void AnimationBox_Paint(object sender, PaintEventArgs e)
        {
            thisGrid.DrawGrid(e);
        }

        private void AnimationBox_MouseClick(object sender, MouseEventArgs e)
        {
            var mouseClick = e as MouseEventArgs;
           // MessageBox.Show(mouseClick.X + " " + mouseClick.Y);
            GridTile t = thisGrid.FindTileInPixelCoordinates(mouseClick.X, mouseClick.Y);
            if (buildModeActive)
            {
                if (buildModeType == "Conveyor") {
                  
                    if (t is EmptyTile && t.Unclickable == false)
                    {
                        thisGrid.AddConveyorLineAtCoordinates(t, new Conveyor());
                    }
                }
                else if (buildModeType == "CheckIn")
                {
                    if (t is EmptyTile && t.Unclickable == false)
                    {
                        thisGrid.AddCheckInAtCoordinates(t, new CheckIn());
                    }
                }
                else if(buildModeType == "DropOff")
                {
                    if (t is EmptyTile && t.Unclickable == false)
                    {
                        thisGrid.AddDropOffAtCoordinates(t, new DropOff(3));
                    }
                }
            }
            else
            {
                if (!(t is EmptyTile)) {
                    Node n = thisGrid.ReturnNodeOnPosition(t);
                    lblNodeType.Text = n.GetType().Name;
                    lblBagStatus.Text = n.Status.ToString();
                }
            }
            lblColRow.Text = t.Column + " " + t.Row;

            animationBox.Invalidate();
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
            if(buildModeActive && buildModeType == "Conveyor")
            {
                System.Diagnostics.Debug.WriteLine("press");
            }
        }
    }
}
