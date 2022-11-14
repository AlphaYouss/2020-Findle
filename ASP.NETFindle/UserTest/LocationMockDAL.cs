using System;
using System.Data;
using ASP.NETFindle.Interface;
using ASP.NETFindle.Models;

namespace UserTest
{
    class LocationMockDAL : ILocationDAL
    {
        public Location location = new Location();

        public DataTable GetFloor(int id)
        {
            throw new NotImplementedException();
        }

        public int GetFloorByLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public DataTable LocationsAllGet()
        {
            DataTable table = new DataTable();
            return table;
        }

        public void LocationSet(int userId, int locationId)
        {
            location.Id = userId;
            location.Room = "Auditorium";
            location.Building = "P8";
            location.Floor = "1e";
        }

        public void LocationUserGet()
        {
            throw new NotImplementedException();
        }
    }
}