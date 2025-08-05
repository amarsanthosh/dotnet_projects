    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class RideBookingService
    {
        public static int idcount = 0;
        private readonly RideManager _rideManager;
        private readonly Location PickupLocation;
        private readonly Location DropoffLocation;

        private int RiderId; 
        private int DriverId;


        public RideBookingService(RideManager rideManager, int riderId, Location PickupLocation, Location DropoffLocation)
        {
            _rideManager = rideManager;
            this.PickupLocation = PickupLocation;
            this.DropoffLocation = DropoffLocation;
            RiderId = riderId; 
        }
        public Driver AssignDriverToRide()
        {
            Driver? d = _rideManager.drivers.FirstOrDefault(d => d.CurrentLocation.Latitude == PickupLocation!.Latitude && d.CurrentLocation.Longitude == PickupLocation.Longitude);
            if (d == null)
            {
                double actualDistance = PickupLocation!.Latitude + PickupLocation!.Longitude;
                double minimumDistance = double.MaxValue; ;
                double compare = 0;
                double result = 0;

                foreach (var i in _rideManager.drivers)
                {
                    compare = Math.Abs(actualDistance - (i.CurrentLocation.Latitude + i.CurrentLocation.Longitude));
                    if (compare < minimumDistance)
                    {
                        minimumDistance = compare;
                        result = i.CurrentLocation.Latitude + i.CurrentLocation.Longitude;
                    }

                }
                d = _rideManager.drivers.FirstOrDefault(i => i.CurrentLocation.Latitude + i.CurrentLocation.Longitude == result);
                d!.CurrentLocation = PickupLocation; // Update driver's current location to pickup location 
            }
            return d!;
        }

        public int bookARide()
        {

            Driver d = AssignDriverToRide();
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
            ++idcount;
            Ride ride = new Ride(idcount, RiderId, DriverId, PickupLocation, DropoffLocation);
            return idcount; 
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
            Driver? d = _rideManager.drivers.FirstOrDefault(d => d.Id == DriverId);
            if (d != null)
            {
                d.IsAvailable = true;
                Console.WriteLine($"Ride with ID: {RideId} has ended. Driver: {d.Id} is now available.");
            }

        }
        

       


    }
}