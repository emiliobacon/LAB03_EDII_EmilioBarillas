using System;
using System.IO;

namespace Laboratorio01.Cartas
{
    public class LeerCartas
    {
        public static string Leer(long dpi)
        {
            string path = @"/Users/emilio/Desktop/caso talent hub/wwwroot/files/REC-" + dpi.ToString() + "-1.txt";

            
            if (!File.Exists(path))
            {
                string error = "error";
                return error; 
            }

            // Open the file to read from.
            string readText = File.ReadAllText(path);

            return readText;
            
        }
    }
}

