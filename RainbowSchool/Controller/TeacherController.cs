using System;
using RainbowSchool.Classes;


namespace RainbowSchool.Controller
{
    public static class TeacherController
    {
        
        public static Teacher createTeacher(int ID, string name, Class c)
        {
            return new Teacher(ID, name, c);
        }

        public static Teacher updateTeacher(int ID, string name, Class c)
        {
            return new Teacher(ID, name, c);
        }
    }
}
