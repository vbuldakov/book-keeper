using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Expences
{
    public class AddNewExpenceViewModel
    {
        [Display(Name="Set date")]
        [Required(ErrorMessage="Please specify date")]
        public string Date { get; set; }

        [Display(Name = "Specify category")]
        [Required(ErrorMessage = "Please specify category")]
        public string Category { get; set; }

        [Display(Name = "Add comments")]
        public string Comments { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage="Please specify spent value")]
        public double Total { get; set; }
    }
}