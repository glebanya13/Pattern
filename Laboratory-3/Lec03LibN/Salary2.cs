using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class Salary2 : IFactory
    {
        private readonly float A;
        public Salary2(float A)
        {
            this.A = A;
        }
        public IBonus getA(float cost1hour)
        {
            return new BonusA2(cost1hour, A);
        }
        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB2(cost1hour, x, A);
        }
        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC2(cost1hour, x, y, A);
        }
    }
}
