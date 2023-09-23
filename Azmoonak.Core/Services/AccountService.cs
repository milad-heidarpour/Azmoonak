using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Classes;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.ConsoleColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Azmoonak.Core.Services;

public class AccountService : IAccount
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

            // sure mobile exist or not
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile == register.Mobile);
            if (user != null)
            {
                return false;
            }


            if (register.Password==register.RePassword)
            {
                //add user
                User newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    RoleId = _context.Roles.SingleOrDefault(r => r.RoleName == "user").Id,
                    FName = register.FName,
                    LName = register.LName,
                    Mobile = register.Mobile,
                    Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                    IsActive = true
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        catch (Exception error)
        {
            Console.WriteLine("add user error : {0}", error.Message);
            return false;
        }
    }

    public async Task<bool> DeleteUser(Guid UserId)
    {
        try
        {
            var user = _context.Users.Find(UserId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);

        }
        catch (Exception error)
        {
            WriteLine(error.Message,
                   BackgroundColor = Red,
                   ForegroundColor = Yellow);
            return await Task.FromResult(false);
        }
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }


    public async Task<bool> EditAdminDashbord(EditAdminViewModel admin)
    {
        try
        {
            User editAdmin = new User()
            {
                Id = admin.Id,
                RoleId = admin.RoleId,
                FName = admin.FName,
                LName = admin.LName,
                Mobile = admin.Mobile,
                Password = admin.Password,
            };
            _context.Users.Update(editAdmin);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                Console.BackgroundColor = ConsoleColor.Red,
                Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }



    public async Task<bool> EditUser(EditUserViewModel user)
    {
        try
        {
            User edituser = new User()
            {
                Id = user.Id,
                RoleId = user.RoleId,
                FName = user.FName,
                LName = user.LName,
                Password = user.Password,
                Mobile = user.Mobile,
                IsActive = user.IsActive,
            };
            _context.Users.Update(edituser);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                Console.BackgroundColor = ConsoleColor.Red,
                Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<List<User>> GetAdmins()
    {
        var admins = _context.Users.Include(u => u.Role).Where(u => u.Role.RoleName == "admin").ToList();
        return await Task.FromResult(admins);
    }

    public async Task<List<Role>> GetRoles()
    {
        var roles = await _context.Roles.Include(r=>r.Users).ToListAsync();
        return await Task.FromResult(roles);
    }

    public async Task<User> GetUser(Guid UserId)
    {
        var user = await _context.Users.Include(u=>u.Certificates).Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == UserId);
        return await Task.FromResult(user);
    }
    public async Task<List<Certificate>> GetUserCertificate(Guid UserId)
    {
        var certificates = await _context.Certificates.Include(c=>c.User).Include(c=>c.Group).Where(c => c.UserId == UserId).ToListAsync();
        return await Task.FromResult(certificates);
    }

    public async Task<User> GetAdmin(string AdminMobile)
    {
        var admin = await _context.Users.Where(u => u.Mobile == AdminMobile).Select(s => new User()
        {
            Id = s.Id,
            FName = s.FName,
            LName = s.LName,
            Mobile = s.Mobile,
            Password=s.Password,
            IsActive = s.IsActive,
            Role = new Role()
            {
                Id = s.Role.Id,
                RoleName = s.Role.RoleName
            }
        }).FirstOrDefaultAsync();
        return admin;
    }

    public async Task<List<User>> GetUsers()//just for users
    {
        var users = _context.Users.Include(u => u.Role).Where(u => u.Role.RoleName == "user").ToList();
        return await Task.FromResult(users);
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

    public async Task<User> GetAdmin(Guid AdminId)
    {
        var admin = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == AdminId);
        return await Task.FromResult(admin);
    }
}
