using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Exceptions;

public class NotFoundError(string message): BaseException(message, statusCode: 404)
{
}
