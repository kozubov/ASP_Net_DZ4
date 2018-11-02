using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_4.Models
{
    public class Singleton
    {
        public static Singleton instance;
        public static Singleton Instens => instance ?? (instance = new Singleton());

        public Singleton() { }
        private List<Book> Books = new List<Book>();
        private List<Publisher> Publishers = new List<Publisher>();
        private IEnumerable<Author> Authors = new List<Author>();


        public List<Book> GetBooks => Books;
        public List<Publisher> GetPublisher => Publishers;
        public IEnumerable<Author> GetAuthors
        {
            get => Authors;
            set => Authors = value;
        }

        public void AddBook(Book book)
        {
            book.Id = (Books.LastOrDefault()?.Id ?? 0) + 1;
            Books.Add(book);
        }

        public void AddPublisher(Publisher publisher)
        {
            publisher.Id = (Publishers.LastOrDefault()?.Id ?? 0) + 1;
            Publishers.Add(publisher);
        }

        public void AddAuthor(Author author)
        {
            author.Id = (Authors.LastOrDefault()?.Id ?? 0) + 1;
            Authors = Authors.Add(author);
        }
    }
}