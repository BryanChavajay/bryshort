using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Users.Create;

public record CreateUserCommand(
    string Username,
    string Password,
    bool isActive
) : IRequest<User>;
