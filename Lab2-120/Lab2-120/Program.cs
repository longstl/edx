using System;

namespace Lab2_120
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employee1 = new Employee("Libby", 2000);
            var employee1 = new TechnicalEmployee("Libby");
            var employee2 = new TechnicalEmployee("Zaynah");
            var employee3 = new BusinessEmployee("Winter");

            // Output to the console window
            Console.WriteLine(employee1.employeeStatus() + "..." + employee2.employeeStatus() + "..." + employee3.employeeStatus());
        }
    }
}
