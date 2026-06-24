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
}
