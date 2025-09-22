using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLib
{
    public class LoanEligibilityService
    {
        
        public bool IsEligible(int age,decimal income)
        {
            if(age<21 || age>60)
            {
                return false;
            }

            if(income<=30000)
            {
                return false;
            }

            return true;
        }
    }
}
