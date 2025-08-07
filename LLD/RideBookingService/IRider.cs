using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public interface IRider
    {
        public int Id { get; }
        int requestARide(Ride ride);

        void cancelARide(Ride ride);

        void endARide(Ride ride);

        public int getId();
    }
}