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
        static CellModel[,] TheGrid = g.Generate();
        // GET: Game
        public ActionResult Index()
        {
            return View("Game", TheGrid);
        }

        public ActionResult OnButtonClick()
        {
            return View("Game", TheGrid);
        }
    }
}