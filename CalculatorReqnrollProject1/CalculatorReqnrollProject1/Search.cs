using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorReqnrollProject1
{
    public class Search
    {
        public String DisplayProduct(Product product)
        {
            foreach(var p in product.GetProducts())
            {
                if(p.Name==product.Name)
                {
                    return p.Name;
                }
            }

            return null;
        }
    }
}
