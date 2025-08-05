using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class Expense
    {
        private String id;
        private double amount;
        private User paidBy;
        private List<Split> splits;
        private ISplitStrategy splitStrategy;
        public Expense(String id, double amount, User paidBy, List<Split> splits, ISplitStrategy splitStrategy)
        {
            this.id = id;
            this.amount = amount;
            this.paidBy = paidBy;
            this.splits = splits;
            this.splitStrategy = splitStrategy;
        }
        public String getId()
        {
            return id;
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public double getAmount()
        {
            return amount;
        }
        public void setAmount(double amount)
        {
            this.amount = amount;
        }
        public User getPaidBy()
        {
            return paidBy;
        }
        public void setPaidBy(User paidBy)
        {
            this.paidBy = paidBy;
        }
        public List<Split> getSplits()
        {
            return splits;
        }
        public void setSplits(List<Split> splits)
        {
            this.splits = splits;
        }
        public ISplitStrategy getSplitStrategy()
        {
            return splitStrategy;
        }
        public void setSplitStrategy(ISplitStrategy splitStrategy)
        {
            this.splitStrategy = splitStrategy;
        }
        }
    }
    

