using System.Data;
using ASP.NETFindle.Interface;
using ASP.NETFindle.Models;

namespace ASP.NETFindle.Container
{
    public class LocationContainer
    {
        ILocationDAL locationDAL;

        public LocationContainer(ILocationDAL locationDAL)
        {
            this.locationDAL = locationDAL;
        }

        public DataTable GetFloor(int id)
        {
            return locationDAL.GetFloor(id);
        }

        public Location GetLocation(int locationID)
        {
            return locationDAL.GetLocation(locationID);
        }

        public void SetCurrentLocation(int userId, int locationId)
        {
            locationDAL.LocationSet(userId, locationId);
        }
    }
}