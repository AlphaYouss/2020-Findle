using System.Data;
using ASP.NETFindle.Interface;

namespace ASP.NETFindle.Container
{
    public class HistoryContainer
    {
        IHistoryDAL historyDAL;

        public HistoryContainer(IHistoryDAL historyDAL)
        {
            this.historyDAL = historyDAL;
        }

        public DataTable GetHistories(int userID)
        {           
            return historyDAL.GetHistories(userID);
        }
    }
}