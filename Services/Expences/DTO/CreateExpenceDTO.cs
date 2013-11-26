using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class CreateExpenceDTO
    {
        public int CategoryId
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        [Required]
        public string Description
        {
            get;
            set;
        }

        public double Total
        {
            get;
            set;
        }
    }
}
