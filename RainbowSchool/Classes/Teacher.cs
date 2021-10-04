using System;


namespace RainbowSchool.Classes
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name {get; set;}
        public Class c { get; set; }

        public Teacher(int ID, string Name, Class c)
        {
            this.ID = ID;
            this.Name = Name;
            this.c = c;
        }

        //Class and section
    }
}
