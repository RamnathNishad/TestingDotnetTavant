using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLib;

namespace TestProject1
{
    public class LoanEligibilityTests
    {
        LoanEligibilityService service = new LoanEligibilityService();

        //------------Boundary Value Testing------------
        [Theory]
        [InlineData(21,40000,true)]
        [InlineData(20,40000,false)]
        [InlineData(60,40000,true)]
        [InlineData(61,40000,false)]
        [InlineData(30,30001,true)]
        [InlineData(30,30000,false)]
        public void Test_BoundaryValues(int age,decimal income,bool expected)
        {
            var result=service.IsEligible(age, income);
            Assert.Equal(expected, result);
        }

        //----------Edge Case Testing----------------
        [Theory]
        [InlineData(0,50000,false)]     // Age=0(edge case, invalid)
        [InlineData(-5,40000,false)]    // Negative age
        [InlineData(25,0,false)]        // Zero income
        [InlineData(25,-1000,false)]    // Negative income
        //[InlineData(25,decimal.MaxValue,true)]  //Extremly high income
        public void Test_EdgeCases(int age,decimal income,bool expected)
        {
            var result=service.IsEligible(age,income);
            Assert.Equal(expected, result);
        }
    }
}
