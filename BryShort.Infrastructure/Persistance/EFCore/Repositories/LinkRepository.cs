using BryShort.Core.Entities;
using BryShort.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Infrastructure.Persistance.EFCore.Repositories;

internal class EFLinkRepository(ApplicationDbContext context) : ILinkRepository
{
    public async Task<Link> Add(Link link)
    {
        context.Add(link);
        await context.SaveChangesAsync();
        return link;
    }

    public async Task<Link?> GetByShortUrl(string shortUrl)
    {
        var link = context.Links.OrderByDescending(x => x.Id).FirstOrDefault(x => x.ShortUrl == shortUrl);
        return link;
    }
}
