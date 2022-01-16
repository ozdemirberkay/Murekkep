using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MurekkepWeb.Models;
using MurekkepWeb.Models.Managers;

namespace MurekkepWeb.Controllers
{
    public class HomeController : Controller
    {


        private DataBaseContext db = new DataBaseContext();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            ViewBag.Yorumlar = await db.Comments.ToListAsync();
            return View(await db.Categories.ToListAsync());

        }


        public ActionResult Arama()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Arama(string kelime)
        {
            string s1 = kelime;//
            return RedirectToAction("AramaSonuc", "Home", new { text = kelime });
        }


        public async Task<ActionResult> AramaSonuc(string text)
        {
            ViewBag.Urunler = await db.Products.Where(x => x.Name.Contains(text)).ToListAsync();



            return View();

        }



        public ActionResult Hakkimizda()
        {
            DataBaseContext db = new DataBaseContext();

            return View();
        }


        public async Task<ActionResult> Urunler(int id)
        {

            return View(await db.Products.Where(s => s.CategoryID == id.ToString()).ToListAsync());

        }

        public async Task<ActionResult> UrunYorum(int? id, string text = "", string yildiz = "", string t = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (text == "")
            {
                if (yildiz != "")
                {
                    int tmp = int.Parse(yildiz);
                    product.YorumList = await db.Comments.Where(s => (s.productId == id) && (s.yildiz == tmp)).ToListAsync();
                }
                else
                {
                    product.YorumList = await db.Comments.Where(s => s.productId == id).ToListAsync();
                }


            }
            else
            {

                if (yildiz != "")
                {

                    int tmp = int.Parse(yildiz);
                    product.YorumList = await db.Comments.Where(s => (s.productId == id) && (s.icerik.Contains(text))  && (s.yildiz ==tmp)).ToListAsync();
                }
                else
                {
                    product.YorumList = await db.Comments.Where(s => (s.productId == id) && (s.icerik.Contains(text))).ToListAsync();
                }

               
            }



            int toplamPuan = 0;

            for (int i = 0; i < product.YorumList.Count; i++)
            {
                toplamPuan += product.YorumList[i].yildiz;

            }

            if (product.YorumList.Count > 0)
            {
                product.ortalamaPuan = (toplamPuan / product.YorumList.Count).ToString();
            }
            else
            {
                product.ortalamaPuan = "Bu ürüne henüz hiç puan verilmedi";
            }



            return View(product);
        }


        [HttpPost]
        public async Task<ActionResult> UrunYorum2(int? id, string aramatext, string yildiz, string t = "")
        {
            return RedirectToAction("UrunYorum", "Home", new { id = id, text = aramatext, yildiz = yildiz, t = t });
        }


        [HttpPost]
        public async Task<ActionResult> UrunYorumBegen(int urunid, string yorumid)
        {
            int tmp = int.Parse(yorumid);
            Comment comment = await db.Comments.FindAsync(tmp);

            comment.begeniSayi = comment.begeniSayi + 1;
            db.SaveChanges();


            return RedirectToAction("UrunYorum", "Home", new { id = urunid });
        }


        [HttpPost]
        public async Task<ActionResult> UrunYorum(int? id, string Message, string stars)
        {


            Comment comment = new Comment();
            comment.icerik = Message;
            comment.yildiz = int.Parse(stars);
            comment.productId = id;
            comment.begeniSayi = 0;

            comment.username = Session["username"].ToString();

            db.Comments.Add(comment);
            await db.SaveChangesAsync();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }



            product.YorumList = await db.Comments.Where(s => s.productId == id).ToListAsync();

            int toplamPuan = 0;

            for (int i = 0; i < product.YorumList.Count; i++)
            {
                toplamPuan += product.YorumList[i].yildiz;

            }


            if (product.YorumList.Count > 0)
            {
                product.ortalamaPuan = (toplamPuan / product.YorumList.Count).ToString();
            }
            else
            {
                product.ortalamaPuan = "Bu ürüne henüz hiç puan verilmedi";
            }

            return View(product);
        }
    }
}