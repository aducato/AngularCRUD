using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.DataModel
{
    public class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }

        public DateTime dob { get; set; }


    }
}
