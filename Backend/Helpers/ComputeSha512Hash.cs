using System.Security.Cryptography;

namespace tik_tak_toe_server.Helpers;

public static class ComputeSha512Hash
{
    public static string ComputeHash(string input)
    {
        using var sha512 = SHA512.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hash = sha512.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}

