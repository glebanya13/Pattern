using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusB3 : IBonus
    {
        public float cost1hour { get; set; }
        private float x { get; set; }
        private float A { get; set; }
        private float B { get; set; }
        public BonusB3(float cost1hour, float x, float A, float B)
        {
            this.cost1hour = cost1hour;
            this.x = x;
            this.A = A;
            this.B = B;
        }
        public float calc(float number_hours)
        {
            return (number_hours + A) * (cost1hour + B) * x;
        }
    }
}
