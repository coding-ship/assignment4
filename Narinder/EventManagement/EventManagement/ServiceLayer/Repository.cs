using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.ServiceLayer
{
    public class Repository:IRepository
    {
        private EventDbContext db = new EventDbContext();

        public VenueDetails Details(string id)
        {
            VenueDetails venue = db.VenueDetail.ToList().FirstOrDefault(x => x.Event_Place == id);
            return venue;
        }
    }
}
