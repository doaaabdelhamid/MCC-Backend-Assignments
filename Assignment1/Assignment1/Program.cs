namespace Assignment1
{
    #region Person Class
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
         public Person (int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}";
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Value Type
            int x = 10;
            int y = 5;
            Console.WriteLine(x + "," + y); // 10, 5
            y = x;
            x = 20;
            Console.WriteLine(x + "," + y); // 20, 10

            // Why doesn’t changing x affect y?
            // int is a value type, y =x copies the value (10), so each variable has its own memory location.

            #endregion

            #region Reference Type
            Person p1 = new Person(1, "Doaa", "doaaabdelhamed117@gmail.com");
            Person p2 = new Person(2, "Ahmed", "ahmed145@gmail.com");
            Console.WriteLine(p1); // Id: 1, Name: Doaa, Email: doaaabdelhamed117@gmail.com
            Console.WriteLine(p2); // Id: 2, Name: Ahmed, Email: ahmed145@gmail.com
            p1 = p2;
            p1.Name = "Ali";
            Console.WriteLine(p1); // Id: 2, Name: Ali, Email: ahmed145@gmail.com
            Console.WriteLine(p2); // Id: 2, Name: Ali, Email: ahmed145@gmail.com

            //  Why do both variables display the same name?
            // Person is a reference type, p1 = p2 copies the reference not the object, Changing the object through one variable is seen through the other
            #endregion

            #region Object Reassignment
            p1 = new Person(3, "Sara", "sara294@gmail.com");
            Console.WriteLine(p1); // Id: 3, Name: Sara, Email: sara294@gmail.com
            Console.WriteLine(p2); // Id: 2, Name: Ali, Email: ahmed145@gmail.com

            // Does p2 change when p1 points to a new object? Explain why.
            // No. new creates a separate object and p1 points to it, p2 still points to the old object.
            #endregion

            #region Challenge
            Person p3 = p2;
            Console.WriteLine(p2); // Id: 2, Name: Ali, Email: ahmed145@gmail.com
            Console.WriteLine(p3); // Id: 2, Name: Ali, Email: ahmed145@gmail.com

            // What happens if you change p3.Email?
            // p2 is affected.
            // p2 and p3 reference the same object, so modifying the email in p3 changes it in p2 as well.
            p3.Email = "ali523@gmail.com";
            Console.WriteLine(p2); // Id: 2, Name: Ali, Email: ali523@gmail.com
            Console.WriteLine(p3); // Id: 2, Name: Ali, Email: ali523@gmail.com 

            //What happens if you assign a new object to p3?
            // p2 is not affected.
            // new creates a separate object and p3 points to it, p2 still points to the old object.
            p3 = new Person(5, "Abdullah", "abdullah34@gmail.com");
            Console.WriteLine(p2); // Id: 2, Name: Ali, Email: ali523@gmail.com
            Console.WriteLine(p3); // Id: 5, Name: Abdullah, Email: abdullah34@gmail.com
            #endregion


        }
    }
}
