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
    
        public RideBookingService(RideManager rideManager)
        {
            _rideManager = rideManager;
        }
        public Driver AssignDriverToRide(Ride ride)
        {
            Driver? d = _rideManager.drivers.FirstOrDefault(d => d.IsAvailable == true && d.CurrentLocation.Latitude == ride.PickupLocation!.Latitude && d.CurrentLocation.Longitude == ride.PickupLocation.Longitude);
            if (d == null)
            {
                double actualDistance = ride.PickupLocation!.Latitude + ride.PickupLocation!.Longitude;
                double minimumDistance = double.MaxValue; ;
                double compare = 0;
                double result = 0;

                foreach (var i in _rideManager.drivers)
                {
                    // if (!i.IsAvailable) break;  
                    compare = Math.Abs(actualDistance - (i.CurrentLocation.Latitude + i.CurrentLocation.Longitude));
                    if (compare < minimumDistance)
                    {
                        minimumDistance = compare;
                        result = i.CurrentLocation.Latitude + i.CurrentLocation.Longitude;
                    }

                }
                d = _rideManager.drivers.FirstOrDefault(i => i.CurrentLocation.Latitude + i.CurrentLocation.Longitude == result);
                d!.CurrentLocation = ride.PickupLocation; // Update driver's current location to pickup location 
            }
            return d!;
        }

        public int bookARide(Ride ride)
        {

            Driver d = AssignDriverToRide(ride);
            if (d != null)
            {
                ride.DriverId = d.Id;
                d.IsAvailable = false; // Mark driver as unavailable 
                d.UpdateLocation(ride.DropoffLocation!); // Update driver's current location to dropoff
                Console.WriteLine($"Ride booked with Driver ID: {d.Id} from {ride.PickupLocation} to {ride.DropoffLocation}");
            }
            else
            {
                Console.WriteLine("No available drivers found for the requested pickup location.");
                return -1;
            }
            ++idcount;
            // Ride ride = new Ride(idcount, RiderId, DriverId, PickupLocation, DropoffLocation);
            return ride.RideId = idcount; 
        }

        public void cancelARide(int RideId)
        {
            // Logic to cancel a ride
            Console.WriteLine($"Ride with ID: {RideId} has been cancelled.");
        }

        // public void RideDetails(int RideId)
        // {
        //     // Ride ride; 
            
        // }

        public void endRide(Ride ride)
        {
            Driver? d = _rideManager.drivers.FirstOrDefault(d => d.Id == ride.DriverId);
            if (d != null)
            {
                // d.IsAvailable = true;
                Console.WriteLine($"Ride with ID: {ride.RideId} has ended. Driver: {d.Id} is now available.");
            }

        }
        

       


    }
}