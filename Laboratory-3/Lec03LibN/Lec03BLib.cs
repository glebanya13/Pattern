using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class Lec03BLib
    {
        static public IFactory getL1()
        {
            return new Salary1();
        }

        static public IFactory getL2(float a)
        {
            return new Salary2(a);
        }
        static public IFactory getL3(float a, float b)
        {
            return new Salary3(a, b);
        }
    }
}
