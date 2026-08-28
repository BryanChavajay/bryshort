namespace BryShort.API.V1.DTOs.publics;

public record PublicLink(
    string ShortUrl,
    string UrlTo,
    DateTime? ExpiresAt
);