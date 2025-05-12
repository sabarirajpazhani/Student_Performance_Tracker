using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class RegularStudents : Students
    {
        public string RegularStudGrade { get; set; }

        public RegularStudents(int Student_ID, string Student_Name, string Student_Type, string RegularStudGrade) : base(Student_ID, Student_Name, Student_Type)
        {
            this.RegularStudGrade = RegularStudGrade;
        }

        public override void DisplayStudent()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                         -------------- Registed Student --------------                             ");
            Console.ResetColor();
            Console.WriteLine($"                               Student ID          : {Student_ID}");
            Console.WriteLine($"                               Student Name        : {Student_Name}");
            Console.WriteLine($"                               Student Type        : {Student_Type}");
            Console.WriteLine($"                               Grade               : {RegularStudGrade}");
            Console.WriteLine("                        ----------------------------------------------");
        }
    }
}