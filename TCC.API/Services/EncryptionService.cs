namespace TCC.API.Services;

public class EncryptionService(IConfiguration configuration) : IEncryptionService
{
    private readonly string? _configurableSalt = configuration.GetSection("EncryptionSettings:ConfigurableSalt").Value;
    private const string HardcodedSalt = "zw egurktu207qiu57u18quwgtfvuwqz ut vq2 otiq";

    public string Encrypt(string value)
    {
        using var sha256 = SHA256.Create();
        var saltedValue = new StringBuilder(value)
                         .Append(_configurableSalt)
                         .Append(HardcodedSalt)
                         .ToString();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedValue));
        return Convert.ToBase64String(hashedBytes);
    }
}