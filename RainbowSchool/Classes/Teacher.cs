using System;


namespace RainbowSchool.Classes
{
    public class Teacher
    {
        public readonly int ID;
        public string Name {get; set;}

        public Teacher(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }

        //Class and section
    }
}
