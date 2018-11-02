using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using ASP_4.Models;

namespace ASP_4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Publisher publisher { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public DateTime PublishingDate { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        public Book(string name, string date, string pageCount, string isbn)
        {
            Authors = new List<Author>();
            Name = name;
            PublishingDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }

        public void BookEdit(string name, string date, string pageCount, string isbn)
        {
            Name = name;
            PublishingDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }

        public void AddBookAuthor(Author author)
        {
            Authors = Authors.Add(author);
        }

        public void AddBookPublisher(Publisher publisher)
        {
            this.publisher = publisher;
        }

        public IEnumerable<Author> GetBooksAuthor => Authors;

        public void AuthorClear()
        {
            Authors = Authors.Clear();
        }

        public void CheckAuthor()
        {
            Authors = Singleton.Instens.GetAuthors.Checking(Authors);
        }
    }
}