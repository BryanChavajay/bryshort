using BryShort.Core.Entities;
using BryShort.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Infrastructure.Persistance.EFCore.Repositories;

internal class EFUserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User> Add(User user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> ExistUsername(string username)
    {
        return await context.Users.AnyAsync(x => x.Username == username);
    }

    public async Task<User?> GetById(int id)
    {
        var user = await context.Users.FindAsync(id);
        return user;
    }

    public async Task<User?> GetByPublicId(Guid publicId)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.PublicId == publicId);
        return user;
    }

    public async Task<User?> GetByUsername(string username)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
        return user;
    }
}
