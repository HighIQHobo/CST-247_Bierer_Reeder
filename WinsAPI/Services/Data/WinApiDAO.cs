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
using WinsAPI.Models;
using System.Collections;

namespace WinsAPI.Services.Data
{
    public class WinApiDAO
    {
        //Setup Connection String
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Will\\Dropbox\\School\\CST-247\\Workspace\\MinesweeperWebApp\\MinesweeperWebApp\\App_Data\\Minesweeper.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        
        //get a win by the ID
        public WinModel getWinById(int Id)
        {
            try
            {
                //create query
                string query = "SELECT * FROM dbo.MS_WINS WHERE Id = @Id";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    {
                        //create params
                        cmd.Parameters.Add("@Id", SqlDbType.Int, 50).Value = Id;

                        //open the connection
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        WinModel TheWin = new WinModel();

                        //read from the database and return the win
                        while (reader.Read())
                        {
                            TheWin.Id = Convert.ToInt32(reader["Id"]);
                            TheWin.UserId = Convert.ToInt32(reader["UserID"]);
                            TheWin.Clicks = Convert.ToInt32(reader["Clicks"]);
                            TheWin.WinDate = Convert.ToDateTime(reader["WinDate"].ToString());

                            return TheWin;
                        }
                        //close the connection
                        cn.Close();
                    }
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
            return null;
        }

        //get a list of all wins
        public ArrayList getWins()
        {
            try
            {
                //create query
                string query = "SELECT * FROM dbo.MS_WINS";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    {
                        //open connection and create params
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        ArrayList WinList = new ArrayList();
                        WinModel TheWin = new WinModel();

                        //read from database, add wins to arraylist and return the list.
                        while (reader.Read())
                        {
                            TheWin.Id = Convert.ToInt32(reader["Id"]);
                            TheWin.UserId = Convert.ToInt32(reader["UserID"]);
                            TheWin.Clicks = Convert.ToInt32(reader["Clicks"]);
                            TheWin.WinDate = Convert.ToDateTime(reader["WinDate"].ToString());
                            WinList.Add(TheWin);
                        }
                        cn.Close();
                        return WinList;
                        //close the connection
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}