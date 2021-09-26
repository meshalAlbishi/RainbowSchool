using System;
using RainbowSchool.Classes;

namespace RainbowSchool.Formatter
{
    public static class TeacherFormatter
    {
        public static string FileFormat(Teacher teacher)
        {
            
            return teacher.ID + " " + teacher.Name;
        }

        public static string ConsoleFormat(Teacher teacher)
        {
            return String.Format("{0,-15}{1,-25}", teacher.ID, teacher.Name);
        }
    }
}
