using System.ComponentModel.DataAnnotations;

namespace BryShort.API.V1.DTOs.requests;

public class CreateLinkDTO
{
    [Required]
    [MaxLength(16)]
    public required string ShortUrl { get; set; }

    [Required]
    public required string UrlTo { get; set; }

    public DateTime? ExpiresAt { get; set; }

    int UserId { get; set; }
}
