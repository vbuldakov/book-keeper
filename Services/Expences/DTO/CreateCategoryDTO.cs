using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name
        {
            get;
            set;
        }
    }
}
