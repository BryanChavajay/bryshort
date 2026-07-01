using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Links.Create;

public record CreateLinkCommand(
    string shortUrl,
    string urlTo,
    DateTime? expiresAt,
    int userId
) : IRequest<Link>;
