using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Services.Expences.Contracts
{
    public class CreateExpenceContract
    {
        public int UserId 
        { 
            get; 
            set; 
        }

        public DateTime Date 
        { 
            get; 
            set; 
        }

        public int? CategoryId 
        { 
            get; 
            set; 
        }

        public string CategoryText 
        { 
            get; 
            set; 
        }

        [Required]
        public string Comments 
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
