using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Schedulify.Application.Configurations;
using Schedulify.Application.Encoders;
using Schedulify.Domain.Dtos.Users;

namespace Schedulify.Application.Providers;

internal class JwtProvider : IJwtProvider
{
    private readonly TokenHelperSettings _settings;
    private readonly byte[] _key;
    private const int ExpiresInMonths = 2;
    
    public JwtProvider(IOptions<TokenHelperSettings> settings)
    {
        _settings = settings.Value;
        _key = Convert.FromBase64String(Base64Encoder.Encode(settings!.Value!.PrivateKey!));
    }
    
    public TokenDto Generate(List<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _settings.Issuer,
            Audience = "api",
            Expires = DateTime.UtcNow.AddMonths(ExpiresInMonths),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha512),
        };

        tokenDescriptor.Subject = new ClaimsIdentity(claims);
        tokenDescriptor.Expires = DateTime.UtcNow.AddDays(ExpiresInMonths);
        tokenDescriptor.Audience = "refresh";
        var accessToken = tokenHandler.CreateToken(tokenDescriptor);
        
        tokenDescriptor.Expires = DateTime.UtcNow.AddDays(ExpiresInMonths);
        tokenDescriptor.Audience = "refresh";
        var refreshToken = tokenHandler.CreateToken(tokenDescriptor);
        
        return new()
        {
            ExpiresIn = ExpiresInMonths,
            ExpiresAtUtc = tokenDescriptor.Expires.Value,
            AccessToken = tokenHandler.WriteToken(accessToken),
            RefreshToken = tokenHandler.WriteToken(refreshToken)
        };
    }
}