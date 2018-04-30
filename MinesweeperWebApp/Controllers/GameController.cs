using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinesweeperWebApp.Models;
using MinesweeperWebApp.Services.Business;
using MinesweeperWebApp.GameEngine;
using Newtonsoft.Json;

namespace MinesweeperWebApp.Controllers
{
    public class GameController : Controller
    {
        static MinesweeperGame g = new MinesweeperGame();
        // GET: Game
        public ActionResult Index()
        {
            if(Convert.ToInt32(Session["UserID"]) == 0)
            {
                return Redirect("Login");
            }
            else
            {
                return View("Game", g);
            }
        }

        public ActionResult DisplayGameData()
        {

            return View("Game", g);
        }

        //Cell click method
        [HttpPost]
        public ActionResult CellClick(string cell)
        {
            for (int row = 0; row < g.Length; row++)
            {
                for (int col = 0; col < g.Length; col++)
                {
                    if (cell.Equals(row + ", " + col))
                    {
                        //process the cell
                        g.ProcessCell(g.TheGrid[row, col]);
                        //count up the number of clicks for highscore page
                        g.Clicks++;
                        g.message = "";

                        //If User wins, push game data to the database
                        if(g.win == true)
                        {
                            WinSecurityService service = new WinSecurityService();
                            service.Create(Convert.ToInt32(Session["UserID"]), g.Clicks, DateTime.Now);
                            g.message = "You Win!";
                        }
                    }
                }
            }

            return View("Game", g);
        }

        //Reset the game board
        public ActionResult Restart()
        {
            //Create a new game engine
            g = new MinesweeperGame();
            return View("Game", g);
        }
        //Save the Game state
        public ActionResult SaveGame()
        {
            SaveSecurityService service = new SaveSecurityService();
            //serialize the game state
            string SaveData = JsonConvert.SerializeObject(g.TheGrid);
            int id = Convert.ToInt32(Session["UserID"]);
            //delete previous game state the user might have
            service.Delete(id);
            //Put game data in the database
            service.Create(id, SaveData);
            g.message = "Game Saved!";
            g.isSaveGame = true;

            return View("Game", g);
        }

        //Load the game state
        public ActionResult LoadGame()
        {
            //get the game data using the UserID saved in the session
            SaveSecurityService service = new SaveSecurityService();
            int id = Convert.ToInt32(Session["UserID"]);
            string Data = service.GetById(id);
            g.TheGrid = JsonConvert.DeserializeObject<CellModel[,]>(Data);
            g.message = "Game Loaded!";

            return View("Game", g);
        }
    }
}