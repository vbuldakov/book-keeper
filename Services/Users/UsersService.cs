using System.Linq;
using DataAccess.Core;
using Domain;
using WebMatrix.WebData;
using Services.Exceptions;
using Domain.Core;
using Services.Cache;

namespace Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _usersRepository;
        private readonly ICache _cache;
        private readonly ICacheKeyBuilderFactory _cacheKeyBuilderFactory;

        public UsersService(IUserRepository usersRepository, ICache cache, ICacheKeyBuilderFactory cacheKeyBuilderFactory)
        {
            _usersRepository = usersRepository;
            _cache = cache;

            _cacheKeyBuilderFactory = cacheKeyBuilderFactory;
        }

        #region IUsersService Members

        public bool DoesUserExist(string email)
        {
            return WebSecurity.UserExists(email);
        }

        public void CreateUser(CreateUserDTO dto)
        {
            if (this.DoesUserExist(dto.Email))
            {
                throw new ProjectException(string.Format("User \"{0}\" already exist.", dto.Email));
            }

            WebSecurity.CreateUserAndAccount(dto.Email, dto.Password, new { Name = dto.Name });

            //TODO: validate email and confirm account
        }

        public bool Login(LoginUserDTO dto)
        {
            return WebSecurity.Login(dto.Email, dto.Password, dto.Remember);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }

        public bool IsAuthneticated()
        {
            return WebSecurity.IsAuthenticated;
        }

        public int GetCurrentUserId()
        {
            var userIdKey = _cacheKeyBuilderFactory.CreateKey().Add("UserId").Add(WebSecurity.CurrentUserName).GetKey();

            int id = -1;
            var idWrapper = _cache.Get<CacheValueObject<int>>(userIdKey);
            if (idWrapper == null)
            {
                id = WebSecurity.CurrentUserId;
                _cache.Set(userIdKey, new CacheValueObject<int>(id), new System.Runtime.Caching.CacheItemPolicy() { SlidingExpiration = System.TimeSpan.FromDays(7) });
            }
            else
            {
                id = idWrapper.Value;
            }

            return id;
        }

        public UserDTO GetCurrentUser()
        {
            return this.GetUser(this.GetCurrentUserId());
        }

        public UserDTO GetUser(int id)
        {
            var userKey = _cacheKeyBuilderFactory.CreateKey().Add("UserDTO").Add(id).GetKey();
            var userInfo = _cache.Get<UserDTO>(userKey);
            if (userInfo == null)
            {
                var user = _usersRepository.All(UserSpecifications.ById(id)).FirstOrDefault();
                if (user != null)
                {
                    userInfo =
                        new UserDTO
                        {
                            Id = user.UserId,
                            Email = user.Email,
                            Name = user.Name
                        };

                    _cache.Set(userKey, userInfo);
                }
            }

            return userInfo;
        }

        #endregion
    }
}
