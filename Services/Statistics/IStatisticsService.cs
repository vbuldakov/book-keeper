using Services.Statistics.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Statistics
{
    public interface IStatisticsService
    {
        StatisticsDTO GetStatistics(int userId, StatisticsRequestDTO dto);
    }
}
