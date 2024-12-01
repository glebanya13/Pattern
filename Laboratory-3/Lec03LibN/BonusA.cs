using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusA : IBonus
    {
        public float cost1hour { get; set; }
        public BonusA(float cost1hour)
        {
            this.cost1hour = cost1hour;
        }
        public float calc(float number_hours)
        {
            return cost1hour * number_hours;
        }
    }
}
