using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class BalanceManager
    {
        // Map of map<string, map<string>> currentuser vs map of user and amount
        //    Map< String, Map<String, Double>> balance;
        private Dictionary<string, Dictionary<string, double>> balances;// = new Dictionary<string, Dictionary<string, double>>();
        public BalanceManager(Dictionary<string, Dictionary<string, double>> balances)
        {
            this.balances = balances;
        }
           public void updateBalance(User from, User to, double amount){



   }
   public Dictionary<String, Double> getBalanceForUser(User user){
       return null;
   }
      public Dictionary<String, Dictionary<String, Double>> getBalance() {
       return balances;
   }


   public void setBalance(Dictionary<String, Dictionary<String, Double>> balance) {
       this.balances = balance;
   }



        public void printAllBalance() { }
    }
}