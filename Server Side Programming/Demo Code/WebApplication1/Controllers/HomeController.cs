using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {   //Use drop down to auto import the namespace when you see red squiggly lines
        private static List<BlogEntry> entries = new List<BlogEntry>() 
        {
            new BlogEntry() {
                Id = 1,
                Title = "Test 1",
                Body = "This is the 1st blog entry"
            },
            new BlogEntry() {
                Id = 2,
                Title = "Test 2",
                Body = "This is the 2nd blog entry"
            }
        };




        public ActionResult Index() // Action result is an abstract class, a base class, there are many subclasses 
        // of ActionResult that do different things.  ViewResult is one.

        {
            return View(entries); // inserting 'entries' passes model to view, Controllers primary job is take date from DB and render (we are pretending to use a DB in this example)
        }   //hover over View method (a helper method) to see it returns a viewresult, an action result that can render some HTML





        // This public action method returns a view result object 
        public ActionResult Detail(int id) 
        {
            var entry = entries.FirstOrDefault(i => i.Id == id); // This is linq 1:11:50  for explanation

            if (entry == null)
            {
                return HttpNotFound();
            }

            return View(entry);//create the ViewResult by calling the View method
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogEntry model)
        {
            model.Id = entries.Count + 1;

            entries.Add(model);

            return Redirect("/");
        }
    }
}





