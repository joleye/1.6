using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class Price
    {
        private double j_value;
        public Price(string p)
        {
            if (string.IsNullOrEmpty(p))
                j_value = 0;
            else
            j_value = double.Parse(p);
        }

        public override string ToString()
        {
            return j_value.ToString();
        }
    }
}
