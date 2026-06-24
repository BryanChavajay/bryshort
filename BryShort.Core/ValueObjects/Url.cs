using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.ValueObjects;

public class Url
{

    public string Value { get; private set; } = default!;
    public DateTime? Expires_at { get; private set; } = null;

}
