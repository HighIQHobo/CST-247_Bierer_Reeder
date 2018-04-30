﻿//CST- 247
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
    public class WinSecurityService
    {
        //Add new gae data to the database
        public bool Create(int UserID, int Clicks, DateTime WinDate)
        {
            WinSecurityDAO service = new WinSecurityDAO();
            return service.create(UserID, Clicks, WinDate);
        }
    }
}