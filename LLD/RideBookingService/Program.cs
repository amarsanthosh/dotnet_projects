// See https://aka.ms/new-console-template for more information
using RideBookingService;
// Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        // Example usage of Driver and Location classes
        Location loc = new Location(37.7749, -122.4194); // San Francisco coordinates
        Driver driver = new Driver(1, "John Doe", loc);
        
        Console.WriteLine($"Driver ID: {driver.Id}, Name: {driver.Name}, Location: {driver.CurrentLocation}");
        
        // Update driver's location
        // Location newLoc = new Location(34.0522, -118.2437); // Los Angeles coordinates
        // driver.UpdateLocation(newLoc);


        Rider rider = new Rider(1, "Alice");
        Location pickupLocation = new Location(37.7749, -122.4194); // San Francisco coordinates
        Location dropoffLocation = new Location(34.0522, -118.2437); // Los Angeles coordinates
        Ride ride = new Ride();
        int  rideId = ride.bookARide(rider.getId(), pickupLocation, dropoffLocation);

        ride.RideDetails(rideId); // Assuming ride ID is 1  
        Console.WriteLine($"Updated Driver Location: {driver.CurrentLocation}");
    }
}