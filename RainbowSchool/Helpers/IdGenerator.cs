using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSchool.Helpers
{
    public static class IdGenerator
    {

        public static int idGenerator()
        {
            Random rnd = new Random();
            return rnd.Next(100, 10000);
        }
    }
}
