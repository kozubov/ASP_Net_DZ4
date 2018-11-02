using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_4.Models;

namespace ASP_4.Controllers
{
    public class HomeController : Controller
    {
        private Singleton singleton = Singleton.Instens;
        // GET: Publisher
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelPublisher model)
        {
            if (ModelState.IsValid)
            {
                Publisher publisher = new Publisher(model.Name);
                singleton.AddPublisher(publisher);
                ViewBag.TablePublishers = singleton.GetPublisher;
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.TablePublishers = singleton.GetPublisher;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Publisher = singleton.GetPublisher.Find(Publisher => Publisher.Id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ModelPublisher model, int id)
        {
            if (ModelState.IsValid)
            {
                var FindPublisher = singleton.GetPublisher.Find(Publisher => Publisher.Id == id);
                FindPublisher.EditPublisher(model.Name);
                CheckingPublisher(FindPublisher);
                return RedirectToAction("Show_Table");
            }
            else
            {
                ViewBag.Publisher = singleton.GetPublisher.Find(Publisher => Publisher.Id == id);
                return View();
            }
        }

        private void CheckingPublisher(Publisher item)
        {
            foreach (Book VARIABLE in singleton.GetBooks)
            {
                if (VARIABLE.publisher.Id == item.Id)
                {
                    VARIABLE.publisher.Name = item.Name;
                }
            }
        }

        public ActionResult Delete(int id)
        {
            var FindPublisherTo = singleton.GetPublisher.Find(Publisher => Publisher.Id == id);
            singleton.GetPublisher.Remove(FindPublisherTo);
            DeletePublisher(FindPublisherTo);
            ViewBag.TablePublishers = singleton.GetPublisher;
            return View("Show_Table");
        }

        private void DeletePublisher(Publisher findPublisher)
        {
            foreach (Book VARIABLE in singleton.GetBooks)
            {
                if (VARIABLE.publisher.Id == findPublisher.Id)
                {
                    VARIABLE.publisher = null;
                }
            }
        }
    }
}