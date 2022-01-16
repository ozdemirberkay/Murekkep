using MurekkepWeb.Models;
using MurekkepWeb.Models.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MurekkepWeb.Controllers
{
    public class AdminController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Home
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            List<User> users = await db.Users.ToListAsync();
            List<Comment> comment = await db.Comments.ToListAsync();
            List<Product> products = await db.Products.ToListAsync();
            List<Category> categories = await db.Categories.ToListAsync();



            ViewBag.usercount = users.Count;
            ViewBag.commentcount = comment.Count;
            ViewBag.productscount = products.Count;
            ViewBag.categoriescount = categories.Count;

            return View();
        }
    }
}