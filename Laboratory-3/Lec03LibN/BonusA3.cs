using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusA3 : IBonus
    {
        private float A { get; set; }
        private float B { get; set; }
        public float cost1hour { get; set; }

        public BonusA3(float cost1hour, float A, float B)
        {
            this.cost1hour = cost1hour;
            this.A = A;
            this.B = B;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * (cost1hour + B);
        }
    }
}
