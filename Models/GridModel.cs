using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweeperWebApp.Models
{
    public class GridModel
    {
        public CellModel[,] TheGrid;
        public int Length { get; set; }
        public static Random rnd = new Random();
        public int LiveCells { get; set; }

        public GridModel(int Length)
        {
            this.Length = Length;
            TheGrid = new CellModel[Length, Length];
        }

        public void setMine()
        {
            foreach(CellModel c in TheGrid)
            {
                int activate = rnd.Next(1, 100);
                if(activate <=10)
                {
                    c.IsLive = true;
                    LiveCells++;
                }
            }
        }

        public void CountNeighbors(CellModel c)
        {
            int col = c.Col;
            int row = c.Row;
            if (IsValid(row - 1, col - 1) && TheGrid[row - 1, col - 1].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row - 1, col + 0) && TheGrid[row - 1, col + 0].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row - 1, col + 1) && TheGrid[row - 1, col + 1].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row + 0, col - 1) && TheGrid[row + 0, col - 1].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row + 0, col + 1) && TheGrid[row + 0, col + 1].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row + 1, col - 1) && TheGrid[row + 1, col - 1].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row + 1, col + 0) && TheGrid[row + 1, col + 0].IsLive)
                c.LiveNeighbors++;
            if (IsValid(row + 1, col + 1) && TheGrid[row + 1, col + 1].IsLive)
                c.LiveNeighbors++;
        }

        private bool IsValid(int x, int y)
        {
            if (x >= 0 && x < Length && y >= 0 && y <Length)
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