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

//Created by: William Bierer & Stuart Reeder
//Service used for everything involving users. uses the UserSecurityDAO object to communicate with DB
namespace MinesweeperWebApp.Services.Business
{
    public class UserSecurityService
    {

        //Used for logging in
        public bool Authenticate(UserModel user)
        {
            UserSecurityDAO service = new UserSecurityDAO();
            return service.FindByUser(user);
        }

        //Used for registering
        public bool Create(UserModel user)
        {
            UserSecurityDAO service = new UserSecurityDAO();
            return service.Create(user);
        }
        //Used to get the UserID based on the Username (needed for adding userID to the session)
        public int GetIdFromName(string user)
        {
            UserSecurityDAO service = new UserSecurityDAO();
            return service.GetIdFromName(user);
        }
    }
}