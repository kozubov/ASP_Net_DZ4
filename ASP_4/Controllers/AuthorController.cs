using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_4.Models;

namespace ASP_4.Controllers
{
    public class AuthorController : Controller
    {
        private Singleton singleton = Singleton.Instens;
        // GET: Author
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelAuthor model)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author(model.Name, model.DateOfBirth, model.DateOfDeath);
                singleton.AddAuthor(author);
                ViewBag.Author = singleton.GetAuthors;
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Author = singleton.GetAuthors;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author FindAuthor = singleton.GetAuthors.BackAuthor(id);
            ViewBag.Author = FindAuthor;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ModelAuthor model, int id)
        {
            if (ModelState.IsValid)
            {
                Author FindAuthor = singleton.GetAuthors.BackAuthor(id); ;
                FindAuthor.AuthorEdit(model.Name, model.DateOfBirth, model.DateOfDeath);
                ViewBag.Author = singleton.GetAuthors;
                Checking_Author();
                return RedirectToAction("Show_Table");
            }
            else
            {
                Author FindAuthor = singleton.GetAuthors.BackAuthor(id);
                ViewBag.Author = FindAuthor;
                return View();
            }
        }

        private void Checking_Author()
        {
            foreach (Book VARIABLE in singleton.GetBooks)
            {
                VARIABLE.CheckAuthor();
            }
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Author> Authors = singleton.GetAuthors.Delete(id);
            singleton.GetAuthors = Authors;
            ViewBag.Author = singleton.GetAuthors;
            Checking_Author();
            return View("Show_Table");
        }
    }
}