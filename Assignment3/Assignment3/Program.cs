namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Student("Doaa", 20);
            Person p2 = new Librarian("Noor", 22);
            p1.DisplayRole();
            p2.DisplayRole();
            Console.WriteLine("================================");

            LibraryItem book = new Book("Animal Farm", 2);
            LibraryItem magazine = new Magazine("Insight", 4);
            Console.WriteLine(book.GetDetails());
            Console.WriteLine(magazine.GetDetails());
            Console.WriteLine("================================");

            Library library = new Library();
            library.AddBooks(new Book("1984", 1));
            library.AddBooks(new Book("Robinson Crusoe", 3));
            library.DisplayBooks();


        }
    }
}
