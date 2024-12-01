using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusA2 : IBonus
    {
        public float cost1hour { get; set; }

        private float A { get; set; }

        public BonusA2(float cost1hour, float A)
        {
            this.cost1hour = cost1hour;
            this.A = A;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * cost1hour;
        }
    }
}
