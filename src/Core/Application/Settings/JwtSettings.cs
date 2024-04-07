using System.Text;

namespace Application.Settings;

internal static class JwtSettings
{
    internal static string SecretKey = "333c1237e4da4576b728523c84bb6449";
    internal static byte[] GenerateSecretByte() =>
        Encoding.ASCII.GetBytes(SecretKey);
}
