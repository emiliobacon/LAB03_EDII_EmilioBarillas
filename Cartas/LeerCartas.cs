using System;
using System.IO;

namespace Laboratorio01.Cartas
{
    public class LeerCartas
    {
        public static string Leer(long dpi)
        {
            string path = @"/Users/emilio/Desktop/caso talent hub/wwwroot/files/REC-" + dpi.ToString() + "-1.txt";

            // This text is added only once to the file.
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string createText = "Hello and Welcome" + Environment.NewLine;
            //    File.WriteAllText(path, createText);
            //}
            
            // Open the file to read from.
            string readText = File.ReadAllText(path);

            return readText;
            
        }
    }
}

