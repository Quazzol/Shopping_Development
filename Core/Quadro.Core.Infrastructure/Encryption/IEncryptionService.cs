namespace Quadro.Core.Infrastructure.Encryption;

public interface IEncryptionService
{
  string Encrypt( string unencrypted);
  string Decrypt(string encrypted);

}