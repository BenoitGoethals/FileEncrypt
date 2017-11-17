using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncrypter
{
    public class Starter
    {
        public static void  Main(string[] args)
        {
            
            CyptroManager cyptroManager=new CyptroManager("5dfdf");
            FileHelper.MakeStructure();
            var allFile = FileHelper.GetAllFile(FileHelper.InDirectory,Location.In);
            TaskFactory factory=new TaskFactory();
            
            foreach (var file in allFile)
            {
                Action function = () =>
                {
                    cyptroManager.AsynCyrptoFile(file);
                };
                
                factory.StartNew(function  );
                function.Invoke();
            }





            var allFileCr = FileHelper.GetAllFile(FileHelper.InDirectory,Location.Out);
        

            foreach (var file in allFile)
            {
                Action function = () =>
                {
                    cyptroManager.AsynDeCyrptoFile(file);
                };

                factory.StartNew(function);
                function.Invoke();
            }


            Console.ReadLine();
        }
    }
}