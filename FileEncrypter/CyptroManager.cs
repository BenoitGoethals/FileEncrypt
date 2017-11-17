using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Text.UTF8Encoding;

namespace FileEncrypter
{
    public sealed class CyptroManager: ICyptroManager
    {

        private readonly FileHelper _fileHelper = new FileHelper();

        public delegate string CyrtoFun(String file);

        private readonly ICryptoHelper _cryptoHelpe=new CryptoHelper();


        public CyptroManager(string key)
        {
            _cryptoHelpe.CyrptoKey = key;

        }


      
      
        public void AsynCyrptoFile(string file)
        {
            lock (file)
            {
              
                _fileHelper.Process(file, @"\..\out\",_cryptoHelpe.Encrypt);
            }

        }
        

        public void AsynDeCyrptoFile(string file)
        {
            {
                _fileHelper.Process(file, @"\..\in\", _cryptoHelpe.Decrypt);
            }
        }

     
    }
}