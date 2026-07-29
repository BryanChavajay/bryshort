using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using BryShort.Core.Exceptions;
using BryShort.Core.Interfaces;
using BryShort.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Links.Create;

public class UseCaseCreateLink(ILinkRepository linkRepository)
    : IRequestExecute<CreateLinkCommand, Link>
{
    public async Task<Link> Execute(CreateLinkCommand createLinkCommand)
    {
        if (createLinkCommand.ExpiresAt is not null)
        {
            if(createLinkCommand.ExpiresAt < DateTime.UtcNow) { throw new BusinessRuleException("No puede registrar una fecha de vencimiento menor a la actual"); }
        }

        var existLink = await linkRepository.GetByShortUrl(createLinkCommand.ShortUrl);
        if (existLink != null && existLink.UrlTo.IsValid()) { throw new BusinessRuleException("Nombre de url en uso"); }

        var urlTo = Url.Create(value: createLinkCommand.UrlTo, expiresAt: createLinkCommand.ExpiresAt);
        var link = Link.Create(shortUrl: createLinkCommand.ShortUrl, urlTo: urlTo, userId: createLinkCommand.UserId, isDeleted: false);

        return await linkRepository.Add(link);
    }
}
