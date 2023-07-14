using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IGroup:IDisposable
{
    Task<List<Group>> GetGroups();
    Task<Group> GetGroup(int groupid);
    Task<bool> EditGroup(Group group);
    Task<bool> AddGroup(Group group);
    Task<bool> DeleteGroup(int groupId);
}
