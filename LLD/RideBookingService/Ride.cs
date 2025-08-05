using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class Ride
    {

        public int RideId { get; private set; }
        public int DriverId { get; private set; }
        public int RiderId { get; private set; }
        public Location? PickupLocation { get; private set; }
        public Location? DropoffLocation { get; private set; }

        public Ride(int RideId, int riderId, int DriverId, Location pickupLocation, Location dropoffLocation)
        {
            RiderId = riderId;
            if (pickupLocation == null) throw new NullReferenceException();
            this.PickupLocation = pickupLocation;
            if (dropoffLocation == null) throw new NullReferenceException();
            this.DropoffLocation = dropoffLocation;
            this.DriverId = DriverId;
            this.RideId = RideId; 
        }               
    }
}