namespace Assignment2
{
    public class Program
    {
        static void Main(string[] args)
        {
           Employee emp1 = new Employee("Doaa", 21, 20000m);
           Employee emp2 = new Employee("Noor", 23, 25000m);
           Manager mgr = new Manager("Ahmed", 30, 45000m, 10000m);

            emp1.DisplayInfo();
            Console.WriteLine("=======================================");
            emp2.DisplayInfo();
            Console.WriteLine("=======================================");
            mgr.DisplayInfo();
            Console.WriteLine("=======================================");

            emp1.Salary = -12000m;
            //Console.WriteLine($"Salary after negative attempt: {emp1.Salary}");

        }
    }
}
