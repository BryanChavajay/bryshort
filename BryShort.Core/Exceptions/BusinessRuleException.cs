using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

public class BusinessRuleException : BaseException
{
    public new const string StatusCode = "400";

    public BusinessRuleException(string message) : base(message, StatusCode)
    {
    }
}
