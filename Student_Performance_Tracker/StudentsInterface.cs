using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal interface StudentsInterface
    {
        void isNullString(string student_Name);
        void isValidString(string student_Name);
        string RegularStudentGradeCalculator(int Student_ID, Hashtable StudentMark);
        string ExchangeStudentGradeCalculator(int Student_ID, Hashtable StudentMark);

    }

    public class StudentsMethods : StudentsInterface
    {
        public void isNullString(string student_Name)
        {
            if (string.IsNullOrWhiteSpace(student_Name))
            {
                throw new IsNullExpection("Name cannot be Empty");
            }
        }

        public void isValidString(string student_Name)
        {
            if (!Regex.IsMatch(student_Name, @"^[a-zA-Z .]+$"))
            {
                throw new IsValidStringExpection("Name must contains alphabets only not number and special characters");
            }
        }

        public string RegularStudentGradeCalculator(int Student_ID, Hashtable StudentMark)
        {
            int totalMark = 0;
            Subjects mark = (Subjects)StudentMark[Student_ID];
            totalMark += mark.Tamil;
            totalMark += mark.English;
            totalMark += mark.Maths;
            totalMark += mark.Science;
            totalMark += mark.Social;

            String Grade = "Empty";
            double Average = 0;
            Average = totalMark / 5;

            if (Average >= 90)
            {
                Grade = "A+";
            }
            else if (Average >= 80)
            {
                Grade = "A";
            }
            else if (Average >= 70)
            {
                Grade = "B";
            }
            else if (Average >= 60)
            {
                Grade = "C";
            }
            else if (Average >= 50)
            {
                Grade = "D";
            }
            else
            {
                Grade = "F";
            }
            return Grade;
        }


        public string ExchangeStudentGradeCalculator(int Student_ID, Hashtable StudentMark)
        {
            int totalMark = 0;
            Subjects mark = (Subjects)StudentMark[Student_ID];
            totalMark += mark.Tamil;
            totalMark += mark.English;
            totalMark += mark.Maths;
            totalMark += mark.Science;
            totalMark += mark.Social;

            string Grade = "Empty";

            int maxMark = 500;
            double Percentage = (totalMark / (double)maxMark) * 100;

            if (Percentage > 60)
            {
                Grade = "Pass";
            }
            else
            {
                Grade = "Fail";
            }

            return Grade;
        }


    }
}