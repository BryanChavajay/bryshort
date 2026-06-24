using System;
using System.Collections.Generic;
using System.Text;
using BryShort.Core.Exceptions;

namespace BryShort.Core.Entities;

public class User
{
    public int Id {  get; private set; }
    public Guid PublicId { get; private set; } = Guid.CreateVersion7();
    public string Username { get; private set; } = default!;
    public string Password { get; private set; } = default!;
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;

    private User(int id, Guid publicId, string username, string password, bool isActive, bool isDeleted)
    {
        if (string.IsNullOrWhiteSpace(username)) { throw new BusinessRuleException("El nombre de usuario es obligatorio"); }
        if (string.IsNullOrWhiteSpace(password)) { throw new BusinessRuleException("La contrasenia debe es obligatorioa"); }

        Id = id;
        PublicId = publicId;
        Username = username;
        Password = password;
        IsActive = isActive;
        IsDeleted = isDeleted; 
    }

    public static User Create(string username, string password, bool isActive)
    {
        if (password.Length < 8) { throw new BusinessRuleException("La contraseña no debe ser menor a 8"); }
        if (username.Contains(' ')) { throw new BusinessRuleException("El nombre de usuario no debe contener espacios en blanco"); }
        return new User( 0, Guid.CreateVersion7(), username, password, isActive, false );
    }

    public static User LoadToRepository(int id, Guid publicId, string username, string password, bool isActive, bool isDeleted)
    {
        return new User(id, publicId, username, password, isActive, isDeleted);
    }
}
