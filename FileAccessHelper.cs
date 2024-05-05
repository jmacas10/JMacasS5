using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMacasS5
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fielname) {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory,fielname);//ruta que recibe el archivo 
        }
    }
}
