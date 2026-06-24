using BryShort.Core.Entities;
using BryShort.Core.Exceptions;
using BryShort.Core.Interfaces;
using BryShort.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Links.Create;

public class UseCaseCreateLink(ILinkRepository linkRepository)
{
    public async Task<Link> Execute(CreateLinkCommand createLinkCommand)
    {
        if (createLinkCommand.expiresAt is not null)
        {
            if(createLinkCommand.expiresAt < DateTime.UtcNow) { throw new BusinessRuleException("No puede registrar una fecha de vencimiento menor a la actual"); }
        }

        var existLink = await linkRepository.GetByShortUrl(createLinkCommand.shortUrl);
        if (existLink.UrlTo.IsValid()) { throw new BusinessRuleException("Nombre de url en uso"); }

        var urlTo = Url.Create(value: createLinkCommand.urlTo, expiresAt: createLinkCommand.expiresAt);
        var link = Link.Create(shortUrl: createLinkCommand.shortUrl, urlTo: urlTo, userId: createLinkCommand.userId, isDeleted: false);

        return await linkRepository.Add(link);
    }
}
