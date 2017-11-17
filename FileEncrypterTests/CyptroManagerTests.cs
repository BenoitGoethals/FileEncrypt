using System;
using System.Threading;
using System.Threading.Tasks;
using FileEncrypter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileEncrypterTests
{
    [TestClass()]
    public class CyptroManagerTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            /*
            ICyptroManager cyptroManager=new CyptroManager(){CyrptoKey = "1prt56" };

            string orginal = "test";
            string output=cyptroManager.Encrypt(orginal);
            string output2 = cyptroManager.Decrypt(output);
            Assert.IsTrue(output2.Equals(orginal));*/

        }

        [TestMethod()]
        public void EncryptBigTest()
        {
       /*     TaskFactory factory=new TaskFactory();
            ICyptroManager cyptroManager = new CyptroManager() { CyrptoKey = "1prt56" };

            string orginal = GenerateString();
            Task<string> task = new Task<string>(() => cyptroManager.Encrypt(orginal));
            Task<string> task2 = new Task<string>(() => cyptroManager.Decrypt(task.Result));
            task.Start();
            Task.WaitAll();
            task2.Start();
            Task.WaitAll();
            Assert.IsTrue(orginal.Equals(task2.Result));
            */
        }



        private string GenerateString()
        {
            Random random=new Random();
            string output="";
            for (int i = 0; i < 10000; i++)
            {
                output += char.ConvertFromUtf32(random.Next(1000));
            }



            return output;
        }
    }
}