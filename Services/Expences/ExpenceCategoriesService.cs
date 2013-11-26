using DataAccess.Core;
using DataAccess.Repositories;
using Domain;
using Domain.Core;
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
    public class ExpenceCategoriesService : IExpenceCategoriesService
    {
        private readonly IExpenceCategoryRepository _categoryRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _uow;
        private readonly ICache _cache;
        private readonly ICacheKeyBuilderFactory _keyFactory;
        private readonly ICacheTagManager _tagManager;

        public ExpenceCategoriesService(
            IExpenceCategoryRepository categoryRepo, 
            IUserRepository userRepo,
            IUnitOfWork uow,
            ICache cache,
            ICacheKeyBuilderFactory keyFactory,
            ICacheTagManager tagManager)
        {
            _categoryRepo = categoryRepo;
            _userRepo = userRepo;
            _uow = uow;
            _cache = cache;
            _keyFactory = keyFactory;
            _tagManager = tagManager;
        }

        public ExpenceCategoryDTO Create(int userId, CreateCategoryDTO dto)
        {
            #region Validate 

            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new InvalidInputException("Category name is required.");
            }

            var user = _userRepo.All(UserSpecifications.ById(userId)).FirstOrDefault();

            if (user == null)
            {
                throw new ItemNotFoundException(string.Format("User with id \"{0}\" not found.", userId));
            }

            var existingCategory = _categoryRepo.All(ExpenceCategorySpecifications.ByName(dto.Name)).FirstOrDefault();
            if (existingCategory != null)
            {
                throw new ItemAlreadyExistException(string.Format("Category with name \'" + dto.Name + "\' already exist"));
            }

            #endregion

            var category = new ExpenceCategory() { Name = dto.Name.Trim() };

            user.ExpenceCategories.Add(category);

            _uow.Commit();

            _tagManager.TouchTag("category", "create", category.UserId);

            return 
                new ExpenceCategoryDTO
                {
                    Id = category.ExpenceCategoryId,
                    Name = category.Name
                };
        }

        public IEnumerable<ExpenceCategoryDTO> GetUserCategories(int userId)
        {
            var key = _keyFactory
                .CreateKey()
                .Add("categories")
                .AddTag("category", "create", userId)
                .AddTag("category", "update", userId)
                .AddTag("category", "delete", userId)
                .GetKey();

            var data = _cache.Get<IEnumerable<ExpenceCategoryDTO>>(key);
            if (data == null)
            {
                data = _categoryRepo
                            .GetCategoriesForUser(ExpenceCategorySpecifications.ByUserId(userId))
                            .Select(c =>
                                new ExpenceCategoryDTO
                                {
                                    Id = c.ExpenceCategoryId,
                                    Name = c.Name
                                })
                            .ToList();

                _cache.Set(key, data);
            }

            return data;
        }
    }
}
