using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Statistics
{
    public class Summary
    {
        public double Total 
        { 
            get; 
            private set; 
        }

        public Summary(double total)
        {
            this.Total = total;
        }
    }
}
