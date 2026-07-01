using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using BryShort.Core.Exceptions;
using BryShort.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Users.Create;

public class UseCaseCreateUser(IUserRepository userRepository)
    : IRequestExecute<CreateUserCommand, User>
{
    public async Task<User> Execute(CreateUserCommand command)
    {
        var exist = await userRepository.ExistUsername(command.Username);

        if (exist) { throw new BusinessRuleException("El nombre de usuario ya esta registrado"); }

        var passwordHashed = BCrypt.Net.BCrypt.HashPassword(command.Password);

        var user = User.Create(username: command.Username, password: passwordHashed, isActive: command.isActive);

        return await userRepository.Add(user);
    }

}
