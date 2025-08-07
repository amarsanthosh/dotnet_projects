using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public interface IDriver
    {
        int Id { get; }
        Location CurrentLocation { get;set;  }
        bool IsAvailable { get;set;  }

        void UpdateLocation(Location location);

        void ToggleAvailability(bool IsAvailable);        
    }
}