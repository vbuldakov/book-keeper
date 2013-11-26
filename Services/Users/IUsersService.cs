using Domain;
namespace Services.Users
{
    public interface IUsersService
    {
        bool DoesUserExist(string email);
        void CreateUser(CreateUserDTO user);
        bool Login(LoginUserDTO dto);
        void Logout();
        bool IsAuthneticated();
        int GetCurrentUserId();

        UserDTO GetCurrentUser();
        UserDTO GetUser(int id);
    }
}
