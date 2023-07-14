using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Classes;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azmoonak.Core.Services;

public class AccountService:IAccount
{
    private readonly DatabaseContext _context;
    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddUser(RegisterViewModel register)
    {
        try
        {

            // suer mobile exist or not
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile == register.Mobile);
            if (user != null)
            {
                return false;
            }


            //add user
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = _context.Roles.SingleOrDefault(r => r.RoleName == "user").Id,
                Mobile = register.Mobile,
                Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                IsActive = true
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            Console.WriteLine("add user error : {0}", error.Message);
            return false;
        }
    }
    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<User> LoginUser(LoginViewModel login)
    {
        try
        {
            var hashpassword = await new Security().HashPassword(await new Security().HashPassword(login.Password));
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Mobile == login.Mobile && u.Password == hashpassword);
            if (user != null)
            {

                return user;
            }
            return null;
        }
        catch (Exception)
        {

            return null;
        }
    }
}
