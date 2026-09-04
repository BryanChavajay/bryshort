using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using BryShort.Core.Exceptions;
using BryShort.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Links.GetLinkByShorturl;

public class UseCaseGetLinkByShorturl(ILinkRepository linkRepository)
    : IRequestExecute<GetLinkByShorturlCommand, Link>
{
    public async Task<Link> Execute(GetLinkByShorturlCommand request)
    {
        var link = await linkRepository.GetByShortUrl(request.ShortUrl);

        if (link == null || !link.UrlTo.IsValid()) { throw new NotFoundError("Link no encontrado o expirado"); }
        
        return link;
    }
}
