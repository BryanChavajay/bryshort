using BryShort.Core.Exceptions;
using BryShort.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Entities;

public class Link
{
    public int Id { get; private set; }
    public string ShortUrl { get; private set; } = default!;
    public Url UrlTo { get; private set; } = default!;
    public int UserId { get; private set; }
    public bool IsDeleted { get; private set; }

    private Link(int id, string shortUrl, Url urlTo,  int userId,  bool isDeleted)
    {
        if (string.IsNullOrWhiteSpace(shortUrl)) { throw new BusinessRuleException("La url corta no puede ser vacia");  }
        if (shortUrl.Contains(' ')) { throw new BusinessRuleException("La url corta no puede contener espacios en blanco"); }

        Id = id;
        ShortUrl = shortUrl;
        UrlTo = urlTo;
        UserId = userId;
        IsDeleted = isDeleted;
    }

    static public Link Create(string shortUrl, Url urlTo, int userId, bool isDeleted, int id = 0)
    {
        return new Link(0, shortUrl, urlTo, userId, isDeleted);
    }

    static public Link LoadToRepository(int id, string shortUrl, Url urlTo, int userId, bool isDeleted)
    {
        return new Link(id, shortUrl, urlTo, userId, isDeleted);
    }
}
