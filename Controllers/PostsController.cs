using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUEJATERD.DBModels;

namespace QUEJATERD.Controllers
{
    public class PostsController : Controller
    {
        private DG_QUEJATERD_Entities db = new DG_QUEJATERD_Entities();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Users).Include(p => p.Users1).Include(p => p.Users2);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname");
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname");
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,IsVisible,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", posts.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", posts.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", posts.DeletedBy);
            return View(posts);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", posts.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", posts.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", posts.DeletedBy);
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,IsVisible,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", posts.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", posts.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", posts.DeletedBy);
            return View(posts);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Posts posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
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
        }
    }
}
