using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Statistics.DTO
{
    public class StatisticsDTO
    {
        public SummaryStatisticsDTO Summary { get; set; }
        public IEnumerable<CategorySummaryDTO> TopCategories { get; set; }
    }
}
