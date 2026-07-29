using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

public class BusinessRuleException(string message) : BaseException(message, 400)
{
}
