using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class Person
    {
        private int _age;
        public string Name { get; set; }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void DisplayRole()
        {
            Console.WriteLine($"{Name}(age {Age}) is a person");
        }
    }
    public class Student : Person
    {
        public Student(string name, int age): base(name, age)
        { }
        public override void DisplayRole()
        {
            Console.WriteLine($"{Name}(age {Age}) is a student");
        }
    }

    public class Librarian: Person
    {
        public Librarian(string name, int age) : base(name, age)
        { }
        public override void DisplayRole()
        {
            Console.WriteLine($"{Name}(age {Age}) is a librarian");
        }
    }
}
