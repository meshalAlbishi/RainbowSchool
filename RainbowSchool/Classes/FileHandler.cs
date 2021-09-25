﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSchool.Classes
{
    public  class FileHandler
    {
        
        private static string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Data", "data.txt");
        //private static string filePath =  @"../Data/data.txt";

        public static List<string> readFile()
        {
            return File.ReadAllLines(filePath).ToList();
        }

        public static bool writeToFile(List<string> teachers)
        {
           
            try
            {
                File.WriteAllLines(filePath, teachers);

                return true;
            }
            catch(Exception e) 
            {
                return false; 
            }
           
        }

    }
}
