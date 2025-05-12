using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal abstract class Students
    {
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_Type { get; set; }

        public Students(int Student_ID, string Student_Name, string Student_Type)
        {
            this.Student_ID = Student_ID;
            this.Student_Name = Student_Name;
            this.Student_Type = Student_Type;
        }

        public abstract void DisplayStudent();
    }
}