using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusC2 : IBonus
    {
        private float A;
        private float x;
        private float y;
        public float cost1hour { get; set; }
        public BonusC2(float cost1hour, float x, float y, float A)
        {
            this.cost1hour = cost1hour;
            this.A = A;
            this.x = x;
            this.y = y;
        }
        public float calc(float number_hours)
        {
            return (number_hours + A) * cost1hour * x + y;
        }
    }
}
