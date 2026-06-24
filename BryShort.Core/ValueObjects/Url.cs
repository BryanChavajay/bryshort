using BryShort.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.ValueObjects;

public class Url
{

    public string Value { get; private set; } = default!;
    public DateTime? ExpiresAt { get; private set; } = null;

    private Url (string value, DateTime? expiresAt)
    {
        if (string.IsNullOrEmpty(value)) { throw new BusinessRuleException("La url a redirigir no puede estar vacia"); }

        Value = value;
        ExpiresAt = expiresAt;
    }

    public static Url Create(string value, DateTime? expiresAt)
    {
        return new Url(value, expiresAt);
    }

    public bool IsValid()
    {
        if (ExpiresAt is null) { return true; }
        return ExpiresAt <= DateTime.UtcNow;
    }
}
