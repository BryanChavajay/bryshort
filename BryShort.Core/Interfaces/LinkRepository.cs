using BryShort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Interfaces;

public interface ILinkRepository
{
    Task<Link> Add(Link link);

    Task<Link> GetByShortUrl(string shortUrl);
}
