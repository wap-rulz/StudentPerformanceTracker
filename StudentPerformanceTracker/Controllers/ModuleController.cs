using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformanceTracker.Data;
using StudentPerformanceTracker.Models;

namespace StudentPerformanceTracker.Controllers
{
    public class ModuleController : Controller
    {
        // GET: ModuleController
        public ActionResult Index()
        {
            var modules = InMemoryDatabase.Modules;
            return View(modules);
        }

        // GET: ModuleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModuleController/Create
        [HttpPost]
        public ActionResult Create(Module module)
        {
            module.Id = InMemoryDatabase.Modules.Max(m => m.Id) + 1;
            InMemoryDatabase.Modules.Add(module);
            return RedirectToAction(nameof(Index));
        }

        // GET: ModuleController/Edit/5
        public ActionResult Edit(int id)
        {
            var module = InMemoryDatabase.Modules.SingleOrDefault(m => m.Id == id);
            return View(module);
        }

        // POST: ModuleController/Edit/5
        [HttpPost]
        public ActionResult Edit(Module module)
        {
            var existingModule = InMemoryDatabase.Modules.SingleOrDefault(m => m.Id == module.Id);
            if (existingModule != null)
            {
                existingModule.Name = module.Name;
                existingModule.Credits = module.Credits;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ModuleController/Delete/5
        public ActionResult Delete(int id)
        {
            var module = InMemoryDatabase.Modules.SingleOrDefault(m => m.Id == id);
            if (module != null)
            {
                InMemoryDatabase.Modules.Remove(module);
                InMemoryDatabase.StudySessions.RemoveAll(s => s.ModuleId == id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
