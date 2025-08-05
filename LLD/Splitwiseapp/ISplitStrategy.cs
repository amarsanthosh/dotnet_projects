using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public interface ISplitStrategy
    {
           List<Split> calculateSplit(double amount, List<Split> splits);
    }
}