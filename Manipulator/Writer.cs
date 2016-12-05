using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulator
{
    static class Writer
    {

        private static string path;
        private static object obj;

        static Writer()
        {
            path = "log.txt";
            obj = new object();
            if (File.Exists(path))
                File.Delete(path);
        }

        static public void Write(string text)
        {

            lock (obj)
            {
                using (var writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
