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
        private readonly RideManager _ridemanager; 
        public static int idcount = 0;
        public int RideId { get; private set; }
        public int DriverId { get; private set; }
        public int RiderId { get; private set; }
        public Location? PickupLocation { get; private set; }
        public Location? DropoffLocation { get;private set; }

        public Ride(int riderId, Location pickupLocation, Location dropoffLocation, RideManager rideManager)
        {
            RiderId = riderId;
            if (pickupLocation == null) throw new NullReferenceException();
            this.PickupLocation = pickupLocation;
            if (dropoffLocation == null) throw new NullReferenceException();
            this.DropoffLocation = dropoffLocation; 
            _ridemanager = rideManager ?? throw new ArgumentNullException(nameof(rideManager), "RideManager cannot be null");
            // this.RideId = idcount; // Assigning a unique ride ID
        }
        public Driver AssignDriverToRide()
        {
            Driver? d = _ridemanager.drivers.FirstOrDefault(d => d.CurrentLocation.Latitude==PickupLocation!.Latitude && d.CurrentLocation.Longitude==PickupLocation.Longitude);
            if (d == null)
            {
                double actualDistance = PickupLocation!.Latitude + PickupLocation!.Longitude;
                double minimumDistance = double.MaxValue; ;
                double compare = 0;
                double result = 0;
                // Console.WriteLine("3");

                foreach (var i in _ridemanager.drivers)
                {
                    //Eucilidean distance calculation -> d=((x2​−x1​)2+(y2​−y1​)2​) ^(½)

                    compare = Math.Abs(actualDistance - (i.CurrentLocation.Latitude + i.CurrentLocation.Longitude));
                    if (compare < minimumDistance)
                    {
                        minimumDistance = compare;
                        result = i.CurrentLocation.Latitude + i.CurrentLocation.Longitude;
                    }

                }
                // Console.WriteLine("Hello -> : " +  result);
                // d = _ridemanager.drivers.FirstOrDefault(i => Math.Sqrt(Math.Pow(i.CurrentLocation.Latitude - PickupLocation.Latitude, 2) + Math.Pow(i.CurrentLocation.Longitude - PickupLocation.Longitude, 2)) == minimumDistance);
                d = _ridemanager.drivers.FirstOrDefault(i => i.CurrentLocation.Latitude + i.CurrentLocation.Longitude == result);
                d!.CurrentLocation = PickupLocation; // Update driver's current location to pickup location 
            }
            return d!;
        }
        public int bookARide()
        {
            // Logic to book a ride
            // Console.WriteLine($"Ride booked for Rider ID: {RiderId} from {PickupLocation} to {DropoffLocation}");

            // Console.WriteLine("1. "); 
            Driver d = AssignDriverToRide();
            // DriverId = d.Id; // Assigning driver ID to the ride
                        // Console.WriteLine("2. "); 

            if (d != null)
            {
                this.DriverId = d.Id;
                d.IsAvailable = false; // Mark driver as unavailable
                d.UpdateLocation(DropoffLocation!); // Update driver's current location to dropoff
                Console.WriteLine($"Ride booked with Driver ID: {d.Id} from {PickupLocation} to {DropoffLocation}");
            }
            else
            {
                Console.WriteLine("No available drivers found for the requested pickup location.");
                return -1;
            }
            return ++idcount;          
        }

        public void cancelARide(int RideId)
        {
            // Logic to cancel a ride
            Console.WriteLine($"Ride with ID: {RideId} has been cancelled.");
        }

        public void RideDetails(int RideId)
        {
            Console.WriteLine($"Ride ID: {RideId}, Driver ID: {DriverId} , Rider ID: {RiderId}, Pickup: {PickupLocation}, Dropoff: {DropoffLocation}");
        }

        public void endRide(int RideId)
        {
            Driver? d = _ridemanager.drivers.FirstOrDefault(d => d.Id == DriverId);
            if (d != null)
            {
                d.IsAvailable = true;
                Console.WriteLine($"Ride with ID: {RideId} has ended. Driver: {d.Id} is now available.");
            }

        }
        
    }
}