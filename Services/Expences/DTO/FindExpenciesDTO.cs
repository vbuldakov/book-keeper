using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class FindExpenciesDTO
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
