using Azmoonak.Core.Interface;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Azmoonak.Core.Services;

public class ProfileService:IProfile
{
    private readonly DatabaseContext _context;
    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user =await _context.Users.Where(u => u.Mobile == userMobile).Select(s => new User()
        {
            Id = s.Id,
            Mobile = s.Mobile,
            IsActive = s.IsActive,
            Role = new Role()
            {
                Id = s.Role.Id,
                RoleName = s.Role.RoleName
            }
        }).FirstOrDefaultAsync();
        return user;
    }
}
