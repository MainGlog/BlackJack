using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToStringDemo
{
    public class Rock
    {
        private String rockType;
        private String shape;
        private double weight;

        public Rock(String rockType, String shape, double weight)
        {
            this.rockType = rockType;
            this.shape = shape;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{rockType} is a(n) {shape} that weighs {weight}g";
        }
    }
}
