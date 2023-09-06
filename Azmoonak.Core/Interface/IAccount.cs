using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
    Task<User> LoginUser(LoginViewModel login);
    Task<List<User>> GetUsers();
    Task<User>GetUser (Guid UserId);
    Task<bool> EditUser(User user);
    Task<List<Role>>GetRoles();
    Task<bool> DeleteUser(Guid UserId);

}
