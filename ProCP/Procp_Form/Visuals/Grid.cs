﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Procp_Form.Visuals;

namespace Procp_Form.Visuals
{
    class Grid
    {
        float tileWidth;
        float tileHeight;
        int tileHorizontalCount = 10;
        int tileVerticalCount = 10;
        float animBoxWidth;
        float animBoxHeigth;

        List<GridTile> gridTiles;

        int hideAreaNotCheckInRows = 0;

        int hideAreaNotConveyorRowsTop = 9;
        int hideAreaNotConveyorRowsBottom = 0;


        int hideAreaNotForDropOff = 9;

        public Grid(int animBoxW, int abBoxH)
        {
            gridTiles = new List<GridTile>();

            animBoxWidth = animBoxW;
            animBoxHeigth = abBoxH;
            tileWidth = (animBoxWidth - 1) / tileHorizontalCount;
            tileHeight = (animBoxHeigth - 1) / tileVerticalCount;

            CreateGrid();
        }
        public int TileHorizontalCount
        {
            get { return tileHorizontalCount; }
            set { tileHorizontalCount = value; }
        }
        public int TileVerticalCount
        {
            get { return tileVerticalCount; }
            set { tileVerticalCount = value; }
        }

        private void CreateGrid()
        {
            for (int c = 0; c < tileHorizontalCount; c++)
            {
                for (int r = 0; r < tileVerticalCount; r++)
                {
                    gridTiles.Add(new EmptyTile(c, r));
                }
            }
        }
        public void DrawGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.FillRectangle(Brushes.Cyan, 0, 0, animBoxWidth, animBoxHeigth);

            foreach (GridTile n in gridTiles)
            {
                n.DrawTile(e, tileWidth, tileHeight);
            }
        }
        public ConveyorTile AddConveyorLineAtCoordinates(GridTile toReplace)
        {
            ConveyorTile newLineTile = new ConveyorTile();
            newLineTile.Column = toReplace.Column;
            newLineTile.Row = toReplace.Row;
            gridTiles.Remove(toReplace);
            gridTiles.Add(newLineTile);
            return newLineTile;
        }

        public bool CheckIfTilesAreEmpty(GridTile firstTile, int cRange, int rRange)
        {
            int firstC = firstTile.Column;
            int firstR = firstTile.Row;
            for(int i = firstC; i < firstC + cRange; i++)
            {
                for(int y = firstR; y < firstR + rRange; y++)
                {
                    GridTile temp = FindTileInRowColumnCoordinates(i, y);
                    if(!(temp is EmptyTile) || temp.Unselectable)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void AddMPA(GridTile firstTile, MPA mpa)
        {
            int cRange = 2;
            int rRange = 2;

            if (CheckIfTilesAreEmpty(firstTile, cRange, rRange))
            {
                for (int i = firstTile.Column; i < firstTile.Column + cRange; i++)
                {
                    for (int y = firstTile.Row; y < firstTile.Row + rRange; y++)
                    {
                        MPATile mpaTile = new MPATile();
                        mpaTile.Column = i;
                        mpaTile.Row = y;
                        GridTile temp = FindTileInRowColumnCoordinates(i, y);
                        gridTiles.Remove(temp);
                        gridTiles.Add(mpaTile);
                        mpaTile.nodeInGrid = mpa;
                    }
                }
            }
        }

        public GridTile AddCheckInAtCoordinates(GridTile toReplace, Node nodeToPlace)
        {
            CheckInTile newCheckInTile = new CheckInTile();
            newCheckInTile.Column = toReplace.Column;
            newCheckInTile.Row = toReplace.Row;
            gridTiles.Remove(toReplace);
            gridTiles.Add(newCheckInTile);
            newCheckInTile.nodeInGrid = nodeToPlace;
            return newCheckInTile;
        }

        public GridTile AddSecurityAtCoordinates(GridTile toReplace, Node nodeToPlace)
        {
            SecurityTile newSecurityTile = new SecurityTile();
            newSecurityTile.Column = toReplace.Column;
            newSecurityTile.Row = toReplace.Row;
            gridTiles.Remove(toReplace);
            gridTiles.Add(newSecurityTile);
            newSecurityTile.nodeInGrid = nodeToPlace;
            return newSecurityTile;
        }

        public GridTile AddDropOffAtCoordinates(GridTile toReplace, Node nodeToPlace)
        {
            DropOffTile newDropOffTile = new DropOffTile();
            newDropOffTile.Column = toReplace.Column;
            newDropOffTile.Row = toReplace.Row;
            gridTiles.Remove(toReplace);
            gridTiles.Add(newDropOffTile);
            newDropOffTile.nodeInGrid = nodeToPlace;
            return newDropOffTile;
        }
        public GridTile FindTileInPixelCoordinates(float targetX, float targetY)
        {
            GridTile foundTile = new EmptyTile();
            foreach (GridTile n in gridTiles)
            {
                if ((n.Column * tileWidth) <= targetX && (n.Column * tileWidth) + tileWidth >= targetX && (n.Row * tileHeight) <= targetY && (n.Row * tileHeight) + tileHeight >= targetY)
                {
                    foundTile = n;
                   // MessageBox.Show(n.Column + " " + n.Row + " FOUND");
                    break;
                }
            }
            return foundTile;
        }
        public GridTile FindTileInRowColumnCoordinates(float  targetColumn, float targetRow)
        {
            GridTile foundTile = new EmptyTile();
            foreach (GridTile n in gridTiles)
            {
                if (n.Column == targetColumn && n.Row == targetRow)
                {
                    foundTile = n;
                    break;
                }
            }
            return foundTile;
        }

        public void HideArea(string buildType)
        {
            if (buildType == null)
            {
                foreach(GridTile t in gridTiles)
                {
                    t.Unselectable = false;
                    t.SetTileUncklicableColor();
                }
            }
            else if(buildType == "Conveyor")
            {
                HideAreNotForConveyorAndSecurityAndMPA();
            }
            else if (buildType == "Security Scanner")
            {
                HideAreNotForConveyorAndSecurityAndMPA();
            }
            else if(buildType == "CheckIn")
            {
                HideAreaNotForCheckIn();
            }
            else if(buildType == "DropOff")
            {
                HideAreaNotForDropOff();
            }
            else if(buildType == "MPA")
            {
                HideAreNotForConveyorAndSecurityAndMPA();
            }
        }

        private void HideAreNotForConveyorAndSecurityAndMPA()
        {
            foreach (GridTile t in gridTiles)
            {
                if (t.Row == hideAreaNotConveyorRowsTop || t.Row == hideAreaNotConveyorRowsBottom)
                {
                    t.Unselectable = true;
                    t.SetTileUncklicableColor();
                }
                else
                {
                    t.Unselectable = false;
                    t.SetTileUncklicableColor();
                }
            }
        }

        private void HideAreaNotForCheckIn()
        {
            foreach (GridTile t in gridTiles)
            {
                if( t.Row != hideAreaNotCheckInRows)
                {
                    t.Unselectable = true;
                    t.SetTileUncklicableColor();
                }
                else
                {
                    t.Unselectable = false;
                    t.SetTileUncklicableColor();
                }
            }
        }

        private void HideAreaNotForDropOff()
        {
            foreach (GridTile t in gridTiles)
            {
                if (t.Row != hideAreaNotForDropOff)
                {
                    t.Unselectable = true;
                    t.SetTileUncklicableColor();
                }
                else
                {
                    t.Unselectable = false;
                    t.SetTileUncklicableColor();
                }
            }
        }

        public Node ReturnNodeOnPosition(GridTile clickedTile)
        {
            return clickedTile.nodeInGrid;
        }

        public void RemoveNode(GridTile toRemove)
        {
            foreach(GridTile t in gridTiles)
            {
                if(t.nextTile == toRemove)
                {
                    t.nextTile = null;
                    break;
                }
            }
            int index = gridTiles.IndexOf(toRemove, 0);
            EmptyTile empty = new EmptyTile();
            empty.Column = toRemove.Column;
            empty.Row = toRemove.Row;
            gridTiles.Remove(toRemove);
            gridTiles.Insert(index, empty);
        }

        //removes all tiles of a conveyor Line
        //the fact that the conveyor is not one tile completely goes agains the core design, and therefore we have methods like this one
        //I really cannot think of a better way to do this and I hate it - Boris Georgiev
        public void RemoveConveyorLine(GridTile toRemove)
        {
            ConveyorTile first = new ConveyorTile();
            foreach(GridTile t in gridTiles.ToList())
            {
                if(toRemove.nodeInGrid == t.nodeInGrid)
                {
                    ConveyorTile temp = (ConveyorTile) t;
                    if(temp.PositionInLine == 0)
                    {
                        first = temp;
                    }
                    int index = gridTiles.IndexOf(t, 0);
                    EmptyTile empty = new EmptyTile();
                    empty.Column = t.Column;
                    empty.Row = t.Row;
                    gridTiles.Remove(t);
                    gridTiles.Insert(index, empty);
                }
            }
            foreach(GridTile t in gridTiles.ToList())
            {
                if(t.nextTile == first)
                {
                    t.nextTile = null;
                    break;
                }
            }
        }

        public void RemoveMPA(GridTile toRemove)
        {
            foreach(GridTile t in gridTiles.ToList())
            {
                if(t.nodeInGrid == toRemove.nodeInGrid)
                {
                    int index = gridTiles.IndexOf(t, 0);
                    EmptyTile empty = new EmptyTile();
                    empty.Column = t.Column;
                    empty.Row = t.Row;
                    gridTiles.Remove(t);
                    gridTiles.Insert(index, empty);
                }
            }
        }
    }
}
