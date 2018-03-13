using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinesweeperWebApp.Models;
using MinesweeperWebApp.GameEngine;

namespace MinesweeperWebApp.Controllers
{
    public class GameController : Controller
    {
        static MinesweeperGame g = new MinesweeperGame();
        // GET: Game
        public ActionResult Index()
        {
            return View("Game", g);
        }

        public ActionResult DisplayGameData()
        {

            return View("Game", g);
        }


        [HttpPost]
        public PartialViewResult AjaxCellClick(string cell)
        {
            for (int row = 0; row < g.Length; row++)
            {
                for (int col = 0; col < g.Length; col++)
                {
                    if (cell.Equals(row + ", " + col))
                    {
                        g.ProcessCell(g.TheGrid[row, col]);
                    }
                }
            }
            return PartialView("_GameBoard", g);
        }

        public ActionResult Restart()
        {
            g = new MinesweeperGame();
            return View("Game", g);
        }
    }
}