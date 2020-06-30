using System;
using System.Collections.Generic;
using System.Text;

namespace ModAssignment
{
    class Degree
    {
        string DegreeName { get; set; }

        Course[] Courses { get; set; }

        public Degree(string name)
        {
            this.DegreeName = name;
            this.Courses = new Course[10];
        }

        public string Name()
        {
            return this.DegreeName;
        }

        public string AllCourses()
        {
            string allCourses = "";
            for (int i = 0; i < this.Courses.Length; i++)
            {
                if (this.Courses[i] != null)
                {
                    allCourses = allCourses + this.Courses[i].Name() + ", ";
                }
            }
            return allCourses;
        }

        public void AddCourse(Course course)
        {
            for (int i = 0; i < this.Courses.Length; i++)
            {
                if (this.Courses[i] == null)
                {
                    this.Courses[i] = course;
                    break;
                }
            }
        }
    }
}
