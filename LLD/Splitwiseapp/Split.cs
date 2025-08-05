using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class Split
    {
        private User user;

        private decimal Amount;



        public Split(User user, decimal amount)
        {
            this.user = user;
            Amount = amount;
        }


        public User GetUser()
        {
            return user;
        }
        public void setUser(User user)
        {
            this.user = user;
        }

        public decimal GetAmount()
        {
            return Amount;
        }
        public void setAmount(decimal amount)
        {
            Amount = amount;
        }
   

    }
}