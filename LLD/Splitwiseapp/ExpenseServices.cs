using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class ExpenseServices
    {
        private BalanceManager balanceManager;
        public ExpenseServices(BalanceManager balanceManager)
        {
            this.balanceManager = balanceManager;
        }

        //add expenses
        public void addExpenses(Expense expense)
        {
            
        }

        //Show balance of user
           public void showBalance(User user){


   }
        // Show allBalance
        public void showAllBalances()
        {

        }
        public void settelUp(User from, User to) { }
        

        public BalanceManager getBalanceManager()
        {
            return balanceManager;
        }
   
        public void setBalance(BalanceManager balanceManager)
        {
            this.balanceManager = balanceManager ; 
        }

    }
    
}