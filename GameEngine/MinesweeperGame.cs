using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesweeperWebApp.Models;

namespace MinesweeperWebApp.GameEngine
{
    public class MinesweeperGame
    {
        private GridModel Grid { get; set; }

        public MinesweeperGame()
        {

        }

        public CellModel[,] Generate()
        {

            Grid = new GridModel(10);
            for(int r = 0; r < Grid.Length; r++)
            {
                for(int c = 0; c < Grid.Length; c++)
                {
                    Grid.TheGrid[r, c] = new CellModel(r, c);
                }
            }
            Grid.setMine();

            foreach(CellModel c in Grid.TheGrid)
            {
                Grid.CountNeighbors(c);
            }
            return Grid.TheGrid;
        }
    }
}