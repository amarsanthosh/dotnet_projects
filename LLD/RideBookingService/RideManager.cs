using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class RideManager
    {
        public static List<Driver> drivers = new List<Driver>(); 

        public void AddDriver(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver cannot be null");
            }

            if (drivers.Any(d => d.Id == driver.Id))
            {
                throw new InvalidOperationException("Driver with the same ID already exists.");
            }
 
            drivers.Add(driver);
        }
    }
}