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
        public Driver AssignDriverToRide(Location pickupLocation)
        {
            Driver? d = RideManager.drivers.FirstOrDefault(d => d.CurrentLocation.Latitude==pickupLocation.Latitude && d.CurrentLocation.Longitude==pickupLocation.Longitude); ;

            return d!;
        }
        public int bookARide(int RiderId, Location PickupLocation, Location dropoffLocation)
        {
            // Logic to book a ride
            this.RiderId = RiderId;
            this.PickupLocation = PickupLocation;
            this.DropoffLocation = dropoffLocation!;
            // Console.WriteLine($"Ride booked for Rider ID: {RiderId} from {PickupLocation} to {DropoffLocation}");

            Driver d = AssignDriverToRide(PickupLocation!);
            // DriverId = d.Id; // Assigning driver ID to the ride
            if (d != null)
            {
                this.DriverId = d.Id;
                d.IsAvailable = false; // Mark driver as unavailable
                d.UpdateLocation(dropoffLocation!); // Update driver's current location to dropoff
                Console.WriteLine($"Ride booked with Driver ID: {d.Id} from {PickupLocation} to {dropoffLocation}");
            }
            else
            {
                Console.WriteLine("No available drivers found for the requested pickup location.");
            }
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
            Console.WriteLine($"Ride ID: {RideId}, Driver ID: {DriverId} , Rider ID: {RiderId}, Pickup: {PickupLocation}, Dropoff: {DropoffLocation}");
        }

        public void endRide(int RideId)
        {
            Driver? d = RideManager.drivers.FirstOrDefault(d => d.Id == DriverId);
            if (d != null)
            {
                d.IsAvailable = true;
                Console.WriteLine($"Ride with ID: {RideId} has ended. Driver: {d.Id} is now available.");
            }

        }
        
    }
}