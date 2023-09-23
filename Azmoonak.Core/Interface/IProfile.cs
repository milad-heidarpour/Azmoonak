using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IProfile:IDisposable
{
    Task<User> GetUser(string userMobile);
    Task<User> GetUser(Guid id);

    Task<Certificate> AddCertificate(Certificate certificate);

    Task<List<Certificate>> GetCertificate(Guid userId);

    Task<User> GetUserName(string UserMobile);
    Task<bool> EditProfile(EditUserDashbordViewModel user);
}
