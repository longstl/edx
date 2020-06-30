using System;
using System.Collections.Generic;
using System.Text;

namespace ModAssignment
{
    public class Student : Person
    {
        private static int Increment = 0;

        public Student(string name) : base(name)
        {
            Increment++;
        }

        public static int CountStudents()
        {
            return Increment;
        }
    }
}
