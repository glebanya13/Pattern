using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusC : IBonus
    {
        public float cost1hour { get; set; }
        private float x;
        private float y;
        public BonusC(float cost1hour, float x, float y)
        {
            this.cost1hour = cost1hour;
            this.x = x;
            this.y = y;
        }
        public float calc(float number_hours)
        {
            return cost1hour * number_hours * x + y;
        }
    }
}
