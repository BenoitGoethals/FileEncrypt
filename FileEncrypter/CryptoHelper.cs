using System;
using System.Security.Cryptography;
using System.Text;

namespace FileEncrypter
{
    public sealed class CryptoHelper : ICryptoHelper
    {


        public  string CyrptoKey { get; set; }
        // string key = "1prt56";
        public string Encrypt(String encryptval)
        {
            byte[] enctArray = Encoding.UTF8.GetBytes(encryptval);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            var srctArray = objcrpt.ComputeHash(Encoding.UTF8.GetBytes(CyrptoKey));
            objcrpt.Clear();
            objt.Key = srctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateEncryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(enctArray, 0, enctArray.Length);
            objt.Clear();
            return Convert.ToBase64String(resArray, 0, resArray.Length);
        }

        public string Decrypt(String decryptText)
        {
            byte[] drctArray = Convert.FromBase64String(decryptText);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
            var srctArray = objmdcript.ComputeHash(Encoding.UTF8.GetBytes(CyrptoKey));
            objmdcript.Clear();
            objt.Key = srctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateDecryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(drctArray, 0, drctArray.Length);
            objt.Clear();
            return Encoding.UTF8.GetString(resArray);
        }
    }
}