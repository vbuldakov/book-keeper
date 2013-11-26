using Services.Expences.Contracts;
using Services.Expences.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences
{
    public interface IExpencesService
    {
        ExpenceDTO Create(int userId, CreateExpenceDTO dto);
        ExpencesListDTO FindExpencies(int userId, FindExpenciesDTO dto);
        void Delete(DeleteExpenceDTO dto);
        void Update(int userId, int expenceId, CreateExpenceDTO dto);
    }
}
