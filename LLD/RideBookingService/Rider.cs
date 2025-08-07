using System;
    using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class Rider : IRider
    {
        public int Id { get; }
        string name;

        private readonly RideBookingService rideBookingService;
// 
        // int IRider.Id => throw new NotImplementedException();

        public Rider(int id, string name, RideBookingService rideBookingService)
        {
            this.Id = id;
            this.name = name;
            this.rideBookingService = rideBookingService;
        }

        // public int Id => throw new NotImplementedException();

        public void cancelARide(Ride ride)
        {
            rideBookingService.cancelARide(ride);
        }

        public int getId()
        {
            return this.Id;
        }

        public string getName()
        {
            return this.name; 
        }

        public int requestARide(Ride ride)
        {
            return rideBookingService.bookARide(ride);
        }

        public void endARide(Ride ride)
        {
            rideBookingService.endRide(ride);
        }
    }
}