using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WinsAPI.Models;
using WinsAPI.Services.Data;
using System.Collections;

namespace WinsAPI.Services.Business
{
    public class WinApiBusinessService
    {
        public WinModel getWinById(int Id)
        {
            WinApiDAO service = new WinApiDAO();
            return service.getWinById(Id);
        }
        public ArrayList getWins()
        {
            WinApiDAO service = new WinApiDAO();
            return service.getWins();
        }
    }
}