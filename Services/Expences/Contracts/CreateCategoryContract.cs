using Services.Expences.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Services.Expences.Contracts
{
    public class CreateCategoryContract
    {
        public int UserId
        { 
            get; 
            set; 
        }

        public CreateCategoryDTO Dto
        {
            get;
            set;
        }
    }
}
