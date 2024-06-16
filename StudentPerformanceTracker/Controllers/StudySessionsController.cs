using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformanceTracker.Data;
using StudentPerformanceTracker.Models;

namespace StudentPerformanceTracker.Controllers
{
    public class StudySessionsController : Controller
    {
        // GET: StudySessionController
        public ActionResult Index()
        {
            return View(InMemoryDatabase.StudySessions);
        }

        // GET: StudySessionController/Create
        public ActionResult Create()
        {
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
            var session = InMemoryDatabase.StudySessions.FirstOrDefault(s => s.Id == id);
            return View(session);
        }

        // POST: StudySessionController/Edit/5
        [HttpPost]
        public ActionResult Edit(StudySession session)
        {
            var existingSession = InMemoryDatabase.StudySessions.FirstOrDefault(s => s.Id == session.Id);
            if (existingSession != null)
            {
                existingSession.Date = session.Date;
                existingSession.Duration = session.Duration;
                existingSession.Subject = session.Subject;
                existingSession.Type = session.Type;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: StudySessionController/Delete/5
        public ActionResult Delete(int id)
        {
            var session = InMemoryDatabase.StudySessions.FirstOrDefault(s => s.Id == id);
            if (session != null)
            {
                InMemoryDatabase.StudySessions.Remove(session);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
