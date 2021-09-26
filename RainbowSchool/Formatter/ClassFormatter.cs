using System;
using RainbowSchool.Classes;

namespace RainbowSchool.Formatter
{
    public static class ClassFormatter
    {
        public static string FileFormat(Class c)
        {
            return c.ID + " " + c.Name + " " + c.Section;
        }

        public static string ConsoleFormat(Class c)
        {
            return String.Format("{0,-15}{1,-25}{2}", c.ID, c.Name, c.Section);
        }
    }
}
