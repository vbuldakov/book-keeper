using Services.Exceptions;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Members;

namespace Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IUsersService _usersService;

        public MembersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        //
        // GET: /Members/
        [HttpGet]
        public ActionResult Index()
        {
            if (_usersService.IsAuthneticated())
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        public JsonResult VerifyEmailAvailability(string email)
        {
            if (!_usersService.DoesUserExist(email))
            {
                return Json(true);
            }

            return Json(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usersService.CreateUser(
                        new CreateUserDTO
                        {
                            Email = model.Email,
                            Name = model.Name,
                            Password = model.Password
                        });
                }
                catch (ProjectException)
                {
                    //TODO: log

                    model.Message =
                        new MessageViewModel
                        {
                            Status = MessageStatus.Error,
                            Message = "Unable to register user, please try again later."
                        };

                    return PartialView("_RegisterPartial", model);
                }

                var loginSuccess = 
                    _usersService.Login(new LoginUserDTO
                        {
                            Email = model.Email,
                            Password = model.Password,
                            Remember = false
                        });

                if (loginSuccess)
                {
                    //TODO: move JS into view
                    return JavaScript("window.location = '" + Url.Action("Index", "App") + "'");
                }
                else
                {
                    model.Message =
                        new MessageViewModel
                        {
                            Status = MessageStatus.Warning,
                            Message = "Account has been created, but not able to login. Please try to login later."
                        };

                    return PartialView("_RegisterPartial", model);
                }
            }

            return PartialView("_RegisterPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_usersService.Login(new LoginUserDTO { Email = model.Email, Password = model.Password, Remember = model.Remember }))
                {
                    // TODO: move it into view
                    return JavaScript("window.location = '" + Url.Action("Index", "App") + "'");
                }
                else
                {
                    model.Message =
                        new MessageViewModel
                        {
                            Status = MessageStatus.Error,
                            Message = "Either email or password is invalid"
                        };
                }
            }

            return PartialView("_LoginPartial", model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Logout()
        {
            _usersService.Logout();
        }


        [Authorize]
        [HttpGet]
        new public JsonResult User()
        {
            var dto = _usersService.GetCurrentUser();

            return Json(new { userName = dto.Name }, JsonRequestBehavior.AllowGet);
        }
    }
}
