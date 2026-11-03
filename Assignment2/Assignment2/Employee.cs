using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Employee
    {
        private decimal _salary;  
        public string Name {  get; set; }
        public int Age { get; set; }
        public decimal Salary      
        { get => _salary;
            set
            {
                if (value >= 0)
                    _salary = value;
                else
                    Console.WriteLine("Salary can't be negative");
            }
        } 

        public Employee (string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public virtual void DisplayInfo() 
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Monthly Salary: {Salary}");
            Console.WriteLine($"Annual Salary: {CalculateAnnualSalary()}");
        }
        public virtual decimal CalculateAnnualSalary()
        {
            return Salary * 12;
        }
    }
}
