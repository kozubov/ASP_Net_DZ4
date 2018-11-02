using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_4.Models;


namespace ASP_4.Controllers
{
    public class BookController : Controller
    {
        Singleton singleton = Singleton.Instens;
        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            Show_RadioAndCeck();
            return View();
        }

        private void Show_RadioAndCeck()
        {
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> checkBox = new List<SelectListItem>();
            if (singleton.GetPublisher.Count != 0)
            {
                foreach (var VARIABLE in singleton.GetPublisher)
                {
                    radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            if (singleton.GetAuthors.ToList().Count != 0)
            {
                foreach (var VARIABLE in singleton.GetAuthors)
                {
                    checkBox.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            ViewBag.Radio = radio;
            ViewBag.Check = checkBox;
        }

        [HttpPost]
        public ActionResult Index(ModelBook model)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book(model.Name, model.PublishingDate, model.PageCount, model.ISBN);
                foreach (string VARIABLE in model.SelectedCheck)
                {
                    Author FindAuthor = singleton.GetAuthors.BackAuthor(Convert.ToInt32(VARIABLE));
                    book.AddBookAuthor(FindAuthor);
                }
                Publisher pub = singleton.GetPublisher.Find(Publisher => Publisher.Id == Convert.ToInt32(model.RadioCheck));
                book.AddBookPublisher(pub);
                singleton.AddBook(book);
                ViewBag.Book = singleton.GetBooks;
                return RedirectToAction("Show_Table");
            }
            else
            {
                Show_RadioAndCeck();
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Book = singleton.GetBooks;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book FindBook = singleton.GetBooks.Find(Book => Book.Id == id);
            ShowRadioCheckEdit(FindBook);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ModelBook model, int id)
        {
            if (ModelState.IsValid)
            {
                Book Find_book = singleton.GetBooks.Find(Book => Book.Id == id);
                Find_book.BookEdit(model.Name, model.PublishingDate, model.PageCount, model.ISBN);
                Publisher Find_publich =
                    singleton.GetPublisher.Find(Publisher => Publisher.Id == Convert.ToInt32(model.RadioCheck));
                Find_book.publisher = Find_publich;
                Find_book.AuthorClear();
                foreach (string VARIABLE in model.SelectedCheck)
                {
                    Author FindAuthor = singleton.GetAuthors.BackAuthor(Convert.ToInt32(VARIABLE));
                    Find_book.AddBookAuthor(FindAuthor);
                }

                return RedirectToAction("Show_Table");
            }
            else
            {
                Book FindBook = singleton.GetBooks.Find(Book => Book.Id == id);
                ShowRadioCheckEdit(FindBook);
                return View();
            }
        }

        private void ShowRadioCheckEdit(Book findBook)
        {
            ViewBag.Book = findBook;
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> check = new List<SelectListItem>();
            if (findBook != null)
            {
                foreach (Publisher VARIABLE in singleton.GetPublisher)
                {
                    if (findBook.publisher != null)
                    {
                        if (findBook.publisher.Id == VARIABLE.Id)
                        {
                            radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = true });
                        }
                        else
                        {
                            radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                        }
                    }
                    else
                    {
                        radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                    }
                }

                int i = 0;
                foreach (Author VARIABLE in singleton.GetAuthors)
                {
                    i = 0;
                    foreach (Author VAR in findBook.GetBooksAuthor)
                    {
                        if (VARIABLE.Id == VAR.Id)
                        {
                            check.Add(new SelectListItem
                            {
                                Text = $"{VARIABLE.Name}",
                                Value = $"{VARIABLE.Id}",
                                Selected = true
                            });
                            i++;
                        }
                    }
                    if (i == 0)
                    {
                        check.Add(
                            new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                    }
                }
            }
            ViewBag.Radio = radio;
            ViewBag.Check = check;
        }

        public ActionResult Delete(int id)
        {
            var FindBook = singleton.GetBooks.Find(Book => Book.Id == id);
            singleton.GetBooks.Remove(FindBook);
            ViewBag.Book = singleton.GetBooks;
            return View("Show_Table");
        }
    }
}