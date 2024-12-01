using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusB2 : IBonus
    {
        private float A;
        private float x;
        public float cost1hour { get; set; }
        public BonusB2(float cost1hour, float x, float A)
        {
            this.cost1hour = cost1hour;
            this.A = A;
            this.x = x;
        }
        public float calc(float number_hours)
        {
            return cost1hour * (number_hours + A) * x;
        }
    }
}
