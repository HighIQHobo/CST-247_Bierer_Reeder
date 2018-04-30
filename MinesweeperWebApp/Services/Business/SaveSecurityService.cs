//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesweeperWebApp.Models;
using MinesweeperWebApp.Services.Data;

namespace MinesweeperWebApp.Services.Business
{
    public class SaveSecurityService
    {
        //Create a new save
        public bool Create(int UserID, string data)
        {
            SaveSecurityDAO service = new SaveSecurityDAO();
            return service.Create(UserID, data);
        }
        //Delete an old save
        public bool Delete(object UserID)
        {
            SaveSecurityDAO service = new SaveSecurityDAO();
            return service.Delete(UserID);
        }
        //get save from ID
        public string GetById(int UserID)
        {
            SaveSecurityDAO service = new SaveSecurityDAO();
            return service.GetById(UserID);
        }
    }
}