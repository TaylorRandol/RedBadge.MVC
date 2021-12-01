using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedBadge.Data;
using RedBadgeData;

namespace RedBadge.MVC.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Notes
        public ActionResult Index()
        {
            var notes = _db.Notes.Include(n => n.Task);
            return View(notes.ToList());
        }

        // GET: Notes/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            ViewBag.TaskId = new SelectList(_db.Tasks, "TaskId", "Title");
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoteId,UserId,TaskId,Comment,CreatedUtc,ModifiedUtc")] Note note)
        {
            note.CreatedUtc = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Notes.Add(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskId = new SelectList(_db.Tasks, "TaskId", "Title", note.TaskId);
            return View(note);
        }

        // GET: Notes/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskId = new SelectList(_db.Tasks, "TaskId", "Title", note.TaskId);
            return View(note);
        }

        // POST: Notes/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteId,UserId,TaskId,Comment,CreatedUtc,ModifiedUtc")] Note note)
        {
            note.ModifiedUtc = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Entry(note).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskId = new SelectList(_db.Tasks, "TaskId", "Title", note.TaskId);
            return View(note);
        }

        // GET: Notes/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = _db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = _db.Notes.Find(id);
            _db.Notes.Remove(note);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
