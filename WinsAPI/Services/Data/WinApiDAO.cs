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
        
        public WinModel getWinById(int Id)
        {
            try
            {
                string query = "SELECT * FROM dbo.MS_WINS WHERE Id = @Id";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int, 50).Value = Id;
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        WinModel TheWin = new WinModel();
                        while (reader.Read())
                        {
                            TheWin.Id = Convert.ToInt32(reader["Id"]);
                            TheWin.UserId = Convert.ToInt32(reader["UserID"]);
                            TheWin.Clicks = Convert.ToInt32(reader["Clicks"]);
                            TheWin.WinDate = Convert.ToDateTime(reader["WinDate"].ToString());

                            return TheWin;
                        }
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

        public ArrayList getWins()
        {
            try
            {
                string query = "SELECT * FROM dbo.MS_WINS";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    {
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        ArrayList WinList = new ArrayList();
                        WinModel TheWin = new WinModel();
                        while (reader.Read())
                        {
                            TheWin.Id = Convert.ToInt32(reader["Id"]);
                            TheWin.UserId = Convert.ToInt32(reader["UserID"]);
                            TheWin.Clicks = Convert.ToInt32(reader["Clicks"]);
                            TheWin.WinDate = Convert.ToDateTime(reader["WinDate"].ToString());
                            WinList.Add(TheWin);
                        }
                        return WinList;
                        cn.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return null;
        }
    }
}