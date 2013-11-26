using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Code
{
    public static class TimePeriodHelper
    {
        public static TimePeriod ToTimePeriod(this string periodStr)
        {
            DateTime aStartDate, aEndDate = DateTime.Now;
            switch (periodStr.Trim().ToLower())
            {
                case "week":
                    aStartDate = aEndDate.AddDays(-((aEndDate.DayOfWeek - DayOfWeek.Monday + 7) % 7)).Date;
                    break;

                case "month":
                    aStartDate = new DateTime(aEndDate.Year, aEndDate.Month, 1);
                    break;

                case "lmonth":
                    aStartDate = new DateTime(
                        aEndDate.Month == 1 ? aEndDate.Year - 1 : aEndDate.Year,
                        (aEndDate.Month - 2) % 12 + 1,
                        1);
                    aEndDate = new DateTime(
                        aStartDate.Year,
                        aStartDate.Month,
                        DateTime.DaysInMonth(aStartDate.Year, aStartDate.Month));
                    break;

                case "quarter":
                    aStartDate = new DateTime(
                        aEndDate.Year,
                        ((aEndDate.Month - 1) / 3) * 3 + 1,
                        1);
                    break;

                case "year":
                    aStartDate = new DateTime(
                        aEndDate.Year,
                        1,
                        1);
                    break;

                case "all":
                    aStartDate = DateTime.MinValue;
                    break;

                default:
                    return null;
            }

            return 
                new TimePeriod
                {
                    From = aStartDate,
                    To = aEndDate
                };
        }
    }
}