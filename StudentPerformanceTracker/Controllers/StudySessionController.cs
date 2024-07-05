using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPerformanceTracker.Data;
using StudentPerformanceTracker.Models;

namespace StudentPerformanceTracker.Controllers
{
    public class StudySessionController : Controller
    {
        // GET: StudySessionController
        public ActionResult Index()
        {
            var sessions = InMemoryDatabase.StudySessions.Select(s => new
            {
                s.Id,
                s.Date,
                s.Duration,
                s.StudyLevel,
                ModuleName = InMemoryDatabase.Modules.SingleOrDefault(m => m.Id == s.ModuleId)?.Name
            }).ToList();
            return View(sessions);
        }

        // GET: StudySessionController/Create
        public ActionResult Create()
        {
            ViewBag.Modules = InMemoryDatabase.Modules;
            PopulateStudyLevelSelector(null);
			PopulateDurationSelectors(0);
			return View();
        }

        // POST: StudySessionController/Create
        [HttpPost]
        public ActionResult Create(StudySession session)
        {
            session.Id = InMemoryDatabase.StudySessions.Count + 1;
            InMemoryDatabase.StudySessions.Add(session);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudySessionController/Edit/5
        public ActionResult Edit(int id)
        {
            var session = InMemoryDatabase.StudySessions.SingleOrDefault(s => s.Id == id);
            ViewBag.Modules = InMemoryDatabase.Modules;
            PopulateStudyLevelSelector(session.StudyLevel);
			PopulateDurationSelectors(session.Duration);
			return View(session);
        }

        // POST: StudySessionController/Edit/5
        [HttpPost]
        public ActionResult Edit(StudySession session)
        {
            var existingSession = InMemoryDatabase.StudySessions.SingleOrDefault(s => s.Id == session.Id);
            ViewBag.Modules = InMemoryDatabase.Modules;
            if (existingSession != null)
            {
                existingSession.Date = session.Date;
                existingSession.Duration = session.Duration;
                existingSession.ModuleId = session.ModuleId;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: StudySessionController/Delete/5
        public ActionResult Delete(int id)
        {
            var session = InMemoryDatabase.StudySessions.SingleOrDefault(s => s.Id == id);
            if (session != null)
            {
                InMemoryDatabase.StudySessions.Remove(session);
            }
            return RedirectToAction(nameof(Index));
        }

		private void PopulateDurationSelectors(int duration)
		{
			var hours = Enumerable.Range(0, 13).Select(i => new { Key = i, Value = $"{i} h" });
			var minutes = Enumerable.Range(0, 60).Where(i => i % 5 == 0).Select(i => new { Key = i, Value = $"{i} min" });

			ViewBag.Hours = new SelectList(hours, "Key", "Value", duration / 60);
			ViewBag.Minutes = new SelectList(minutes, "Key", "Value", duration % 60);
		}

		private void PopulateStudyLevelSelector(StudyLevel? studyLevel)
		{
            SelectList StudyLevels;
            if (studyLevel == null)
            {
                StudyLevels = new SelectList(Enum.GetValues(typeof(StudyLevel)));
            }
            else
			{
				StudyLevels = new SelectList(Enum.GetValues(typeof(StudyLevel)), studyLevel);
			}
            ViewBag.StudyLevels = StudyLevels;
		}
	}
}
