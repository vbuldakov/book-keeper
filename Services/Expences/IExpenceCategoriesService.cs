using Domain;
using Domain.Expences;
using Services.Expences.Contracts;
using Services.Expences.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences
{
    public interface IExpenceCategoriesService
    {
        IEnumerable<ExpenceCategoryDTO> GetUserCategories(int userId);
        ExpenceCategoryDTO Create(int userId, CreateCategoryDTO dto);
    }
}
