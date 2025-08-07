using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService    
{
    public interface IRideBookingService
    {
        int bookARide(Ride ride);// { get;  }

        void endRide(Ride ride);
        void cancelARide(Ride ride); 
    }
}