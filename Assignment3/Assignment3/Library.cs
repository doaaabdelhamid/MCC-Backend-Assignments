using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class Library
    {
        private List<Book> Books = new List<Book>();
        public void AddBooks(Book book)
        {
            Books.Add(book);
        }
        public void DisplayBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book.GetDetails());
            }
        }
    }
}
