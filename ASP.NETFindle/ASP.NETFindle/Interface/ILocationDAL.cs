using System.Data;
using ASP.NETFindle.Models;

namespace ASP.NETFindle.Interface
{
    public interface ILocationDAL
    {
        DataTable GetFloor(int id);
        Location GetLocation(int locationID);
        void LocationSet(int userID, int locationID);
        int GetFloorByLocation(int locationID);
    }
}
