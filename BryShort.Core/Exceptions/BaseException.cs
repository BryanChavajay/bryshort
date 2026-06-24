using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

public class BaseException : Exception
{
    public string StatusCode { get; set; } = default!;

    public BaseException(string message, string statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
