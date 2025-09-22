using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLib
{
    public class StudentNotFoundException : ApplicationException
    {
        public StudentNotFoundException(string errMsg)
            :base(errMsg)
        {
            
        }
    }
}
