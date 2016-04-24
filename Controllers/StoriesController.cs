using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PublicNewsPaper.Models;

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
    }
}
