using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public class Utils
    {
        public int Square(int i)
        {
            checked
            {
                return i * i;
            }
        }
    }
}
