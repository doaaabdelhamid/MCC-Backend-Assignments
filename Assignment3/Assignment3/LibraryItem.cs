using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public int ItemId { get; set; }
        protected LibraryItem(string title, int itemId)
        {
            Title = title;
            ItemId = itemId;
        }
        public abstract string GetDetails();
    }

    public class Book : LibraryItem
    {
        public Book(string title, int itemId):base(title, itemId)
        {
        }
        public override string GetDetails()
        {
            return $"BookId: {ItemId}, Title: {Title}";
        }
    }
    public class Magazine : LibraryItem
    {
        public Magazine(string title, int itemId) : base(title, itemId)
        {
        }
        public override string GetDetails()
        {
            return $"MagazineId: {ItemId}, Title: {Title}";
        }
    }
}
