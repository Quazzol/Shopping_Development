using System.Security.Cryptography;
using System.Text;


namespace Quadro.Core.Infrastructure.Encryption;

public class AesEncryptionService : IEncryptionService
{

    private readonly ICryptoTransform _encryptor;
    private readonly ICryptoTransform _decryptor;
    public AesEncryptionService()
    {
        var aes = Aes.Create();
        _encryptor = aes.CreateEncryptor();
        _decryptor = aes.CreateDecryptor();
    }

    public string Decrypt(string encrypted)
    {
        var bytes = Convert.FromBase64String(encrypted);
        return Encoding.UTF8.GetString(Transform(bytes, _decryptor));
    }

    public string Encrypt(string unencrypted)
    {
        var bytes = Transform(Encoding.UTF8.GetBytes(unencrypted), _encryptor);
        return Convert.ToBase64String(bytes);
    }


    private static readonly object LockObject = new object();
    private byte[] Transform(byte[] buffer, ICryptoTransform cryptoTransform)
    {
        lock (LockObject)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}