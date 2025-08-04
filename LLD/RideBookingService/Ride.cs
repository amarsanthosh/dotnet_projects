using System;
using System.Collections.Generic;
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

        /*public Ride(int rideId, int driverId, int riderId, Location pickupLocation, Location dropoffLocation)
        {
            RideId = rideId;
            DriverId = driverId;
            RiderId = riderId;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            RideStartTime = DateTime.Now;
        }*/
        public int AssignDriverToRide(Location pickupLocation)
        {

            return 1; // Assume driver with ID 1 is assigned
        }
        public int bookARide(int RiderId, Location PickupLocation, Location dropoffLocation)
        {
            // Logic to book a ride
            this.RiderId = RiderId;
            this.PickupLocation = PickupLocation;
            this.DropoffLocation = dropoffLocation!;
            Console.WriteLine($"Ride booked for Rider ID: {RiderId} from {PickupLocation} to {DropoffLocation}");

            DriverId = AssignDriverToRide(PickupLocation!);
            return RideId = new Random().Next(1, 1000); // Simulating a ride ID generation           
        }

       public void cancelARide(int RideId)
        {
            // Logic to cancel a ride
            Console.WriteLine($"Ride with ID: {RideId} has been cancelled.");
        }
        
       public void RideDetails(int RideId)
        {
            // Logic to get ride details
            Console.WriteLine($"Ride ID: {RideId}, Driver ID: {DriverId}, Rider ID: {RiderId}, Pickup: {PickupLocation}, Dropoff: {DropoffLocation}");
        }
    }
}