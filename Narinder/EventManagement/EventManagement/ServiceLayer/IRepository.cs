using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.ServiceLayer
{
    public interface IRepository
    {
        public VenueDetails Details(string id);
    }
}
