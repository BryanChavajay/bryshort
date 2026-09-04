using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Links.GetLinkByShorturl;

public record GetLinkByShorturlCommand(
    string ShortUrl
) : IRequest<Link>;
