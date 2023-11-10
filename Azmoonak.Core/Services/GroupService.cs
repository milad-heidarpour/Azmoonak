using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Net.Http.Headers;

namespace Azmoonak.Core.Services;

public class GroupService : IGroup
{
    public readonly DatabaseContext _context;

    public GroupService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> EditGroup(Group group)
    {
        try
        {
            //1
            _context.Update(group);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message, Console.BackgroundColor = ConsoleColor.Red,
                Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async void Dispose()
    {
        if (_context!=null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<Group> GetGroup(int groupid)
    {
        //var group = _context.Groups.Find(groupid);
        //return await Task.FromResult(group);

        var group = await _context.Groups.Include(g => g.Questions).FirstOrDefaultAsync(g => g.Id == groupid);
        return await Task.FromResult(group);
    }

    public async Task<List<Group>> GetGroups()
    {
        var groups = _context.Groups.Where(g=>g.NotShow==false).ToList();
        return await Task.FromResult(groups);
    }

    public async Task<bool> AddGroup(Group group)
    {
        try
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                 Console.BackgroundColor = ConsoleColor.Red,
                 Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> DeleteGroup(int groupId)
    {
        try
        {
            var groups = _context.Groups.Find(groupId);
            if (groups != null)
            {
                _context.Groups.Remove(groups);
                await _context.SaveChangesAsync();

                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                       Console.BackgroundColor = ConsoleColor.Red,
                       Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
            // throw;
        }
    }
}

