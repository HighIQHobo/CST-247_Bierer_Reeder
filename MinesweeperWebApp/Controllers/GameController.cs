//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work

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
        //implement the logger
        private readonly TheLogger logger;

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
        public PartialViewResult CellClick(string cell)
        {
            logger.Info("Entering GameController CellClick");

            try
            {
                //use nested for loops to generate the grid
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
                            if (g.win == true)
                            {
                                WinSecurityService service = new WinSecurityService();
                                service.Create(Convert.ToInt32(Session["UserID"]), g.Clicks, DateTime.Now);
                                g.message = "You Win!";
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Info("Exiting GameController CellClick WITH EXCEPTION");
                throw e;
            }

            logger.Info("Exiting GameController CellClick");
            return PartialView("_Gameboard", g);
        }

        //Reset the game board
        public ActionResult Restart()
        {
            logger.Info("Entering GameController Restart");
            try
            {
                //Create a new game engine
                g = new MinesweeperGame();                
            }
            catch (Exception e)
            {
                logger.Info("Exiting GameController Restart WITH EXCEPTION");
                throw e;
            }
            logger.Info("Exiting GameController Restart");
            return View("Game", g);
        }
        //Save the Game state
        public ActionResult SaveGame()
        {
            logger.Info("Entering GameController SaveGame");
            try
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
            }
            catch (Exception e)
            {
                logger.Info("Exiting GameController Restart WITH EXCEPTION");
                throw e;
            }
            logger.Info("Exiting GameController Restart");
            return View("Game", g);
        }

        //Load the game state
        public ActionResult LoadGame()
        {
            logger.Info("Entering GameController LoadGame");
            try
            {
                //get the game data using the UserID saved in the session
                SaveSecurityService service = new SaveSecurityService();
                int id = Convert.ToInt32(Session["UserID"]);
                string Data = service.GetById(id);
                g.TheGrid = JsonConvert.DeserializeObject<CellModel[,]>(Data);
                g.message = "Game Loaded!";
            }
            catch (Exception e)
            {
                logger.Info("Exiting GameController LoadGame WITH EXCEPTION");
                throw e;
            }
            logger.Info("Exiting GameController LoadGame");
            return View("Game", g);
        }
    }
}