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
    public class TasksController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = _db.Tasks.Include(t => t.Project);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = _db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Title");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,ProjectId,Title,Description,IsDone")] Task task)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(task);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Title", task.ProjectId);
            return View(task);
        }

        // GET: Tasks/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = _db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Title", task.ProjectId);
            return View(task);
        }

        // POST: Tasks/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,ProjectId,Title,Description,IsDone")] Task task)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(task).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Title", task.ProjectId);
            return View(task);
        }

        // GET: Tasks/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = _db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = _db.Tasks.Find(id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
