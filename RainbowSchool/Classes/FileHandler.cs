using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RainbowSchool.Classes
{
    public  class FileHandler
    {

        // private static string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Data", "data.txt");
        private static string filePath = @"data.txt";


        public static List<string> readFile()
        {
            if (!File.Exists(filePath))
            {
                    Console.WriteLine("File Not Exists");
                    return null;
            }

            //Console.WriteLine();
            return File.ReadAllText(filePath).Split("\n").ToList();
        }

        public static bool writeToFile(List<string> teachers)
        {
           
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                foreach (String t in teachers) { 

                    byte[] buffer = Encoding.ASCII.GetBytes(t + "\n");
                    fs.Write(buffer, 0, buffer.Length);
                }

                fs.Flush();
                fs.Close();

                return true;
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                return false; 
            }
           
        }

    }
}
