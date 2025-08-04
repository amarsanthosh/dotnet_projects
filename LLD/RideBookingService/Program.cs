// See https://aka.ms/new-console-template for more information
using RideBookingService;
// Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        // Drivers added to Driver List 
        Location loc = new Location(37.7749, -122.4194); // San Francisco coordinates
        Driver driver = new Driver(1, "John Doe", loc);
        RideManager rideManager = new RideManager();
        rideManager.AddDriver(driver);
        Location loc1 = new Location(34.0522, -118.2437); // Los Angeles coordinates
        Driver driver1 = new Driver(2, "Jane Smith", loc1);
        rideManager.AddDriver(driver1);

        foreach (var drv in RideManager.drivers)
        {
            Console.WriteLine($"Driver ID: {drv.Id}, Name: {drv.Name}, Location: ({drv.CurrentLocation.Latitude}, {drv.CurrentLocation.Longitude}), Available: {drv.IsAvailable}");
        }

        // Booking a ride
        Rider rider = new Rider(1, "Alice");
        Location pickupLocation = new Location(37.7749, -122.4194); // San Francisco coordinates
        Location dropoffLocation = new Location(34.0522, -118.2437); // Los Angeles coordinates



        Ride ride = new Ride();
        int  rideId = ride.bookARide(rider.getId(), pickupLocation, dropoffLocation);
        ride.RideDetails(rideId); // Assuming ride ID is 1  
        ride.endRide(rideId); // Ending the ride
        Console.WriteLine("Ride Completed Successfully!");
    }
}