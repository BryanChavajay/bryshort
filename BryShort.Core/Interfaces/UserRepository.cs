using BryShort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Interfaces;

public interface IUserRepository
{
    Task<User> Add(User user);

    Task<User> GetById(int id);

    Task<User> GetByPublicId(Guid publicId);

    Task<User> GetByUsername(string username);

    Task<bool> ExistUsername(string username);
}
