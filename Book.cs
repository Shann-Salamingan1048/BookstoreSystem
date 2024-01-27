using System;
namespace BookstoreSystem
{
    class Book
    {
        public String Title { get; set; }
        public string BookID { get; set; }
        public double Price { get; set; }
        public String Author { get; set; }
        public Book(string Title, string BookID, double Price, string Author)
        {
            this.Title = Title;
            this.BookID = BookID;
            this.Price = Price;
            this.Author = Author;
        }
    }
}
