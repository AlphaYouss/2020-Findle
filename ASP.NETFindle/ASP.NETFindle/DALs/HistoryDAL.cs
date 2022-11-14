using System;
using System.Data;
using ASP.NETFindle.Interface;
using Microsoft.Data.SqlClient;

namespace ASP.NETFindle.DataBase
{
    public class HistoryDAL: Databasehandler, IHistoryDAL
    {
        public DataTable GetHistories(int userID)
        {
            command = new SqlCommand("SELECT FirstName, LastName, Search_At FROM [SearchHistory] INNER JOIN [User] ON SearchedUser_ID = [User].ID WHERE SearchHistory.User_ID = @userID ORDER BY Search_At DESC", GetCon());
            command.Parameters.AddWithValue("userID", userID);

            DataTable table = new DataTable();

            OpenConnectionToDB();

            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnectionToDB();
            }
            return table;
        }
    }
}