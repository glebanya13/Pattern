﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class Salary3 : IFactory
    {
        private float A { get; set; }
        private float B { get; set; }
        public Salary3(float A, float B)
        {

            this.A = A;
            this.B = B;
        }
        public IBonus getA(float cost1hour)
        {
            return new BonusA3(cost1hour, A, B);
        }
        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB3(cost1hour, x, A, B);
        }
        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC3(cost1hour, x, y, A, B);
        }
    }
}
