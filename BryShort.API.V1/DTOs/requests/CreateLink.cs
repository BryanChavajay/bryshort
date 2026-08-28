using System.ComponentModel.DataAnnotations;

namespace BryShort.API.V1.DTOs.requests;

public class CreateLinkDTO
{
    [Required]
    public required string ShortUrl { get; set; }

    [Required]
    [MaxLength(32)]
    public required string UrlTo { get; set; }

    public DateTime? ExpiresAt { get; set; }

    int UserId { get; set; }
}
