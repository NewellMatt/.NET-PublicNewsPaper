using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PublicNewsPaper.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PublicNewsPaper.Controllers
{
    public class StoriesController : Controller
    {
        private PublicNewsPaperDbContext db = new PublicNewsPaperDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Stories.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Stories.FirstOrDefault(items => items.StoryId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Story story)
        {
            db.Stories.Add(story);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = db.Stories.FirstOrDefault(items => items.StoryId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Story item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisItem = db.Stories.FirstOrDefault(stories => stories.StoryId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Stories.FirstOrDefault(items => items.StoryId == id);
            db.Stories.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CategoriesByStory(string id)
        {
            // Find the customer by name
            var customer = db.Categories.First(c => c.Name == id);

            // Get the customers products
            var customersProducts = customer.Name;

            // Send products to the View to be rendered
            return View(customersProducts);
        }
    }
}
