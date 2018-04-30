//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work

//service that uses the WinAPIDAO

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
        //get a win by the id
        public WinModel getWinById(int Id)
        {
            //call the DAO service
            WinApiDAO service = new WinApiDAO();
            //return the win
            return service.getWinById(Id);
        }
        //get an arraylist of all wins
        public ArrayList getWins()
        {
            //call the DAO service
            WinApiDAO service = new WinApiDAO();
            //return the list of wins
            return service.getWins();
        }
    }
}