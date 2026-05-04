using System.Security.Cryptography;
using System.Text;

namespace VehicleManager.Application.Services.Cryptography;

public class PasswordEncrypter
{
    
    private readonly string _addKey;
    public PasswordEncrypter(string addKey) =>  _addKey = addKey;
    
    public string Encrypt(string password)
    {
        var newPassword = $"{password}{_addKey}";
        
        var bytes = Encoding.UTF8.GetBytes(newPassword);
        var hashBytes = SHA512.HashData(bytes);
        
        return StringBytes(hashBytes);
    }
    
    // Função para converter Array de bytes em String (Fonte: Welisson Arley, em 29/04/2026)
    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        
        return sb.ToString();
    }
}