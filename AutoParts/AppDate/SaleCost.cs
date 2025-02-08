using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoParts.AppDate
{
    public partial class Sale
    {
        public decimal SaleCost
        {
            get
            {
                var c = Convert.ToDecimal(CountAutoPartSale) * Price;
                return Convert.ToDecimal(c);
            }
        }
    }
}
