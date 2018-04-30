//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MinesweeperWebApp.Models;

namespace MinesweeperWebApp.Services.Data
{
    public class UserSecurityDAO
    {
        //Setup Connectioni String
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Will\\Dropbox\\School\\CST-247\\Workspace\\MinesweeperWebApp\\MinesweeperWebApp\\App_Data\\Minesweeper.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public bool FindByUser(UserModel user)
        {
            bool result = false;

            try
            {
                //Setup SELCT Query with params
                string query = "SELECT * FROM dbo.MS_User WHERE UserUsername=@Username AND UserPassword=@Password";

                //create connection command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    //Set Query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                    //Open the connection
                    cn.Open();

                    //Using a DataREader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        result = true;
                    else
                        result = false;

                    // close the connection
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return result;
        }

        public bool Create(UserModel user)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.MS_User (UserFirstName, UserLastName, UserSex, UserBirth, UserState, UserEmail, UserUsername, UserPassword) VALUES (@FirstName, @LastName, @Sex, @Birth, @State, @Email, @Username, @Password)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = user.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = user.LastName;
                    cmd.Parameters.Add("@Sex", SqlDbType.VarChar, 50).Value = user.Sex;
                    cmd.Parameters.Add("@Birth", SqlDbType.VarChar, 50).Value = user.DateOfBirth;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = user.State;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = user.Email;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
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

            // Return result of create
            return result;
        }
        public int GetIdFromName(string Username)
        {
            int result = -1;

            try
            {
                string query = "SELECT UserId FROM dbo.MS_User WHERE UserUsername=@Username";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = Username;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader["UserId"]);
                    }
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
