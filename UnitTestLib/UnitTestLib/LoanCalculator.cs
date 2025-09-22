using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLib
{
    public class LoanCalculator
    {
        public double CalculateLoan(double income)
        {
            var limit=CalculateLimit(income); //private method
            return limit;
        }

        //Private method (hard to test directly)
        private double CalculateLimit(double income)
        {
            return income / 2;
        }
    }
}
