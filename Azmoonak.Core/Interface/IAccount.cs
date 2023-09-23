using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
    Task<User> LoginUser(LoginViewModel login);
    Task<List<User>> GetUsers();
    Task<List<User>> GetAdmins();
    Task<User>GetUser (Guid UserId);
    Task<User> GetAdmin(Guid AdminId);
    Task<List<Certificate>> GetUserCertificate(Guid UserId);
    Task<User> GetAdmin(string AdminMobile);
    Task<bool> EditAdminDashbord(EditAdminViewModel admin);
    Task<bool> EditUser(EditUserViewModel user);
    Task<List<Role>>GetRoles();
    Task<bool> DeleteUser(Guid UserId);

}
