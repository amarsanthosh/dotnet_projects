using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class Rider
    {
        int id;
        string name;

        public Rider(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name; 
        }
    }
}