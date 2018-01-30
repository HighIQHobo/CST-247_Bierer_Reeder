using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinesweeperWebApp.Models;
using MinesweeperWebApp.Services.Business;

//Created by: William Bierer & Stuart Reeder
//Controls the views that pertain to registering a User
namespace MinesweeperWebApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        //Register a user and return the action result 
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            UserSecurityService service = new UserSecurityService();
            if (service.Create(user))
                return View("RegistrationSuccessful");
            else
                return View("RegistrationFailed");
        }
    }
}