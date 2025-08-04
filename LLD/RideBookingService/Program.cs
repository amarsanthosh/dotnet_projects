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

        foreach (var drv in rideManager.drivers)
        {
            Console.WriteLine($"Driver ID: {drv.Id}, Name: {drv.Name}, Location: ({drv.CurrentLocation.Latitude}, {drv.CurrentLocation.Longitude}), Available: {drv.IsAvailable}");
        }
        Console.WriteLine();
        // Booking a ride
        Rider rider = new Rider(1, "Alice");
        Location pickupLocation = new Location(37.7779, -122.4194); // San Francisco coordinates
        Location dropoffLocation = new Location(34.0522, -118.2437); // Los Angeles coordinates
        Console.WriteLine("Booking Request ...");
        Console.WriteLine("Rider Id: " + rider.getId() + " Rider pickup location: " + pickupLocation + " Rider dropoff location: " + dropoffLocation);
        Console.WriteLine();
        Ride ride = new Ride(rider.getId(), pickupLocation , dropoffLocation,rideManager);
        int  rideId = ride.bookARide();
        if (rideId == -1)
        {
            Console.WriteLine("Ride Discarded !!"); 
            return;
        }Console.WriteLine();
        Console.WriteLine("Ride Details !");
        ride.RideDetails(rideId); // Assuming ride ID is 1  
        ride.endRide(rideId); // Ending the ride
        Console.WriteLine("Ride Completed Successfully!");
    }
}