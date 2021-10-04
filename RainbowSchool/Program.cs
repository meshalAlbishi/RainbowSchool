using System;
using RainbowSchool.Helpers;
using RainbowSchool.Classes;
using RainbowSchool.Formatter;
using RainbowSchool.Controller;
using System.Collections.Generic;

namespace RainbowSchool
{
    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();


        static void Main(string[] args)
        {
            try 
	        {	        
		        start();
                Console.ReadLine();
	        }
	        catch (Exception ex)
	        {
                Console.WriteLine("errrorr");
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
	        }
        }


        private static void start()
        {
            // initilaize teachers list
            teachers = new List<Teacher>();

            // read all the data from the file
            teachers = readDataFile();

            while (true) { 

                displayMenu();
                int choice = readMenuChoice();
                if (!validateMenuChoice(choice, 1, 5))
                {
                    Console.WriteLine("\t \n Wrong Selection, PLEASE choose from (1-5) !! \n");
                    continue;
                }

                processChoice(choice);
            }
        }


        private static List<Teacher> readDataFile()
        {

            List<string> lines = FileHandler.readFile();
            
            if(lines == null) { Environment.Exit(0); }
            
            foreach(string line in lines)
            {
                string[] lineData = line.Split();

                if(lineData.Length <= 1)
                {
                    continue;
                }

                Class c = ClassController.createClass(Int32.Parse(lineData[2].Trim()), lineData[3], lineData[4]);

                teachers.Add(TeacherController.createTeacher(Int32.Parse(lineData[0]), lineData[1], c));
            }

            return teachers;
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


        private static void processChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    displayAllTeachers();
                    break;
                // --------------
                case 2:
                    addTeacher();
                    break;
                // --------------
                case 3:
                    updateTeacher();
                    break;
                // --------------
                case 4:
                    deleteTeacher();
                    break;
                // --------------
                case 5:
                    exit();
                    break;
               // --------------
            }
        }


        private static void displayAllTeachers()
        {
            Console.WriteLine("\t------------------------------------------------------------------------------------------");
            Console.WriteLine(" \t ID\t\tTeacher Name\t\tClassID\t\tClass Name\t\tSection");
            Console.WriteLine("\t------------------------------------------------------------------------------------------");

            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine("\t " + TeacherFormatter.ConsoleFormat(teacher) + ClassFormatter.ConsoleFormat(teacher.c));
                Console.WriteLine("\t------------------------------------------------------------------------------------------");
            }

            Console.WriteLine("\n\n");
        }


        private static void addTeacher()
        {
            Console.WriteLine("\n");

            Console.Write("\t\tPlease Enter teacher name: ");
            string teacherName = Console.ReadLine();

            Console.Write("\t\tPlease Enter class name: ");
            string className = Console.ReadLine();

            Console.Write("\t\tPlease Enter section name: ");
            string sectionName = Console.ReadLine();

            Class c = ClassController.createClass(IdGenerator.generateID(), className, sectionName);
            Teacher teacher = TeacherController.createTeacher(IdGenerator.generateID(), teacherName, c);

            teachers.Add(teacher);

            Console.WriteLine($"\n\n Teacher {teacherName}, Added Successfully \n");
        }


        private static void updateTeacher()
        {
            Console.WriteLine("\n");

            displayAllTeachers();

            Console.Write("Please Enter Teacher ID to update: ");
            int ID = Int32.Parse(Console.ReadLine());

            bool isFound = false;
            foreach(Teacher t in teachers)
            {

                if(t.ID == ID)
                {                    

                    isFound = true;
                 
                    Console.Write("\t\tPlease Enter teacher updated name: ");
                    string teacherName = Console.ReadLine();

                    Console.Write("\t\tPlease Enter updated class name: ");
                    string className = Console.ReadLine();

                    Console.Write("\t\tPlease Enter updated section name: ");
                    string sectionName = Console.ReadLine();

                    t.Name = teacherName;
                    t.c.Name = className;
                    t.c.Section = sectionName;
                }
            }


            if (!isFound)
            {
                Console.WriteLine("No Teacher Found with the given ID :(");
                Console.WriteLine("");
            }

        }


        private static void deleteTeacher()
        {
            Console.WriteLine("\n");

            displayAllTeachers();

            Console.Write("Please Enter Teacher ID to update: ");
            int ID = Int32.Parse(Console.ReadLine());

            bool isFound = false;
            foreach(Teacher t in teachers)
            {
                if(t.ID == ID)
                {
                    isFound = true;
                    teachers.Remove(t);
                }
            }


            if (!isFound)
            {
                Console.WriteLine("No Teacher Found with the given ID :(");
                Console.WriteLine("");
            }

        }


        private static void exit()
        {
            if (!writeDataFile())
            {
                
                Console.WriteLine("Somthing Went Wrong While Save The Data :(");
                Console.WriteLine("Try Again Please");

                return;
            }

            Console.WriteLine("Thank you for your work :) !");
            Console.WriteLine("Good Bye");

            Environment.Exit(0);
        }
        

        private static bool writeDataFile()
        {
            List<string> dataLines = new List<string>();

            foreach(Teacher t in teachers)
            {
                dataLines.Add(TeacherFormatter.FileFormat(t) + " " + ClassFormatter.FileFormat(t.c));
            }

            Console.WriteLine(FileHandler.writeToFile(dataLines));
            return true;
        }
    }
}
