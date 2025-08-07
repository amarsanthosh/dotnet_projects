using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class PoolRide : Ride
    {
        public List<int> SharedRiderIds { get;  }
        public PoolRide(int riderId, Location pickupLocation, Location dropoffLocation, List<int> sharedRiderIds) : base(riderId, pickupLocation, dropoffLocation)
        {
            SharedRiderIds = sharedRiderIds ?? new List<int>();
        }

        public override string ToString()
        {
            string s = string.Join(" , ", SharedRiderIds);
            return  $" Shared Riders : {s}" ;
        }
    }
}