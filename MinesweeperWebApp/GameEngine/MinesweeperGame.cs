using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinesweeperWebApp.Models;

//Created by: William Bierer & Stuart Reeder

namespace MinesweeperWebApp.GameEngine
{
    public class MinesweeperGame
    {
        private GridModel Grid { get; set; }
        public CellModel[,] TheGrid { get; set; }
        public int Length { get; set; }
        public bool win { get; set; }
        public bool lose { get; set; }
        public int safeSpaces { get; set; }
        public bool isSaveGame { get; set; }
        public int Clicks { get; set; }
        public string message { get; set; }

        public MinesweeperGame()
        {
            Generate();
            isSaveGame = false;
            TheGrid = Grid.TheGrid;
            lose = false;
            win = false;
            message = "";
            Clicks = 0;
        }

        //Generate the grid and set mines
        private void Generate()
        {

            Grid = new GridModel(10);
            Length = Grid.Length;
            for (int r = 0; r < Length; r++)
            {
                for(int c = 0; c < Length; c++)
                {
                    Grid.TheGrid[r, c] = new CellModel(r, c);
                    
                }
            }
            Grid.setMine();

            foreach(CellModel c in Grid.TheGrid)
            {
                Grid.CountNeighbors(c);
                if (!c.IsLive)
                    safeSpaces++;
            }
        }

        //Process Cell when clicked
        public void ProcessCell(CellModel c)
        {
            int row = c.Row, col = c.Col;
            //only run if cell isnt visited
            if (!c.Visited)
            {
                c.Visited = true;
                //check if cell has a bomb
                if (c.IsLive)
                {
                    lose = true;
                    RevealGrid();
                }
                //if cell neighbor count is zero, show the neighbor count and call ProcessCell recursively
                else if(c.LiveNeighbors == 0)
                {
                    if (IsValid(row - 1, col))
                        ProcessCell(Grid.TheGrid[row - 1, col]);
                    if (IsValid(row + 1, col))
                        ProcessCell(Grid.TheGrid[row + 1, col]);
                    if (IsValid(row, col - 1))
                        ProcessCell(Grid.TheGrid[row, col - 1]);
                    if (IsValid(row, col + 1))
                        ProcessCell(Grid.TheGrid[row, col + 1]);
                    if (IsValid(row - 1, col - 1))
                        ProcessCell(Grid.TheGrid[row - 1, col - 1]);
                    if (IsValid(row + 1, col + 1))
                        ProcessCell(Grid.TheGrid[row + 1, col + 1]);
                    if (IsValid(row + 1, col - 1))
                        ProcessCell(Grid.TheGrid[row + 1, col - 1]);
                    if (IsValid(row - 1, col + 1))
                        ProcessCell(Grid.TheGrid[row - 1, col + 1]);
                    safeSpaces--;
                }
                //When cell has neighbors, display the neighbor count
                else
                {
                    safeSpaces--;
                }
            }
            if (safeSpaces == 0)
            {
                win = true;
                RevealGrid();
            }
        }

        //Reveal the entire grid (used after winning and losing)
        private void RevealGrid()
        {
            foreach(CellModel c in TheGrid)
            {
                c.Visited = true;
            }
        }

        //Check if a cell is valid (used for ProcessCell)
        private bool IsValid(int x, int y)
        {
            if (x >= 0 && x < Length && y >= 0 && y < Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}