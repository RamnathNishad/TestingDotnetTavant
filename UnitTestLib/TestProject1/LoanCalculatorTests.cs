using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnitTestLib;

namespace TestProject1
{
    public class LoanCalculatorTests
    {
        [Fact]
        public void Test_PrivateMethod_CalculateLimit()
        {
            //use reflection to invoke private method for testing

            var loanCalculator = new LoanCalculator();
            var method = typeof(LoanCalculator).GetMethod("CalculateLimit", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = method.Invoke(loanCalculator, new object[] { 1000.0});

            Assert.Equal((double)500, result);
        }
    }
}
