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
        public static void DisplayParticularStudDetails(int student_ID, Hashtable StudentsDetails)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine(
                $"{"Student ID",-15}" +
                $"{"Student Name",-25}" +
                $"{"Student Type",-25}" +
                $"{"Student Grade",-35}"
            );
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine();
            Students studentByID = (Students)StudentsDetails[student_ID];
            if (studentByID is RegularStudents r)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    $"{r.Student_ID,-15}" +
                    $"{r.Student_Name,-25}" +
                    $"{r.Student_Type,-25}" +
                    $"{r.RegularStudGrade,-35}"
                );
                Console.ResetColor();
                Console.WriteLine();
            }
            if (studentByID is ExchangeSudents e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"{e.Student_ID,-15}" +
                    $"{e.Student_Name,-25}" +
                    $"{e.Student_Type,-25}" +
                    $"{e.ExchangeStudGrade,-35}"
                );
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        public static void DisplayAllStudents(Hashtable StudentsDetails)
        {
            var SortedStudentDetails = StudentsDetails.Cast<DictionaryEntry>().OrderBy(x => x.Key);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine(
                $"{"Student ID",-15}" +
                $"{"Student Name",-25}" +
                $"{"Student Type",-25}" +
                $"{"Student Grade",-35}"
            );
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();



            foreach (DictionaryEntry i in SortedStudentDetails)
            {
                var details = i.Value;

                if (details is RegularStudents r)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"{r.Student_ID,-15}" +
                        $"{r.Student_Name,-25}" +
                        $"{r.Student_Type,-25}" +
                        $"{r.RegularStudGrade,-35}"
                    );
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (details is ExchangeSudents e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(
                        $"{e.Student_ID,-15}" +
                        $"{e.Student_Name,-25}" +
                        $"{e.Student_Type,-25}" +
                        $"{e.ExchangeStudGrade,-35}"
                    );
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        public static void DisplayParticularStudMark(Hashtable StudentMark, int Student_ID)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine(
                $"{"Tamil",-15}" +
                $"{"English",-20}" +
                $"{"Maths",-20}" +
                $"{"Science",-25}" +
                $"{"Social",-20}"
            );

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Subjects marks = (Subjects)StudentMark[Student_ID];
            Console.WriteLine(
                $"{marks.Tamil,-15}" +
                $"{marks.English,-20}" +
                $"{marks.Maths,-20}" +
                $"{marks.Science,-25}" +
                $"{marks.Social,-20}"
            );
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }



        public static int studId = 100;
        static void Main(string[] args)
        {
            Hashtable StudentsDetails = new Hashtable();     //For ID, Name, Type and Grade
            Hashtable StudentMark = new Hashtable();         //For ID, Subject Marks (Class)

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
                Console.WriteLine("                                     7. Exit                                                        ");

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
                    if (choice > 7)
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
                        catch (IsValidStringExpection e)
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
                        if (ch == 'R' || ch == 'r')
                        {
                            Student_Type = "Regular";
                        }
                        else if (ch == 'E' || ch == 'e')
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

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("             -------------- Now, enter the marks for 5 subjects here --------------                 ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
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

                        if (Student_Type == "Regular")
                        {
                            String RegularStudGrade = studentMethods.RegularStudentGradeCalculator(Student_ID, StudentMark);

                            RegularStudents regularStudents = new RegularStudents(Student_ID, Student_Name, Student_Type, RegularStudGrade);

                            regularStudents.DisplayStudent();

                            StudentsDetails.Add(Student_ID, regularStudents);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"{Student_ID} - Regular students have been successfully added.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        if (Student_Type == "Exchange")
                        {
                            String ExchangeStudGrade = studentMethods.ExchangeStudentGradeCalculator(Student_ID, StudentMark);

                            ExchangeSudents exchangeStudents = new ExchangeSudents(Student_ID, Student_Name, Student_Type, ExchangeStudGrade);

                            exchangeStudents.DisplayStudent();

                            StudentsDetails.Add(Student_ID, exchangeStudents);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"{Student_ID} - Exchange students have been successfully added.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("If you want to Continue to add the Students (Y/N) : ");
                        Console.ResetColor();
                        char Decision = char.Parse(Console.ReadLine());
                        if (Decision == 'Y' || Decision == 'y')
                        {
                            goto Student_Name;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Thank You for Adding Students");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              You Entered '2' to Update the Student                                 ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("---------------------------------- ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Here are all the students");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" --------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        DisplayAllStudents(StudentsDetails);

                        Console.WriteLine();

                    UpdateStudID:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the student ID to update: ");
                            Console.ResetColor();

                            int student_ID = int.Parse(Console.ReadLine());

                            if (!StudentsDetails.ContainsKey(student_ID))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student ID Not Found! Please enter a Valid ID as shown in the table above.");
                                Console.ResetColor();
                                goto UpdateStudID;
                            }

                            Student_ID = student_ID;

                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Student ID using digits only—no letters, symbols, or whitespace.");
                            Console.ResetColor();
                            goto UpdateStudID;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID. Please enter a valid Student ID.");
                            Console.ResetColor();
                            goto UpdateStudID;
                        }

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Here are the details of student ID - {Student_ID}");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine(
                            $"{"Student ID",-15}" +
                            $"{"Student Name",-25}" +
                            $"{"Student Type",-25}" +
                            $"{"Student Grade",-35}"
                        );
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        var details = StudentsDetails[Student_ID];

                        if (details is RegularStudents r)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(
                                $"{r.Student_ID,-15}" +
                                $"{r.Student_Name,-25}" +
                                $"{r.Student_Type,-25}" +
                                $"{r.RegularStudGrade,-35}"
                            );
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else if (details is ExchangeSudents e)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(
                                $"{e.Student_ID,-15}" +
                                $"{e.Student_Name,-25}" +
                                $"{e.Student_Type,-25}" +
                                $"{e.ExchangeStudGrade,-35}"
                            );
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"                  ----- Enter the choice to update student ID - {Student_ID} -----                 ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("                                1. Update the Student Name                                         ");
                        Console.WriteLine("                                2. Update the Student Type                                         ");
                        Console.WriteLine("                                3. Update the Student Mark                                         ");
                        Console.WriteLine("                                4. Finish Update                                                   ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"                  ----------------------------------------------------------------                 ");
                        Console.ResetColor();



                        while (true)
                        {
                            int ChoiceForUpdate = 0;
                        ChoiceForUpdate:
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter the Choice for Updating: ");
                                Console.ResetColor();
                                int choiceForUpdate = int.Parse(Console.ReadLine());
                                if (choiceForUpdate == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choice cannot be zero.");
                                    Console.ResetColor();
                                    goto ChoiceForUpdate;
                                }
                                if (choiceForUpdate > 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Choice must be between 1 and 3.");
                                    Console.ResetColor();
                                    goto ChoiceForUpdate;
                                }
                                ChoiceForUpdate = choiceForUpdate;
                                Console.WriteLine();
                            }
                            catch (FormatException e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Enter the choice using digits only—no letters, symbols, or whitespace.");
                                Console.ResetColor();
                                goto ChoiceForUpdate;
                            }
                            catch (OverflowException e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                Console.ResetColor();
                                goto ChoiceForUpdate;
                            }


                            String UpdateStudent_Name = "Empty";
                            string UpdateStudent_Type = "Empty";
                            switch (ChoiceForUpdate)
                            {
                                case 1:
                                UpdatedStudentName:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Student Name : ");
                                        Console.ResetColor();
                                        string updateStudent_Name = Console.ReadLine();
                                        studentMethods.isNullString(updateStudent_Name);
                                        studentMethods.isValidString(updateStudent_Name);
                                        UpdateStudent_Name = updateStudent_Name;

                                        if (StudentsDetails[Student_ID] is Students s)
                                        {
                                            s.Student_Name = UpdateStudent_Name;
                                        }
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"Student name for ID - {Student_ID} has been successfully updated");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedStudentName;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedStudentName;
                                    }



                                    break;

                                case 2:

                                UpdateStudentType:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Student Type : ");
                                        Console.ResetColor();
                                        string updateStudent_Type = Console.ReadLine();
                                        studentMethods.isNullString(updateStudent_Type);
                                        studentMethods.isValidString(updateStudent_Type);
                                        UpdateStudent_Type = updateStudent_Type;



                                        string UpdatedGrade = "Empty";
                                        if (updateStudent_Type == "Exchange")
                                        {
                                            UpdatedGrade = studentMethods.ExchangeStudentGradeCalculator(Student_ID, StudentMark);

                                            if (StudentsDetails[Student_ID] is Students s)
                                            {
                                                ExchangeSudents e = new ExchangeSudents(s.Student_ID, s.Student_Name, "Exchange", UpdatedGrade);
                                                StudentsDetails[Student_ID] = e;

                                            }
                                        }

                                        else if (updateStudent_Type == "Regular")
                                        {
                                            UpdatedGrade = studentMethods.RegularStudentGradeCalculator(Student_ID, StudentMark);

                                            if (StudentsDetails[Student_ID] is Students s)
                                            {
                                                RegularStudents r1 = new RegularStudents(s.Student_ID, s.Student_Name, "Regular", UpdatedGrade);
                                                StudentsDetails[Student_ID] = r1;

                                            }
                                        }

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"Student Type for ID - {Student_ID} has been successfully updated");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdateStudentType;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdateStudentType;
                                    }

                                    break;

                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"                              Here Student ID - {Student_ID} Marks                                 ");
                                    Console.ResetColor();
                                    Console.WriteLine();

                                    DisplayParticularStudMark(StudentMark, Student_ID);


                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("               ------ If you want to update the marks, choose an option below ------                ");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.WriteLine("                                Press '1' to update the Tamil mark.                                 ");
                                    Console.WriteLine("                                Press '2' to update the English mark.                               ");
                                    Console.WriteLine("                                Press '3' to update the Maths mark.                                 ");
                                    Console.WriteLine("                                Press '4' to update the Science mark.                               ");
                                    Console.WriteLine("                                Press '5' to update the Social mark.                                ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("               ---------------------------------------------------------------------                ");
                                    Console.ResetColor();
                                    Console.WriteLine();

                                    int UpdateMarkChoice = 0;
                                UpdateMarkChoice:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Choice for Updating Marks: ");
                                        Console.ResetColor();
                                        int updateMarkChoice = int.Parse(Console.ReadLine());
                                        if (updateMarkChoice == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Choice cannot be zero.");
                                            Console.ResetColor();
                                            goto UpdateMarkChoice;
                                        }
                                        if (updateMarkChoice > 5)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Choice must be between 1 and 5.");
                                            Console.ResetColor();
                                            goto UpdateMarkChoice;
                                        }
                                        UpdateMarkChoice = updateMarkChoice;
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Enter the choice using digits only—no letters, symbols, or whitespace.");
                                        Console.ResetColor();
                                        goto UpdateMarkChoice;
                                    }
                                    catch (OverflowException e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                                        Console.ResetColor();
                                        goto UpdateMarkChoice;
                                    }

                                    Subjects updateMark = (Subjects)StudentMark[Student_ID];
                                    if (UpdateMarkChoice == 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Tamil Mark     : ");
                                        Console.ResetColor();
                                        updateMark.Tamil = int.Parse(Console.ReadLine());

                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Tamil mark has been updated successfully");
                                        Console.WriteLine();
                                    }
                                    else if (UpdateMarkChoice == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated English Mark   : ");
                                        Console.ResetColor();
                                        updateMark.English = int.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("English mark has been updated successfully");
                                        Console.WriteLine();
                                    }
                                    else if (UpdateMarkChoice == 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Maths Mark     : ");
                                        Console.ResetColor();
                                        updateMark.Maths = int.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Maths mark has been updated successfully");
                                        Console.WriteLine();
                                    }
                                    else if (UpdateMarkChoice == 4)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Science Mark   : ");
                                        Console.ResetColor();
                                        updateMark.Science = int.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Science mark has been updated successfully");
                                        Console.WriteLine();
                                    }
                                    else if (UpdateMarkChoice == 5)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Social Mark    : ");
                                        Console.ResetColor();
                                        updateMark.Social = int.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Social mark has been updated successfully");
                                        Console.WriteLine();
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("If you want to Continue updating the Marks (Y/N) : ");
                                    Console.ResetColor();
                                    char decision = char.Parse(Console.ReadLine());
                                    if (decision == 'Y' || decision == 'y')
                                    {
                                        goto UpdateMarkChoice;
                                    }
                                    else if (decision == 'N' || decision == 'n')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("Thank You...!!");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();

                                    if (StudentsDetails[Student_ID] is RegularStudents)
                                    {
                                        string updatedRegularGrade = studentMethods.RegularStudentGradeCalculator(Student_ID, StudentMark);
                                        if (StudentsDetails[Student_ID] is Students s)
                                        {
                                            RegularStudents regular = new RegularStudents(s.Student_ID, s.Student_Name, "Regular", updatedRegularGrade);
                                            StudentsDetails[Student_ID] = regular;
                                        }
                                    }


                                    ExchangeSudents TypeExchange = (ExchangeSudents)StudentsDetails[Student_ID];
                                    if (TypeExchange.Student_Type == "Exchange")
                                    {
                                        string updatedExchangeGrade = studentMethods.ExchangeStudentGradeCalculator(Student_ID, StudentMark);
                                        if (StudentsDetails[Student_ID] is Students s)
                                        {
                                            ExchangeSudents exchange = new ExchangeSudents(s.Student_ID, s.Student_Name, "Exchange", updatedExchangeGrade);
                                            StudentsDetails[Student_ID] = exchange;
                                        }
                                    }


                                    break;

                                case 4:
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Thank You for Updating..!!");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    break;
                            }

                            if (ChoiceForUpdate == 4)
                            {
                                break;
                            }
                        }
                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                                You Enter '3' for Deleting the Student                             ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    DeleteStudentID:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the student ID to update: ");
                            Console.ResetColor();

                            int student_ID = int.Parse(Console.ReadLine());

                            if (!StudentsDetails.ContainsKey(student_ID))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student ID Not Found! Please enter a Valid ID as shown in the table above.");
                                Console.ResetColor();
                                goto DeleteStudentID;
                            }

                            StudentsDetails.Remove(student_ID);
                            StudentMark.Remove(student_ID);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Student ID - {student_ID} has been deleted successfully.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Student ID using digits only—no letters, symbols, or whitespace.");
                            Console.ResetColor();
                            goto DeleteStudentID;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID. Please enter a valid Student ID.");
                            Console.ResetColor();
                            goto DeleteStudentID;
                        }
                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;


                    case 4:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                       You Enter '4' for Seaarch the Particular the Student                         ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    SearchStudentID:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the student ID to update: ");
                            Console.ResetColor();

                            int student_ID = int.Parse(Console.ReadLine());

                            if (!StudentsDetails.ContainsKey(student_ID))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Student ID Not Found! Please enter a Valid ID as shown in the table above.");
                                Console.ResetColor();
                                goto SearchStudentID;
                            }
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"                            Here are the details of Student ID {student_ID}                      ");
                            Console.ResetColor();
                            Console.WriteLine();

                            DisplayParticularStudDetails(student_ID, StudentsDetails);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"                              Here are the Mark of Student ID {student_ID}                        ");
                            DisplayParticularStudMark(StudentMark, student_ID);

                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Student ID using digits only—no letters, symbols, or whitespace.");
                            Console.ResetColor();
                            goto SearchStudentID;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID. Please enter a valid Student ID.");
                            Console.ResetColor();
                            goto SearchStudentID;
                        }

                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;



                    case 5:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                            You Enter '5' for Display all the Student                               ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        DisplayAllStudents(StudentsDetails);

                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;


                    case 6:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                            You Enter '5' for Display all the Student                               ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        int A_PluseCount = 0;
                        int A_Count = 0;
                        int B_Count = 0;
                        int C_Count = 0;
                        int D_Count = 0;
                        int F_Count = 0;

                        int Pass_Count = 0;
                        int Fail_Count = 0;

                        foreach (DictionaryEntry i in StudentsDetails)
                        {
                            var studDetails = i.Value;

                            if (studDetails is RegularStudents regular)
                            {
                                if (regular.RegularStudGrade == "A+")
                                {
                                    A_PluseCount++;
                                }
                                else if (regular.RegularStudGrade == "A")
                                {
                                    A_Count++;
                                }
                                else if (regular.RegularStudGrade == "B")
                                {
                                    B_Count++;
                                }
                                else if (regular.RegularStudGrade == "C")
                                {
                                    C_Count++;
                                }
                                else if (regular.RegularStudGrade == "D")
                                {
                                    D_Count++;
                                }
                                else if (regular.RegularStudGrade == "F")
                                {
                                    F_Count++;
                                }
                            }

                            if (studDetails is ExchangeSudents exchange)
                            {
                                if (exchange.ExchangeStudGrade == "Pass")
                                {
                                    Pass_Count++;
                                }
                                if (exchange.ExchangeStudGrade == "Fail")
                                {
                                    Fail_Count++;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                     ------------ Students Performance Summary------------                         ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                Regular Students Grade Summary                                     ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade A+ : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{A_PluseCount} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade A  : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{A_Count} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade B  : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{B_Count} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade C  : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{C_Count} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade D  : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{D_Count} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade F  : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{F_Count} Students");

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                     =====================================================                         ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                Exchange Students Grade Summary                                    ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade Pass : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{Pass_Count} Students");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                        Grade Fail : ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{Fail_Count} Students");

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                     -----------------------------------------------------                         ");
                        Console.ResetColor();

                        Console.WriteLine("Press Any Key to Continue.....");
                        Console.ReadKey(true);
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("                     You Choose to Exist :)                  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();

                        for (int i = 5; i > 0; i--)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("                 Existing From Grocery: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" {i} ");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                        }
                        break;
                }
                if (Choice == 7)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                      ~ * Thank You * ~                    ");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
            }

        }
    }
}