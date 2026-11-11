namespace LINQ_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = LibraryData.BookList;
            var members = LibraryData.MemberList;

            #region Filtration
            // 1. All books instock > 0

            // Fleunt Syntax:
            var BookInStock = books.Where(b => b.CopiesInStock > 0);
            foreach (var book in BookInStock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            //Query Syntax
            var InStock = from b in books
                          where b.CopiesInStock > 0
                          select b;
            foreach (var book in InStock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");


            // 2. Programming books in stock

            // Fleunt Syntax
            var programmingBooks = books.Where(b => b.Genre == "Programming" && b.CopiesInStock > 0);
            foreach (var book in programmingBooks)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var programming_Books = from b in books
                                    where b.Genre == "Programming" && b.CopiesInStock > 0
                                    select b;
            foreach (var book in programming_Books)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // 3. Books with letter c

            // Fluent Syntax
            var BooksC = books.Where(b => b.Title.StartsWith("C"));
            foreach (var book in BooksC)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // Query Syntax 
            var Book_C = from b in books
                         where b.Title.StartsWith("C")
                         select b;
            foreach (var book in Book_C)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");
            #endregion

            #region Projection
            // 4. Book titles

            // Fleunt Syntax
            var title = books.Select(b => b.Title);
            foreach (var book in title)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var Title = from b in books
                        select b.Title;
            foreach (var book in Title)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            // 5. BookId & Title

            // Fleunt Syntax
            var titleAndId = books.Select(b => new { b.Title, b.BookId });
            foreach (var book in titleAndId)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var Title_Id = from b in books
                           select new { b.Title, b.BookId };
            foreach (var book in Title_Id)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            // 6. Print ID, Title, Genre

            // Fleunt Syntax
            var format = books.Select(b => $"[{b.BookId}] [{b.Title}] - [{b.Genre}]");
            foreach (var book in format)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var Format = from b in books
                         select $"[{b.BookId}] [{b.Title}] - [{b.Genre}]";
            foreach (var book in Format)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("===========================");

            #endregion

            #region SelectMany
            // 7. All loans of all members

            // Fleunt Syntax
            var loans = members.SelectMany(m => m.Loans);
            foreach (var loan in loans)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var Loans = from m in members
                        from l in m.Loans
                        select l;
            foreach (var loan in Loans)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // 8. Certain members

            // Fleunt Syntax 
            var certainLoans = members.Where(m => m.Id < 3).
                               SelectMany(m => m.Loans);
            foreach (var loan in certainLoans)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // Query Syntax 
            var CertainLoans = from m in members
                               where m.Id < 3
                               from l in m.Loans
                               select m;
            foreach (var loan in CertainLoans)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // 9. Solve 7 with regular select

            // Fleunt Syntax
            var loans_select = members.Select(m => m.Loans);
            foreach (var loan in loans_select)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // Query Syntax 
            var loans_Select = from m in members
                               select m.Loans;
            foreach (var loan in loans_select)
            {
                Console.WriteLine(loan);
            }
            Console.WriteLine("===========================");

            // Diference between IEnumerable<IEnumerable<Loan>> vs IEnumerable<Loan>
            // Select -> IEnumerable<IEnumerable<Loan>> (nested, needs 2 foreach).
            // SelectMany -> IEnumerable<Loan> (flat, needs 1 foreach).

            #endregion

            #region Execution Types

            #endregion
        }
    }
}
