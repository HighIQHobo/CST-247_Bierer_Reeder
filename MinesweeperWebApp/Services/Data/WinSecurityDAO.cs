using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MinesweeperWebApp.Models;

namespace MinesweeperWebApp.Services.Data
{
	public class WinSecurityDAO
	{
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Will\\Dropbox\\School\\CST-247\\Workspace\\MinesweeperWebApp\\MinesweeperWebApp\\App_Data\\Minesweeper.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public bool create(int UserID, int Clicks, DateTime WinDate)
        {
            bool result = false;

            try
            {
                string query = "INSERT INTO dbo.MS_Wins (UserID, Clicks, WinDate) VALUES (@UserID, @Clicks, @WinData)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    cmd.Parameters.Add("@Clicks", SqlDbType.Int).Value = Clicks;
                    cmd.Parameters.Add("@WinData", SqlDbType.DateTime).Value = WinDate;

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
	}
}