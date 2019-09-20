using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sitesatis.Models.entity;

namespace sitesatis.Controllers
{
    public class productsController : Controller
    {
       /* private satissitesivol1DBEntities db = new satissitesivol1DBEntities();

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.cargo).Include(p => p.cargo_type).Include(p => p.category).Include(p => p.user).Include(p => p.repository);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.cargo_id = new SelectList(db.cargoes, "id", "cargo_company");
            ViewBag.cargo_type_id = new SelectList(db.cargo_type, "id", "cargo_type1");
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name");
            ViewBag.publisher = new SelectList(db.users, "id", "user_name");
            ViewBag.repository_id = new SelectList(db.repositories, "id", "repository_name");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,product_name,product_content,category_id,cargo_type_id,cargo_id,product_price,prouct_image_path,publisher,product_quantity,repository_id,product_add_time")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargo_id = new SelectList(db.cargoes, "id", "cargo_company", product.cargo_id);
            ViewBag.cargo_type_id = new SelectList(db.cargo_type, "id", "cargo_type1", product.cargo_type_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", product.category_id);
            ViewBag.publisher = new SelectList(db.users, "id", "user_name", product.publisher);
            ViewBag.repository_id = new SelectList(db.repositories, "id", "repository_name", product.repository_id);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo_id = new SelectList(db.cargoes, "id", "cargo_company", product.cargo_id);
            ViewBag.cargo_type_id = new SelectList(db.cargo_type, "id", "cargo_type1", product.cargo_type_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", product.category_id);
            ViewBag.publisher = new SelectList(db.users, "id", "user_name", product.publisher);
            ViewBag.repository_id = new SelectList(db.repositories, "id", "repository_name", product.repository_id);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_name,product_content,category_id,cargo_type_id,cargo_id,product_price,prouct_image_path,publisher,product_quantity,repository_id,product_add_time")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargo_id = new SelectList(db.cargoes, "id", "cargo_company", product.cargo_id);
            ViewBag.cargo_type_id = new SelectList(db.cargo_type, "id", "cargo_type1", product.cargo_type_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", product.category_id);
            ViewBag.publisher = new SelectList(db.users, "id", "user_name", product.publisher);
            ViewBag.repository_id = new SelectList(db.repositories, "id", "repository_name", product.repository_id);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
