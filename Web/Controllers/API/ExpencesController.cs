using Services.Exceptions;
using Services.Expences;
using Services.Expences.Contracts;
using Services.Expences.DTO;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.Code;

namespace Web.Controllers.API
{
    [Authorize]
    public class ExpencesController : ApiController
    {
        private readonly IUsersService _userService;
        private readonly IExpencesService _expencesService;

        public ExpencesController(IUsersService userService, IExpencesService expencesService)
        {
            _userService = userService;
            _expencesService = expencesService;
        }

        // GET api/expences
        public IEnumerable<ExpenceDTO> Get(int? skip, int? take, string period="week")
        {
            int aSkip = 0, aTake = 20;
            if (skip.HasValue)
            {
                aSkip = skip.Value;
            }

            if (take.HasValue)
            {
                aTake = take.Value;
                if (aTake > 100)
                {
                    aTake = 100;
                }
            }

            var periodVal = period.ToTimePeriod();
            if (periodVal == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unknown period type."));
            }
            //DateTime aStartDate, aEndDate = DateTime.Now;
            //switch (period)
            //{
            //    case "week" :
            //        aStartDate = aEndDate.AddDays( - ((aEndDate.DayOfWeek - DayOfWeek.Monday + 7) % 7)).Date;
            //        break;

            //    case "month" :
            //        aStartDate = new DateTime(aEndDate.Year, aEndDate.Month, 1);
            //        break;

            //    case "lmonth" :
            //        aStartDate = new DateTime(
            //            aEndDate.Month == 1 ? aEndDate.Year - 1: aEndDate.Year, 
            //            (aEndDate.Month - 2) % 12 + 1,
            //            1);
            //        aEndDate = new DateTime(
            //            aStartDate.Year,
            //            aStartDate.Month,
            //            DateTime.DaysInMonth(aStartDate.Year, aStartDate.Month));
            //        break;

            //    case "quarter" :
            //        aStartDate = new DateTime(
            //            aEndDate.Year,
            //            ((aEndDate.Month - 1) / 3) * 3 + 1,
            //            1);
            //        break;

            //    case "year":
            //        aStartDate = new DateTime(
            //            aEndDate.Year,
            //            1,
            //            1);
            //        break;

            //    case "all":
            //        aStartDate = DateTime.MinValue;
            //        break;

            //    default:
            //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unknown period type."));
            //}


            var data = _expencesService.FindExpencies(
                _userService.GetCurrentUserId(),
                new FindExpenciesDTO
                {
                    Skip = aSkip,
                    Take = aTake,
                    From = periodVal.From,
                    To = periodVal.To
                });

            HttpContext.Current.Response.AppendHeader("BK-HasMore", data.HasMore.ToString());

            return data.Expences;
        }

        // GET api/expences/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/expences
        public ExpenceDTO Post(CreateExpenceDTO dto)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.GetCurrentUserId();
                var resultDto = _expencesService.Create(userId, dto);

                return resultDto;
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

        }

        // PUT api/expences/5
        public void Put(int id, [FromBody]CreateExpenceDTO dto)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.GetCurrentUserId();
                try
                {
                    _expencesService.Update(userId, id, dto);
                }
                catch (ItemNotFoundException ex)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "Expence or Category not found."));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
        }

        // DELETE api/expences/5
        public void Delete(int id)
        {
            var userId = _userService.GetCurrentUserId();
            try
            {
                _expencesService.Delete(new DeleteExpenceDTO { UserId = userId, ExpenceId = id });
            }
            catch (ItemNotFoundException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "You do not have expence with this id."));
            }
        }
    }
}
