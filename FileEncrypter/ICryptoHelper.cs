namespace FileEncrypter
{
    public interface ICryptoHelper
    {
        string CyrptoKey { get; set; }

        string Decrypt(string decryptText);
        string Encrypt(string encryptval);
    }
}