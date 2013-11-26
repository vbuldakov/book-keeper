using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Members
{
    public class LoginViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please specify your email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please specify your password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool Remember { get; set; }

        public MessageViewModel Message { get; set; }
    }
}