using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Student_Performance_Tracker
{
    public class IsNullExpection : Exception
    {
        public IsNullExpection(string message) : base(message) { }
    }

    public class IsValidStringExpection : Exception
    {
        public IsValidStringExpection(string message) : base(message) { }
    }
    public class Program
    {
        
        public static int studId = 100;
        static void Main(string[] args)
        {
            Hashtable StudentsDetails = new Hashtable();  //For ID, Name, Type and Grade
            Hashtable StudentMark = new Hashtable();      //For ID, Subject Marks (Class)

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------------------------------------ Student Performance Tracker -----------------------------------");
                Console.WriteLine("||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("                                     1. Addling the Students                                        ");
                Console.WriteLine("                                     2. Updating the Student By ID                                  ");
                Console.WriteLine("                                     3. Delete the Student                                          ");
                Console.WriteLine("                                     4. Search the Student By ID                                    ");
                Console.WriteLine("                                     5. Display ALl the Students                                    ");
                Console.WriteLine("                                     6. View the Number of Students (Exchange / Regular) in each Grade");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                int Choice = 0;

                Choice:
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Choice : ");
                    Console.ResetColor();
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choice cannot be zero.");
                        Console.ResetColor();
                        goto Choice;
                    }
                    if (choice > 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choice must be between 1 and 6.");
                        Console.ResetColor();
                        goto Choice;
                    }
                    Choice = choice;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the choice using digits only—no letters, symbols, or whitespace.");
                    Console.ResetColor();
                    goto Choice;
                }
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    Console.ResetColor();
                    goto Choice;
                }

                StudentsInterface studentMethods = new StudentsMethods();

                int Student_ID = 0;
                string Student_Name = "Empty";
                string Student_Type = "Empty";

                switch (Choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                               You Enter '1' for Adding the New Student                             ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Student_Name:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Student Name : ");
                            Console.ResetColor();
                            string student_Name = Console.ReadLine();
                            studentMethods.isNullString(student_Name);
                            studentMethods.isValidString(student_Name);
                            Student_Name = student_Name;    
                        }
                        catch (IsNullExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto Student_Name;
                        }
                        catch(IsValidStringExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto Student_Name;
                        }

                        Decision:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter the Stduent Type ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press 'R' for Regular Student / Press 'E' for Exchange Student : ");
                        Console.ResetColor();
                        char ch = char.Parse(Console.ReadLine());   
                        if(ch == 'R' || ch == 'r')
                        {
                            Student_Type = "Regular";
                        }
                        else if(ch == 'E' || ch == 'e')
                        {
                            Student_Type = "Exchange";
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Dicision Properly");
                            Console.ResetColor();
                            goto Decision;
                        }

                        studId++;
                        Student_ID = studId;

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("             -------------- Now, enter the marks for 5 subjects here --------------                 ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.Write("                           Enter the Tamil Mark        : ");
                        Console.ResetColor();
                        int tamil = int.Parse(Console.ReadLine());
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                           Enter the English Mark      : ");
                        Console.ResetColor();
                        int english = int.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                           Enter the Maths Mark        : ");
                        Console.ResetColor();
                        int maths = int.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                           Enter the Science Mark      : ");
                        Console.ResetColor();
                        int science = int.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                           Enter the Social Mark       : ");
                        Console.ResetColor();
                        int social = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("            ------------------------------------------------------------------------               ");
                        Console.ResetColor();
                        Console.WriteLine();


                        Subjects subjects = new Subjects();
                        subjects.Tamil = tamil;
                        subjects.English = english;
                        subjects.Maths = maths;
                        subjects.Science = science;
                        subjects.Social = social;

                        StudentMark.Add(Student_ID, subjects);

                        if(Student_Type == "Regular")
                        {
                            String RegularStudGrade = studentMethods.RegularStudentGradeCalculator(Student_ID, StudentMark);

                            RegularStudents regularStudents = new RegularStudents(Student_ID, Student_Name, Student_Type, RegularStudGrade);

                            regularStudents.DisplayStudent();

                            StudentsDetails.Add(Student_ID,regularStudents);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"{Student_ID} - Regular students have been successfully added.");
                            Console.ResetColor();

                        }

                        if(Student_Type == "Exchange")
                        {
                            String ExchangeStudGrade = studentMethods.ExchangeStudentGradeCalculator(Student_ID, StudentMark);

                            ExchangeSudents exchangeStudents = new ExchangeSudents(Student_ID, Student_Name, Student_Type, ExchangeStudGrade);

                            exchangeStudents.DisplayStudent();

                            StudentsDetails.Add(Student_ID, exchangeStudents);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"{Student_ID} - Exchange students have been successfully added.");
                            Console.ResetColor();
                        }

                        break;
                        

                }


            }

        }
    }
}