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

        public int RideId { get; set; }
        public int DriverId { get; set; }
        public int RiderId { get; set; }
        public Location? PickupLocation { get; set; }
        public Location? DropoffLocation { get; set; }

        public Ride( int riderId, Location pickupLocation, Location dropoffLocation)
        {
            RiderId = riderId;
            if (pickupLocation == null) throw new NullReferenceException();
            this.PickupLocation = pickupLocation;
            if (dropoffLocation == null) throw new NullReferenceException();
            this.DropoffLocation = dropoffLocation;
        }
        public void RideDetails()
        {
            // Ride ride; 
            Console.WriteLine($"Ride ID: {RideId}, Driver ID: {DriverId} , Rider ID: {RiderId}, Pickup: {PickupLocation}, Dropoff: {DropoffLocation}");
        }               
    }
}