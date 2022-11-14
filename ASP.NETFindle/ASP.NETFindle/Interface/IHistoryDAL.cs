using System.Data;

namespace ASP.NETFindle.Interface
{
    public interface IHistoryDAL
    {
        DataTable GetHistories(int userID);
    }
}