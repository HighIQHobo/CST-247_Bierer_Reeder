//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MinesweeperWebApp.Services.Data
{
    public class SaveSecurityDAO
    {
        //Setup Connection String
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Will\\Dropbox\\School\\CST-247\\Workspace\\MinesweeperWebApp\\MinesweeperWebApp\\App_Data\\Minesweeper.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        //add game data
        public bool Create(int UserID, string data)
        {
            bool result = false;

            try
            {
                //create db query
                string query = "INSERT INTO dbo.MS_Savegames (UserID, GameData) VALUES (@UserID, @GameData)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = UserID;
                    cmd.Parameters.Add("@GameData", SqlDbType.VarChar).Value = data;

                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }
            }
            catch(SqlException e)
            {
                throw e;
            }

            return result;
        }
        //Delete game data from DB
        public bool Delete(object UserID)
        {
            bool result = false;

            try
            {
                //create query
                string query = "DELETE FROM dbo.MS_Savegames WHERE UserID = @UserID";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = UserID;

                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows >= 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return result;
        }

        //Get Game Data by ID. Needed for determining whos save data is whos Game data is specific to the user
        public string GetById(int UserID)
        {
            string result = null;

            try
            {
                //creete query
                string query = "SELECT * FROM dbo.MS_Savegames WHERE UserID = @UserID";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = UserID;
                    cn.Open();
                    //use reader to get gamedata
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader["GameData"].ToString();
                    }
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return result;
        }
    }
}