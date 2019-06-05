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
        int tileHorizontalCount = 20;
        int tileVerticalCount = 20;
        float animBoxWidth;
        float animBoxHeigth;

        List<GridTile> gridTiles;

        int hideAreaNotCheckInRows = 0;
        int hideAreaNotConveyorRowsTop;
        int hideAreaNotConveyorRowsBottom = 0;
        int hideAreaNotForDropOff;

        public Grid(int animBoxW, int abBoxH)
        {
            gridTiles = new List<GridTile>();

            animBoxWidth = animBoxW;
            animBoxHeigth = abBoxH;
            tileWidth = (animBoxWidth - 1) / tileHorizontalCount;
            tileHeight = (animBoxHeigth - 1) / tileVerticalCount;

            hideAreaNotForDropOff = tileVerticalCount - 1;
            hideAreaNotConveyorRowsTop = tileVerticalCount - 1;

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
                    gridTiles.Add(new EmptyTile(c, r, (int)tileWidth, (int)tileHeight));
                }
            }
        }

        private void LoadGrid(List<GridTile> load)
        {
            gridTiles.Clear();
            foreach(GridTile c in load)
            {
                gridTiles.Add(c);
            }
        }

        public void DrawGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.FillRectangle(Brushes.Cyan, 0, 0, animBoxWidth, animBoxHeigth);

            foreach (GridTile n in gridTiles)
            {
                n.DrawTile(e);
            }
        }
        public ConveyorTile AddConveyorLineAtCoordinates(GridTile toReplace)
        {
            ConveyorTile newLineTile = new ConveyorTile(toReplace.Column, toReplace.Row, (int)tileWidth, (int)tileHeight);
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
            int cRange = TileVerticalCount / 4;
            int rRange = tileHorizontalCount / 4;


            if (CheckIfTilesAreEmpty(firstTile, cRange, rRange))
            {
                for (int i = firstTile.Column; i < firstTile.Column + cRange; i++)
                {
                    for (int y = firstTile.Row; y < firstTile.Row + rRange; y++)
                    {
                        MPATile mpaTile = new MPATile(i, y, (int)tileWidth, (int)tileHeight);
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
            CheckInTile newCheckInTile = new CheckInTile(toReplace.Column, toReplace.Row, (int)tileWidth, (int)tileHeight);
            gridTiles.Remove(toReplace);
            gridTiles.Add(newCheckInTile);
            newCheckInTile.nodeInGrid = nodeToPlace;
            return newCheckInTile;
        }

        public GridTile AddSecurityAtCoordinates(GridTile toReplace, Node nodeToPlace)
        {
            SecurityTile newSecurityTile = new SecurityTile(toReplace.Column, toReplace.Row, (int)tileWidth, (int)tileHeight);
            gridTiles.Remove(toReplace);
            gridTiles.Add(newSecurityTile);
            newSecurityTile.nodeInGrid = nodeToPlace;
            return newSecurityTile;
        }

        public GridTile AddDropOffAtCoordinates(GridTile toReplace, Node nodeToPlace)
        {
            DropOffTile newDropOffTile = new DropOffTile(toReplace.Column, toReplace.Row, (int)tileWidth, (int)tileHeight);
            gridTiles.Remove(toReplace);
            gridTiles.Add(newDropOffTile);
            newDropOffTile.nodeInGrid = nodeToPlace;
            return newDropOffTile;
        }
        public GridTile FindTileInPixelCoordinates(float targetX, float targetY)
        {
            GridTile foundTile = new EmptyTile(-1, -1, (int)tileWidth, (int)tileHeight);
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
        public GridTile FindTileInRowColumnCoordinates(int targetColumn, int targetRow)
        {
            GridTile foundTile = new EmptyTile(targetColumn, targetRow, (int)tileWidth, (int)tileHeight);
            foreach (GridTile n in gridTiles)
            {
                if (n.Column == targetColumn && n.Row == targetRow)
                {
                    foundTile = n;
                    return foundTile;
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
                if(t.NextTile == toRemove)
                {
                    t.ClearNextTile();
                    break;
                }
            }
            int index = gridTiles.IndexOf(toRemove, 0);
            EmptyTile empty = new EmptyTile(toRemove.Column, toRemove.Row, (int)tileWidth, (int)tileHeight);

            gridTiles.Remove(toRemove);
            gridTiles.Insert(index, empty);
        }

        public void RemoveConveyorLine(GridTile toRemove)
        {
            ConveyorTile first = new ConveyorTile(1,1, (int)tileWidth, (int)tileHeight);
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
                    EmptyTile empty = new EmptyTile(t.Column, t.Row, (int)tileWidth, (int)tileHeight);
                    gridTiles.Remove(t);
                    gridTiles.Insert(index, empty);
                }
            }
            foreach(GridTile t in gridTiles.ToList())
            {
                if(t.NextTile == first)
                {
                    t.ClearNextTile();
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
                    EmptyTile empty = new EmptyTile(t.Column, t.Row, (int)tileWidth, (int)tileHeight);
                    gridTiles.Remove(t);
                    gridTiles.Insert(index, empty);
                }
            }
        }

        public void ClearGrid()
        {
            gridTiles.Clear();
            CreateGrid();
        }

        public void ConnectTiles(GridTile sender, GridTile receiver)
        {
            sender.SetNextTile(receiver);
        }

        public List<GridTile> GetTilesIn4Directions(GridTile c)
        {
            List<GridTile> tempTiles = new List<GridTile>();
            tempTiles.Add(FindTileInRowColumnCoordinates(c.Column, c.Row - 1));
            tempTiles.Add(FindTileInRowColumnCoordinates(c.Column, c.Row + 1));
            tempTiles.Add(FindTileInRowColumnCoordinates(c.Column + 1, c.Row));
            tempTiles.Add(FindTileInRowColumnCoordinates(c.Column - 1, c.Row));

            foreach(GridTile t in tempTiles.ToList())
            {
                if(t == null)
                {
                    tempTiles.Remove(t);
                }
            }
            return tempTiles;
        }
        private GridTile ConnectToConveyorBeginning(GridTile c, ConveyorTile temp)
        {
            if (temp.PositionInLine == 0)
            {
                c.SetNextTile(temp);
                return temp;
            }
            return null;
        }
        private GridTile ConnectToConveyorPrevious(GridTile c, ConveyorTile temp)
        {
            if (temp.isLastTile)
            {
                ConnectTiles(temp, c);
                return temp;
            }
            return null;
        }
        public GridTile AutoConnectDropOff(GridTile c)
        {
            GridTile temp = FindTileInRowColumnCoordinates(c.Column, c.Row - 1);
            if(temp is ConveyorTile)
            {
                if (ConnectToConveyorPrevious(c, temp as ConveyorTile) != null)
                    return temp;
            }
            return null;
        }
        public GridTile AutoConnectCheckIn(GridTile c)
        {
            GridTile temp = FindTileInRowColumnCoordinates(c.Column, c.Row + 1);
            if (temp is ConveyorTile)
            {
                if (ConnectToConveyorBeginning(c, temp as ConveyorTile) != null)
                    return temp;
            }
            return null;
        }
        public GridTile AutoConnectSecurityToPrev(GridTile c)
        {
            List<GridTile> tempList = GetTilesIn4Directions(c);

            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if(ConnectToConveyorPrevious(c, t as ConveyorTile) != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }
        public GridTile AutoConnectSecurityToNext(GridTile c)
        {
            List<GridTile> tempList = GetTilesIn4Directions(c);

            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if (ConnectToConveyorBeginning(c, t as ConveyorTile) != null)
                        return t;
                }
            }
            return null;
        }
        public GridTile AutoConnectConveyorToPrevious(GridTile c)
        {
            List<GridTile> tempList = GetTilesIn4Directions(c);
            foreach(GridTile t in tempList)
            {
                if(t is ConveyorTile)
                {
                    if (ConnectToConveyorPrevious(c, t as ConveyorTile) != null)
                        return t;
                }
                else if(!(t is EmptyTile) && !(t is DropOffTile))
                {
                    ConnectTiles(t, c);
                    return t;
                }
            }
            return null;
        }


        public GridTile AutoConnectConveyorToNext(GridTile c)
        {
            List<GridTile> tempList = GetTilesIn4Directions(c);
            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if (ConnectToConveyorBeginning(c, t as ConveyorTile) != null)
                        return t;
                }
                else if (!(t is EmptyTile))
                {
                    ConnectTiles(c, t);
                    return t;
                }
            }
            return null;
        }
        public List<GridTile> AutoConnectMPAToPrevs(GridTile c)
        {
            foreach (GridTile t in gridTiles)
            {
                if (t.nodeInGrid == c.nodeInGrid)
                {
                    
                }
            }
            return null;
        }

        public delegate List<GridTile> GetNeighboursHandler(GridTile c);

        public List<GridTile> GetTopNeighbour(GridTile c)
        {
            GridTile temp = FindTileInRowColumnCoordinates(c.Column, c.Row - 1);
            List<GridTile> tempList = new List<GridTile>();
            tempList.Add(temp);
            return tempList;
        }


        public List<GridTile> GetBottomNeighbour(GridTile c)
        {
            GridTile temp = FindTileInRowColumnCoordinates(c.Column, c.Row + 1);
            List<GridTile> tempList = new List<GridTile>();
            tempList.Add(temp);
            return tempList;
        }

        public GridTile AutoConnectToPrev(GridTile c, GetNeighboursHandler del)
        {
            List<GridTile> tempList = del(c);
            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if (ConnectToConveyorPrevious(c, t as ConveyorTile) != null)
                    {
                        return t;
                    }
                }
                else if (!(t is EmptyTile) && !(t is DropOffTile) && !(c is MPATile))
                {
                    ConnectTiles(t, c);
                    return t;
                }
            }
            return null;
        }

        public GridTile AutoConnectToNext(GridTile c, GetNeighboursHandler del)
        {
            List<GridTile> tempList = del(c);
            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if (ConnectToConveyorBeginning(c, t as ConveyorTile) != null)
                    {
                        return t;
                    }
                }
                else if (!(t is EmptyTile) && !(t is CheckInTile) && !(c is MPATile))
                {
                    ConnectTiles(c, t);
                    return t;
                }
            }
            return null;
        }

        public GridTile AutcoConnectMPA(GridTile c)
        {
            List<GridTile> tempList = GetTilesIn4Directions(c);
            foreach (GridTile t in tempList)
            {
                if (t is ConveyorTile)
                {
                    if (ConnectToConveyorPrevious(c, t as ConveyorTile) != null)
                    {
                        return t;
                    }
                    if(ConnectToConveyorBeginning(c, t as ConveyorTile) != null)
                    {
                        return t;
                    }
                }
                else if(!(t is MPATile))
                {
                    ConnectTiles(t, c);
                    return t;
                }
            }
            return null;
        }

        public List<GridTile> GetMPA(GridTile c)
        {
            List<GridTile> tempList = new List<GridTile>();
            foreach(GridTile t in gridTiles)
            {
                if(t.nodeInGrid == c.nodeInGrid)
                {
                    tempList.Add(t);
                }
            }
            return tempList;
        }
    }
}
