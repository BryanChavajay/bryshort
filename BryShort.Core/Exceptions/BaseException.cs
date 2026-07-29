using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { get; set; } = default!;

    public BaseException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
