using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusB : IBonus
    {
        private float x { get; set; }
        public float cost1hour { get; set; }
        public BonusB(float cost1hour, float x)
        {
            this.x = x;
            this.cost1hour = cost1hour;
        }
        public float calc(float number_hours)
        {
            return cost1hour * number_hours * x;
        }
    }
}
