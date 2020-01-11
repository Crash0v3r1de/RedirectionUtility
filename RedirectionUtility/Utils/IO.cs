using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedirectionUtility.Utils
{
    public static class IO 
    {
        public static string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
        public static bool FolderPresent(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else return false;
        }
        public static bool CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool FilePresent(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else return false;
        }
        public static bool CreateFile(string path,List<string> data = null)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    if (data != null)
                    {
                        foreach (var st in data)
                        {
                            sw.WriteLine(st);
                        }
                    }
                    else
                    {
                        sw.Write(""); // Blank file of nothing
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
