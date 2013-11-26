using Services.Statistics;
using Services.Statistics.DTO;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Code;

namespace Web.Controllers.API
{
    [Authorize]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService _statsService;
        private readonly IUsersService _userService;

        public StatisticsController(IUsersService userService, IStatisticsService statsService)
        {
            _statsService = statsService;
            _userService = userService;
        }

        // GET api/statistics
        public StatisticsDTO Get(string period = "week")
        {
            var periodVal = period.ToTimePeriod();
            if (periodVal == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unknown period type."));
            }

            return _statsService.GetStatistics(
                _userService.GetCurrentUserId(),
                new StatisticsRequestDTO
                {
                    From = periodVal.From,
                    To = periodVal.To
                });
        }
    }
}
