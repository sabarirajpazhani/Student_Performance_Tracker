using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class ExchangeSudents : Students
    {
        public string ExchangeStudGrade { get; set; }

        public ExchangeSudents(int Student_ID, string Student_Name, string Student_Type, string ExchangeStudGrade) : base(Student_ID, Student_Name, Student_Type)
        {
            this.ExchangeStudGrade = ExchangeStudGrade;
        }

        public override void DisplayStudent()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("                         -------------- Registed Student --------------                             ");
            Console.ResetColor();
            Console.WriteLine($"                             Student ID          : {Student_ID}");
            Console.WriteLine($"                             Student Name        : {Student_Name}");
            Console.WriteLine($"                             Student Type        : {Student_Type}");
            Console.WriteLine($"                             Grade               : {ExchangeStudGrade}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                        ----------------------------------------------");
            Console.ResetColor();
        }
    }
}