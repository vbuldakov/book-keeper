using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Statistics.DTO
{
    public class StatisticsRequestDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
