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
    public class PostActionTypesController : Controller
    {
        private DG_QUEJATERD_Entities db = new DG_QUEJATERD_Entities();

        // GET: PostActionTypes
        public ActionResult Index()
        {
            var postActionTypes = db.PostActionTypes.Include(p => p.Users).Include(p => p.Users1).Include(p => p.Users2);
            return View(postActionTypes.ToList());
        }

        // GET: PostActionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActionTypes postActionTypes = db.PostActionTypes.Find(id);
            if (postActionTypes == null)
            {
                return HttpNotFound();
            }
            return View(postActionTypes);
        }

        // GET: PostActionTypes/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname");
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname");
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname");
            return View();
        }

        // POST: PostActionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActionTypeName,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] PostActionTypes postActionTypes)
        {
            if (ModelState.IsValid)
            {
                db.PostActionTypes.Add(postActionTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.DeletedBy);
            return View(postActionTypes);
        }

        // GET: PostActionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActionTypes postActionTypes = db.PostActionTypes.Find(id);
            if (postActionTypes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.DeletedBy);
            return View(postActionTypes);
        }

        // POST: PostActionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActionTypeName,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] PostActionTypes postActionTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postActionTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.UpdatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActionTypes.DeletedBy);
            return View(postActionTypes);
        }

        // GET: PostActionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActionTypes postActionTypes = db.PostActionTypes.Find(id);
            if (postActionTypes == null)
            {
                return HttpNotFound();
            }
            return View(postActionTypes);
        }

        // POST: PostActionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostActionTypes postActionTypes = db.PostActionTypes.Find(id);
            db.PostActionTypes.Remove(postActionTypes);
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
