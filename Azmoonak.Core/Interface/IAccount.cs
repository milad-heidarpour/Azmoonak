using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
    Task<User> LoginUser(LoginViewModel login);
}
