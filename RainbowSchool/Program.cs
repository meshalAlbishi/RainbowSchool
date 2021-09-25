using RainbowSchool.Classes;
using System;
using System.Collections.Generic;

namespace RainbowSchool
{
    class Program
    {
        static List<string> teachers;

        static void Main(string[] args)
        {
            start();

            Console.ReadLine();
        }

        private static void start()
        {
            // read all the data from the file
            teachers = FileHandler.readFile();

            while (true) { 
                displayMenu();
                int choice = readMenuChoice();
                if (!validateMenuChoice(choice, 1, 5))
                {
                    Console.WriteLine("\t \n Wrong Selection, PLEASE choose from (1-5) !! \n");
                    continue;
                }


            }
        }


        private static void displayMenu()
        {
            Console.WriteLine("\t ---------- Welcome to Teacher Management System ----------");
            
            Console.WriteLine("\t 1. Display All Teachers");
            Console.WriteLine("\t 2. Add New Teacher");
            Console.WriteLine("\t 3. Update Teacher");
            Console.WriteLine("\t 4. Delete Teacher");
            Console.WriteLine("\t 5. Exit :( ");
            Console.WriteLine("\t ---------- ---------- ----------");
            Console.Write("\t Please Choose From (1 - 5): ");
            // Console.WriteLine("\t ---------- ---------- ---------- ---------- ---------- ----------");
        }


        private static int readMenuChoice()
        {
            return Int32.Parse(Console.ReadLine());
        }

        private static bool validateMenuChoice(int choice, int min, int max)
        {
            return choice >= min && choice <= max;
        }


    }
}
