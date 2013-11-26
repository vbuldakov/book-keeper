using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.Members
{
    public class RegisterViewModel
    {
        [Display(Name = "Your Name", Prompt = "Your Name")]
        [Required(ErrorMessage="Please specify your name")]
        public string Name { get; set;}

        [Display(Name = "Email address", Prompt = "Your email address")]
        [Required(ErrorMessage = "Please specify your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Specify valid email address")]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please specify valid email address")]
        [Remote("VerifyEmailAvailability", "Members", HttpMethod = "POST", ErrorMessage = "User with this email already registered")]
        public string Email { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [Required(ErrorMessage="Please specify password")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Password must contain at least 5 but no more than 16 characters")]
        public string Password { get; set; }

        [Display(Name = "Password", Prompt = "Confirm password")]
        [Required(ErrorMessage="Please confirm your password")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Password must contain at least 5 but no more than 16 characters")]
        [Compare("Password", ErrorMessage = "Paswords do not match.")]
        public string ConfirmPassword { get; set; }

        public MessageViewModel Message { get; set; }

    }
}