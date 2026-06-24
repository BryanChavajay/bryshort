using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

internal class BaseException : Exception
{
    public string StatusCode { get; set; } = default!;

    public BaseException(string message) : base(message)
    {
    }
}
