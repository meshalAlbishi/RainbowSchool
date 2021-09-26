using System;
using RainbowSchool.Classes;

namespace RainbowSchool.Controller
{
    public static class ClassController
    {
        public static Class createClass(int ID, string name, string section)
        {
            return new Class(ID, name, section);
        }
    }
}
