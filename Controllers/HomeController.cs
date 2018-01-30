using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Created by: William Bierer & Stuart Reeder
//The Home controller, views in this controller pertain to the homepage of the application
namespace MinesweeperWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Home");
        }
    }
}