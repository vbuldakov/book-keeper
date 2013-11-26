using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class ExpenceDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }

    }
}
