using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_120
{
    abstract class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public int ID { get; set; }
        private static int employeeCount = 1;

        public Employee(string name, double baseSalary)
        {
            this.ID = employeeCount++;
            Name = name;
            BaseSalary = baseSalary;
        }

        public double getBaseSalary()
        {
            return this.BaseSalary;
        }

        public String getName()
        {
            return this.Name;
        }

        public int getEmployeeID()
        {
            return this.ID;
        }

        public String toString()
        {
            return this.ID + " " + this.Name;
        }

        //public virtual String employeeStatus()
        //{
        //    return toString() + " is in the company's system";
        //}

        public abstract String employeeStatus();
    }
}
