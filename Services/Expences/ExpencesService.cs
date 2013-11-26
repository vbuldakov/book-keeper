using DataAccess.Core;
using Domain;
using Domain.Core;
using Domain.Core.Specification;
using Domain.Expences;
using Services.Cache;
using Services.Exceptions;
using Services.Expences.Contracts;
using Services.Expences.DTO;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences
{
    public class ExpencesService: IExpencesService
    {
        private readonly IExpenceCategoryRepository _categoryRepo;
        private readonly IExpenceRepository _expenceRepo;
        private readonly IUnitOfWork _uow;
        private readonly ICache _cache;
        private readonly ICacheKeyBuilderFactory _keyFactory;
        private readonly ICacheTagManager _tagManager;

        public ExpencesService(
            IExpenceCategoryRepository categoryRepo,
            IExpenceRepository expenceRepo,
            IUnitOfWork uow,
            ICache cache,
            ICacheKeyBuilderFactory keyFactory,
            ICacheTagManager tagManager)

        {
            _categoryRepo = categoryRepo;
            _expenceRepo = expenceRepo;
            _uow = uow;
            _cache = cache;
            _keyFactory = keyFactory;
            _tagManager = tagManager;
        }

        public ExpenceDTO Create(int userId, CreateExpenceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            var category = _categoryRepo.All(ExpenceCategorySpecifications.ByUserAndId(userId, dto.CategoryId)).SingleOrDefault();
            if (category == null)
            {
                throw new ItemNotFoundException(string.Format("Expence category with id \"{0}\" no found for user \"{1}\".", dto.CategoryId, userId));
            }

            var expence =
                new Expence
                {
                    Date = dto.Date,
                    Comments = dto.Description,
                    Total = dto.Total
                };

            category.Expences.Add(expence);

            _uow.Commit();

            _tagManager.TouchTag("expence", "create", category.UserId);

            return
                new ExpenceDTO
                {
                    Id = expence.ExpenceId,
                    Date = expence.Date,
                    CategoryId = expence.ExpenceCategoryId,
                    Category = expence.Category.Name,
                    Description = expence.Comments,
                    Total = expence.Total
                };
        }

        public ExpencesListDTO FindExpencies(int userId, FindExpenciesDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            if (dto.Skip < 0 || dto.Take <= 0)
            {
                throw new InvalidInputException("Wrong value for \'Skip\' and/or \'Take\'.");
            }

            var spec = new AndSpecification<Expence>(
                ExpenceSpecifications.ByUserId(userId),
                ExpenceSpecifications.DateFilter(dto.From, dto.To));

            var data = _expenceRepo
                            .GetUserExpences(
                                spec,
                                dto.Skip,
                                dto.Take)
                            .Select(e =>
                                new ExpenceDTO
                                {
                                    Id = e.ExpenceId,
                                    CategoryId = e.ExpenceCategoryId,
                                    Category = e.Category.Name,
                                    Date = e.Date,
                                    Description = e.Comments,
                                    Total = e.Total
                                })
                            .ToList();

            return new ExpencesListDTO
            {
                Expences = data,
                HasMore = dto.Skip + dto.Take < this.Count(spec)
            };
        }

        public void Delete(DeleteExpenceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            var expences = _expenceRepo.All(ExpenceSpecifications.ByUserAndId(dto.UserId, dto.ExpenceId));

            if (expences.Count() == 0)
            {
                throw new ItemNotFoundException(string.Format("Expence with id \"{0}\" with user id \"{1}\" not found.", dto.ExpenceId, dto.UserId));
            }

            foreach (var exp in expences) 
            {
                _expenceRepo.Delete(exp);
            }

            _uow.Commit();

            _tagManager.TouchTag("expence", "delete", dto.UserId);
        }

        public void Update(int userId, int expenceId, CreateExpenceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            var expence = _expenceRepo.All(ExpenceSpecifications.ByUserAndId(userId, expenceId)).FirstOrDefault();
            if (expence == null)
            {
                throw new ItemNotFoundException(string.Format("Expence with id \"{0}\" not found for user \"{1}\"", expenceId, userId));
            }

            var expenceCategory = _categoryRepo.All(ExpenceCategorySpecifications.ByUserAndId(userId, dto.CategoryId)).FirstOrDefault();
            if (expenceCategory == null)
            {
                throw new ItemNotFoundException(string.Format("ExpenceCategory with id \"{0}\" not found for user \"{1}\"", dto.CategoryId, userId));
            }

            expence.Category = expenceCategory;
            expence.Date = dto.Date;
            expence.Comments = dto.Description;
            expence.Total = dto.Total;

            _uow.Commit();

            _tagManager.TouchTag("expence", "udpate", userId);
        }

        private int Count(ISpecification<Expence> spec)
        {
            return _expenceRepo.Count(spec);
        }

    }
}
