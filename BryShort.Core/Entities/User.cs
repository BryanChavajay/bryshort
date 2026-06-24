using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Core.Entities;

public class User
{
    public int Id {  get; private set; }
    public Guid PublicId { get; private set; } = Guid.CreateVersion7();
    public string Username { get; private set; } = default!;
    public string Password { get; private set; } = default!;
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
}
