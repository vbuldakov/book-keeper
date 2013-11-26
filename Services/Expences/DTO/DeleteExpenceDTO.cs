using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class DeleteExpenceDTO
    {
        public int UserId { get; set; }
        public int ExpenceId { get; set; }
    }
}
