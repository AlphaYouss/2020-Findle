using System;
using System.Data.SqlClient;

namespace WPFFINDLE_BAS
{
    class SearchHistory
    {
        private Databasehandler databasehandler { get; set; } = new Databasehandler();
        private SqlCommand command { get; set; } = new SqlCommand();
        public DateTime time { get; private set; } 
        public int searchedUserID { get; private set; } 

        public void SetSearchHistory(int searchedUserID, DateTime time)
        {
            this.searchedUserID = searchedUserID;
            this.time = time;
        }

        public void SetSearchHistory(int id, int searchedUserID)
        {
            command = new SqlCommand("INSERT INTO [SearchHistory] VALUES(@User_ID, @SearchedUser_ID, @Search_At)", databasehandler.GetCon());
            command.Parameters.AddWithValue("User_ID", id);
            command.Parameters.AddWithValue("SearchedUser_ID", searchedUserID);
            command.Parameters.AddWithValue("Search_At", DateTime.Now);

            databasehandler.OpenConnectionToDB();
            command.ExecuteReader();

            databasehandler.CloseConnectionToDB();
            command = new SqlCommand();

            SetSearchHistory(searchedUserID, DateTime.Now);
        }
    }
}
