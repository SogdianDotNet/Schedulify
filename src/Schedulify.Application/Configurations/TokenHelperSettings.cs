namespace Schedulify.Application.Configurations;

public class TokenHelperSettings
{
    public const string SectionName = nameof(TokenHelperSettings);

    /// <summary>
    /// The private key for hashing the JWT tokens
    /// </summary>
    public string? PrivateKey { get; set; }

    /// <summary>
    /// Issuer of the token
    /// </summary>
    public string? Issuer { get; set; }
}