﻿using Azmoonak.Database.Models;

namespace Azmoonak.Core.Interface;

public interface IProfile:IDisposable
{
    Task<User> GetUser(string userMobile);
}