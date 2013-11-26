using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences.DTO
{
    public class ExpencesListDTO
    {
        public bool HasMore { get; set; }
        public IEnumerable<ExpenceDTO> Expences { get; set; }
    }
}
