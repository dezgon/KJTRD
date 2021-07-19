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
    public class PostActionsController : Controller
    {
        private DG_QUEJATERD_Entities db = new DG_QUEJATERD_Entities();

        // GET: PostActions
        public ActionResult Index()
        {
            var postActions = db.PostActions.Include(p => p.PostActionTypes).Include(p => p.Posts).Include(p => p.Users).Include(p => p.Users1);
            return View(postActions.ToList());
        }

        // GET: PostActions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActions postActions = db.PostActions.Find(id);
            if (postActions == null)
            {
                return HttpNotFound();
            }
            return View(postActions);
        }

        // GET: PostActions/Create
        public ActionResult Create()
        {
            ViewBag.ActionTypeId = new SelectList(db.PostActionTypes, "Id", "ActionTypeName");
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname");
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname");
            return View();
        }

        // POST: PostActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostId,IsPositive,ActionTypeId,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] PostActions postActions)
        {
            if (ModelState.IsValid)
            {
                db.PostActions.Add(postActions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActionTypeId = new SelectList(db.PostActionTypes, "Id", "ActionTypeName", postActions.ActionTypeId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postActions.PostId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActions.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActions.DeletedBy);
            return View(postActions);
        }

        // GET: PostActions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActions postActions = db.PostActions.Find(id);
            if (postActions == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActionTypeId = new SelectList(db.PostActionTypes, "Id", "ActionTypeName", postActions.ActionTypeId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postActions.PostId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActions.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActions.DeletedBy);
            return View(postActions);
        }

        // POST: PostActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,IsPositive,ActionTypeId,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] PostActions postActions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postActions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActionTypeId = new SelectList(db.PostActionTypes, "Id", "ActionTypeName", postActions.ActionTypeId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", postActions.PostId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "Surname", postActions.CreatedBy);
            ViewBag.DeletedBy = new SelectList(db.Users, "Id", "Surname", postActions.DeletedBy);
            return View(postActions);
        }

        // GET: PostActions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostActions postActions = db.PostActions.Find(id);
            if (postActions == null)
            {
                return HttpNotFound();
            }
            return View(postActions);
        }

        // POST: PostActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PostActions postActions = db.PostActions.Find(id);
            db.PostActions.Remove(postActions);
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
