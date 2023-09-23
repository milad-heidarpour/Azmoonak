using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Azmoonak.Core.Services;

public class ProfileService:IProfile
{
    private readonly DatabaseContext _context;
    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Certificate> AddCertificate(Certificate certificate)
    {
        try
        {
            Certificate Finalcertificate= new Certificate()
            {
                Id = certificate.Id,
                UserId = certificate.UserId,
                GroupId = certificate.GroupId,
                FinalScore = certificate.FinalScore,
                CorrectAnswer = certificate.CorrectAnswer,
                FalseAnswer = certificate.FalseAnswer,
                NoAnswer = certificate.NoAnswer,
                OpenDateTime = certificate.OpenDateTime,
            };

            await _context.Certificates.AddAsync(Finalcertificate);
            await _context.SaveChangesAsync();
            return Finalcertificate;
        }
        catch (Exception error)
        {
            Console.WriteLine("add Certificate error====>{0}", error.Message);
            return null; 
            throw;
        }
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<User> GetUserName(string UserMobile)
    {
        var User = await _context.Users.FirstOrDefaultAsync(u=>u.Mobile==UserMobile);
        return User;
    }

    public async Task<List<Certificate>> GetCertificate(Guid userId)
    {

        var Certificate = await _context.Certificates.Include(c=>c.Group).Include(c=>c.User).Where(c => c.UserId == userId).ToListAsync();
        return Certificate;
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user =await _context.Users.Where(u => u.Mobile == userMobile).Select(s => new User()
        {
            Id = s.Id,
            FName=s.FName,
            LName=s.LName,
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

    public async Task<User> GetUser(Guid id)//id=userid
    {
        var user = await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<bool> EditProfile(EditUserDashbordViewModel user)
    {
        try
        {
            User editUser = new User()
            {
                Id = user.Id,
                RoleId = user.RoleId,
                FName = user.FName,
                LName = user.LName,
                Mobile = user.Mobile,
                Password = user.Password,
            };
            _context.Users.Update(editUser);
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
}
