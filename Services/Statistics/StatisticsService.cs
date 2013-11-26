using Domain.Core.Specification;
using Domain.Expences;
using Domain.Statistics;
using Services.Cache;
using Services.Statistics.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statsRepostiory;
        private readonly ICache _cache;
        private readonly ICacheKeyBuilderFactory _keyFactory;

        public StatisticsService(
            IStatisticsRepository statsRepostiory,
            ICache cache,
            ICacheKeyBuilderFactory keyFactory)
        {
            _statsRepostiory = statsRepostiory;
            _cache = cache;
            _keyFactory = keyFactory;
        }

        public StatisticsDTO GetStatistics(int userId, StatisticsRequestDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            var key = _keyFactory
                .CreateKey()
                .Add("statistics")
                .AddTag("expence", "create", userId)
                .AddTag("expence", "update", userId)
                .AddTag("expence", "delete", userId)
                .Add("from").Add(dto.From.ToShortDateString())
                .Add("to").Add(dto.To.ToShortDateString())
                .GetKey();

            var resultDTO = _cache.Get<StatisticsDTO>(key);
            if (resultDTO == null)
            {
                var spec = new AndSpecification<Expence>(
                    ExpenceSpecifications.ByUserId(userId),
                    ExpenceSpecifications.DateFilter(dto.From, dto.To));

                //TODO: make async calls
                var summary = _statsRepostiory
                    .GetSummary(spec);

                var topCategories = _statsRepostiory
                    .GetCategoriesRating(spec)
                    .Take(5);

                resultDTO =
                    new StatisticsDTO
                    {
                        Summary =
                            new SummaryStatisticsDTO
                            {
                                Total = summary.Total
                            },
                        TopCategories =
                            topCategories.Select(c =>
                                new CategorySummaryDTO
                                {
                                    Name = c.CategoryName,
                                    Total = c.Total
                                })
                    };

                _cache.Set(
                    key,
                    resultDTO,
                    new System.Runtime.Caching.CacheItemPolicy
                    {
                        SlidingExpiration = TimeSpan.FromDays(1)
                    });
            }

            return resultDTO;
        }

    }
}
