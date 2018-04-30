using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweeperWebApp.Models
{
    public class CellModel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsLive { get; set; }
        public int LiveNeighbors { set; get; }
        public bool Visited { set; get; }
        public bool HasFlag { set; get; }

        public CellModel(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
            IsLive = false;
            LiveNeighbors = 0;
            Visited = false;
            HasFlag = false;
        }
    }
}