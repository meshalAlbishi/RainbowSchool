using System;

namespace RainbowSchool.Classes
{
    public class Class
    {
        public readonly int ID;
        public string Name { get; set; }
        public string Section { get; set; }


        public Class(int ID, string name, string section)
        {
            this.ID = ID;
            this.Name = name;
            this.Section = section;
        }

      
       
    }
}
