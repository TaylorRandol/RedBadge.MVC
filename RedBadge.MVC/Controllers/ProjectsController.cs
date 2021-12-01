using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RedBadge.Data;
using RedBadgeData;
using RedBadgeModels.Project.Models;
using RedBadgeServices;

namespace RedBadge.MVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            var model = service.GetProjects();

            return View(model);
        }

        // GET: Projects/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);
            return View(model);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your project was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could nto be created.");

            return View(model);
        }

        // GET: Projects/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    Title = detail.Title
                };
            return View(model);
        }

        // POST: Projects/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();
            if(service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your Project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Project could not be updated.");
            return View();
        }

        // GET: Projects/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);
            return View(model);
        }

        // POST: Projects/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateProjectService();
            service.DeleteProject(id);
            TempData["SaveResult"] = "Your Project was deleted.";
            return RedirectToAction("Index");
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}
