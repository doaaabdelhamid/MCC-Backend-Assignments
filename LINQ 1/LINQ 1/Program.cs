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
            // 10. Where Query, Add

            // Fleunt Syntax
            var copiesInStock = books.Where(b => b.CopiesInStock > 0);
            books.Add(new Book { BookId = 41, Title = "New Book F", Genre = "Programming", Price = 30.5000m, CopiesInStock = 5 });
            foreach (var book in copiesInStock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");
            // Query Syntax
            var CopiesInStock = from b in books
                                where b.CopiesInStock > 0
                                select b;
            books.Add(new Book { BookId = 42, Title = "New Book Q", Genre = "Programming", Price = 35.5000m, CopiesInStock = 7 });
            foreach (var book in CopiesInStock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // Yes, new book appears because the query runs when I loop over it
            // (foreach), so it sees the list as it is at that moment.

            // Deferred execution: because nothing runs until the foreach, so the new book is included.


            // 11. ToList()

            // Fleunt Syntax  
            var inStock = books.Where(b => b.CopiesInStock > 0).ToList();
            books.Add(new Book { BookId = 43, Title = "New_Book F", Genre = "Programming", Price = 20.5000m, CopiesInStock = 4 });
            foreach (var book in inStock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var In_Stock = (from b in books
                           where b.CopiesInStock > 0
                           select b).ToList();
            books.Add(new Book { BookId = 44, Title = "New_Book Q", Genre = "Programming", Price = 25.5000m, CopiesInStock = 9 });
            foreach(var book in In_Stock)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // NO, the book doesn't appear because ToList() forces the query to run right now and stores the result
            // in a new list. Books added later are NOT in that list.

            // Eager execution: ToList() executes immediately at that line.



            #endregion

            #region Bonus
            // 1. Several conditions in one where

            //Fleunt Syntax
            var differentBooks = books.Where(b => b.Genre == "Science" || b.Genre == "History" && b.Price < 30.0000M);
            foreach (var book in differentBooks)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // Query Syntax
            var DifferentBooks = from b in books
                                 where b.Genre == "Science" || b.Genre == "History"
                                && b.Price < 30.0000M
                                 select b; ;
            foreach (var book in DifferentBooks)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("===========================");

            // 2. Select with an index

            // Fleunt Syntax
            var bookIndex = books.Select((book, index) => new { index, book.Title });
            foreach (var book in bookIndex)
            {
                Console.WriteLine($"{book.index}: {book.Title}");
            }
            Console.WriteLine("===========================");

            // Query Syntax 
            var BookIndex = from b in books.Select((book, index) => new { index, book.Title })
                            select b;
            foreach (var book in BookIndex)
            {
                Console.WriteLine($"{book.index}: {book.Title}");
            }
            Console.WriteLine("===========================");

            #endregion
        }
    }
}
