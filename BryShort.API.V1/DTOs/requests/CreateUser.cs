using System.ComponentModel.DataAnnotations;

namespace BryShort.API.V1.DTOs.requests;

public class CreateUserDTO
{
    [Required]
    [MaxLength(64)]
    public required string UserName { get; set; }
    [Required]
    [MaxLength(32)]
    public required string Password { get; set; }
}
