using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypter
{
    public class FileHelper
    {
        
        
        public static string InDirectory { get; set; } = "c:/fileManager/cyr";
        

        public static  void MakeStructure()
        {
            if (!Directory.Exists(InDirectory))
            {
                Directory.CreateDirectory(InDirectory+"/in");
                Directory.CreateDirectory(InDirectory+"/out");
            }
           

        }

         

       

        public static string[] GetAllFile(string director,Location location)
        {
            string[] ret = Directory.GetFiles(director+(location==Location.In?"/in":"/out"));

            return ret;
        }


    

        

        public void Process(string fileName, string outPath,   CyptroManager.CyrtoFun cyrtoFun)
        {// @"\..\out\"
            lock (fileName)
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                   
                    StreamWriter output=default(StreamWriter);
                    try
                    {
                       
                        using ( output = new StreamWriter(Path.GetDirectoryName(fileName) + outPath + Path.GetFileName(fileName), true)) //File.OpenText(directory + "/" + Path.GetFileName(fileName)))
                        {
                            //  output.AutoFlush = true;
                            string s = String.Empty;

                            while ((s = sr.ReadLine()) != null)
                            {

                                output.Write(cyrtoFun(s));
                                output.Flush();

                            }
                            output.Close();
                        }
                    }
                    catch (IOException e)
                    {
                        output?.Close();
                        /*   if (File.Exists(Path.GetDirectoryName(fileName) + outPath + Path.GetFileName(fileName)))
                        {
                            File.Delete(Path.GetDirectoryName(fileName) + outPath + Path.GetFileName(fileName));
                        }*/
                    }
                    sr.Close();
                   
                }
            }
        }


    }
}
