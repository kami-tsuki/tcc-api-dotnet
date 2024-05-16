namespace TCC.API.Services;

public class TokenService(IConfiguration configuration, TccDbContext context) : ITokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["EncryptionSettings:SecretKey"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(
                new Claim[]
                {
                    new(UserIdClaim, user.Id.ToString()),
                    new(RoleIdClaim, user.RoleId?.ToString() ?? 1.ToString()),
                    new(PersonalKeyClaim, user.PersonalKey)
                }),

            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string? ExtractClaim(ClaimsPrincipal claimsPrincipal, string claimType) => claimsPrincipal.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;

    public ClaimsPrincipal? ValidateToken(string token, out SecurityToken validatedToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ValidateToken(
            token,
            ValidationParameters(configuration),
            out validatedToken);
    }

    public static TokenValidationParameters ValidationParameters(IConfiguration configuration) => new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["EncryptionSettings:SecretKey"]))
    };

    public const string AuthHeader = "x-auth-token";
    public const string UserIdClaim = "user-id";
    public const string RoleIdClaim = "role-id";
    public const string PersonalKeyClaim = "personal-key";
}