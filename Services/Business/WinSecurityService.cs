using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesweeperWebApp.Models;
using MinesweeperWebApp.Services.Data;

namespace MinesweeperWebApp.Services.Business
{
    public class WinSecurityService
    {
        //Add new gae data to the database
        public bool Create(int UserID, int Clicks)
        {
            WinSecurityDAO service = new WinSecurityDAO();
            return service.create(UserID, Clicks);
        }
    }
}