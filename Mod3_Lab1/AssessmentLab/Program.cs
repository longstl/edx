using System;

namespace AssessmentLab
{
    class Program
    {
        static void Main(string[] args)
        {
            GetStudentInformation();
            GetTeacherInformation();
            GetCourseInformation();
            GetProgramInformation();
            GetDegreeInformation();
        }

        static void GetStudentInformation()
        {
            Console.WriteLine("--- Student Information ---");
            Console.WriteLine("Enter the student's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the student's birthdate (DD/MM/YYYY):");
            string date = Console.ReadLine();
            DateTime birthday = validateLegalAge(date);
            DateTime birthDate = Convert.ToDateTime(birthday);

            bool isStudent = true;
            string isThisAStudent;
            if (isStudent)
            {
                isThisAStudent = "Student";
            }
            else
            {
                isThisAStudent = "Teacher";
            }

            int count = 01; 
            string formatStr = string.Format("ID{0:00000000}", count);

            PrintStudentDetails(isThisAStudent, count, firstName, lastName, birthDate);
        }

        static void PrintStudentDetails(string isThisAStudent, int count, string firstName, string lastName, DateTime birthDate)
        {
            Console.WriteLine("\r\n{0} Name: {1} {2}\r\nID number: {3}\r\nwas born in {4}.\r\n", isThisAStudent, firstName, lastName, count, birthDate.Year);
        }

        static void GetTeacherInformation()
        {
            Console.WriteLine("--- Teacher Information ---");
            Console.WriteLine("Enter the teacher's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the teacher's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the teacher's credentials: ");
            string credentials = Console.ReadLine();
            Console.WriteLine("Enter the teacher's class assignment: ");
            string classAssignment = Console.ReadLine();
            bool isStudent = false;
            string isThisAStudent;
            if (isStudent)
            {
                isThisAStudent = "Student";
            }
            else
            {
                isThisAStudent = "Teacher";
            }

            PrintTeacherDetails(isThisAStudent, firstName, lastName, credentials, classAssignment);
        }

        static void PrintTeacherDetails(string isThisAStudent, string firstName, string lastName, string credentials, string classAssignment)
        {
            Console.WriteLine("\r\n{0} Name: {1} {2}, {3}\r\nAssigned to class: {4}.\r\n", isThisAStudent, firstName, lastName, credentials, classAssignment);
        }

        static void GetCourseInformation()
        {
            Console.WriteLine("--- Course Information ---");
            Console.WriteLine("Enter the course name: ");
            string courseName = Console.ReadLine();
            Console.WriteLine("Enter the number of credits earned with successful completion of course: ");
            int courseCredits = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the number of courses required to complete program: ");
            int coursesRequired = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the associated degree name: ");
            string degreeName = Console.ReadLine();

            PrintCourseDetails(courseName, courseCredits, coursesRequired, degreeName);
        }

        static void PrintCourseDetails(string courseName, int courseCredits, int coursesRequired, string degreeName)
        {
            Console.WriteLine("\r\nCourse name: {0}\r\nCredits for course: {1}\r\nDegree Association: {2}\r\n", courseName, courseCredits, coursesRequired, degreeName);
        }

        static void GetProgramInformation()
        {
            // Capture program information input from application user.
            Console.WriteLine("--- Program Information ---");
            Console.WriteLine("Enter the program name: ");
            string programName = Console.ReadLine();
            Console.WriteLine("Enter the associated degree name: ");
            string degreeName = Console.ReadLine();
            Console.WriteLine("Enter the associated field of study name: ");
            string fieldName = Console.ReadLine();

            PrintProgramDetails(programName, degreeName, fieldName);
        }

        static void PrintProgramDetails(string programName, string degreeName, string fieldName)
        {
            Console.WriteLine("\r\nProgram name: {0}\r\nDegree Association: {1}\r\nField of study: {2}\r\n", programName, degreeName, fieldName);
        }

        static void GetDegreeInformation()
        {
            Console.WriteLine("--- Degree Information ---");
            Console.WriteLine("Enter the degree name: ");
            string degreeName = Console.ReadLine();
            Console.WriteLine("Enter the number of credits required to complete degree: ");
            int creditsRequired = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the associated school name (College of...): ");
            string collegeName = Console.ReadLine();

            PrintDegreeDetails(degreeName, creditsRequired, collegeName);
        }

        static void PrintDegreeDetails(string degreeName, int creditsRequired, string collegeName)
        {
            Console.WriteLine("\r\nDegree name: {0}\r\nNumber of credits for completion: {1}\r\nCollege of {2}.\r\n", degreeName, creditsRequired, collegeName);
        }


        static DateTime validateLegalAge(string date)
        {
            try
            {
                DateTime legalAge = DateTime.Parse(date);
                DateTime curDate = DateTime.Today;

                if (legalAge > curDate)
                {
                    Console.WriteLine("Invalid birth date provided");
                }
                if (legalAge.AddYears(18).CompareTo(DateTime.Today) > 0)
                {
                    int age = curDate.Year - legalAge.Year;

                    if (legalAge.Month > curDate.Month)
                    {
                        age--;
                    }

                    Console.WriteLine("The student not legal age.\r\nThe student's age is {0}", age);
                }
                else
                {
                    int age = curDate.Year - legalAge.Year;

                    if (legalAge.Month > curDate.Month)
                    {
                        age--;
                    }

                    Console.WriteLine("The student's age is {0}", age);
                    return legalAge;
                }

                return legalAge;
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "\r\nInvalid birthdate (DD/MM/YYYY) format.");
                return DateTime.Today;
            }
        }
    }
}