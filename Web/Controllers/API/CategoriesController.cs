using Services.Expences;
using Services.Expences.DTO;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Web.Controllers.API
{
    [Authorize]
    public class CategoriesController : ApiController
    {
        private readonly IExpenceCategoriesService _categoriesService;
        private readonly IUsersService _usersService;

        public CategoriesController(
            IUsersService usersService,
            IExpenceCategoriesService categoriesService)
        {
            _usersService = usersService;
            _categoriesService = categoriesService;
        }

        // GET api/categories
        public IEnumerable<ExpenceCategoryDTO> Get()
        {
            var userId = _usersService.GetCurrentUserId();
            var data = _categoriesService.GetUserCategories(userId);

            return data;
        }

        // GET api/categories/5
        public string Get(int id)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Method not implemented.")); 
        }

        // POST api/categories
        public ExpenceCategoryDTO Post(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var userId = _usersService.GetCurrentUserId();
                var resultDto = _categoriesService.Create(userId, dto);

                return resultDto;
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState)); 
            }
        }

        // PUT api/categories/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Method not implemented.")); 
        }

        // DELETE api/categories/5
        public void Delete(int id)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Method not implemented.")); 
        }
    }
}
