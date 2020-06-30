using System;
using System.Collections.Generic;
using System.Text;

namespace ModAssignment
{
    class Course
    {
        string CourseName { get; set; }
        Teacher[] Teacher { get; set; }
        Teacher[] TeacherAssitant { get; set; }
        Student[] Student { get; set; }

        public Course(string name)
        {
            this.CourseName = name;
            this.Teacher = new Teacher[2];
            this.TeacherAssitant = new Teacher[2];
            this.Student = new Student[40];
        }

        public void AddTeacher(Teacher teacher)
        {
            for (int i = 0; i < this.Teacher.Length; i++)
            {
                if (this.Teacher[i] == null)
                {
                    this.Teacher[i] = teacher;
                    break;
                }
            }
        }

        public void AddAssistent(Teacher teacher)
        {
            for (int i = 0; i < this.TeacherAssitant.Length; i++)
            {
                if (this.TeacherAssitant[i] == null)
                {
                    this.TeacherAssitant[i] = teacher;
                    break;
                }
            }
        }

        public void AddStudent(Student student)
        {
            for (int i = 0; i < this.Student.Length; i++)
            {
                if (this.Student[i] == null)
                {
                    this.Student[i] = student;
                    break;
                }
            }
        }

        public string Name()
        {
            return this.CourseName;
        }

        public int StudentCount()
        {

            int nonNullStudents = 0;
            for (int i = 0; i < this.Student.Length; i++)
            {
                if (this.Student[i] != null)
                {
                    nonNullStudents = nonNullStudents + 1;
                }
            }

            return nonNullStudents;
        }

        public Course CourseInfo()
        {
            return this;
        }
    }
}
