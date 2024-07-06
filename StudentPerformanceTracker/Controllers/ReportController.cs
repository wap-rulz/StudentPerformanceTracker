using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformanceTracker.Data;
using StudentPerformanceTracker.Models;
using System.Collections.Generic;

namespace StudentPerformanceTracker.Controllers
{
    public class ReportController : Controller
    {

        // GET: ReportController
        public ActionResult Index()
        {
            List<StudySessionSummary> studySessionSummaries = GetStudySessionSummaries();
            studySessionSummaries.ForEach(studySessionSummary =>
            {
                studySessionSummary.PredictedGrade = PredictGrade(studySessionSummary.ModuleId, studySessionSummary.KnowledgeLevel);
            });
            return View(studySessionSummaries);
        }

        private List<StudySessionSummary> GetStudySessionSummaries()
        {
            var studySessionSummaries = InMemoryDatabase.Modules
                .Select(m => new StudySessionSummary
                {
                    ModuleId = m.Id,
                    ModuleName = m.Name
                }).ToList();
            foreach (var session in InMemoryDatabase.StudySessions)
            {
                var summary = studySessionSummaries.SingleOrDefault(s => s.ModuleId == session.ModuleId);
                summary.TotalSessions++;
                summary.TotalDuration += session.Duration;
                double durationInDecimal = (session.Duration / 60) + ((double)(session.Duration % 60) / 60);
                summary.KnowledgeLevel += durationInDecimal * GetStudyLevel(session.StudyLevel);
            }
            return studySessionSummaries;
        }

        private string PredictGrade(int moduleId, double knowledgeLevel)
        {
            var module = InMemoryDatabase.Modules.SingleOrDefault(m => m.Id == moduleId);
            knowledgeLevel = ((double)knowledgeLevel / module.Credits) * 100;
            if (knowledgeLevel >= 85)
            {
                return "A+";
            }
            else if (knowledgeLevel >= 75)
            {
                return "A";
            }
            else if (knowledgeLevel >= 70)
            {
                return "A-";
            }
            else if (knowledgeLevel >= 65)
            {
                return "B+";
            }
            else if (knowledgeLevel >= 60)
            {
                return "B";
            }
            else if (knowledgeLevel >= 55)
            {
                return "B-";
            }
            else if (knowledgeLevel >= 50)
            {
                return "C+";
            }
            else if (knowledgeLevel >= 45)
            {
                return "C";
            }
            else if (knowledgeLevel >= 40)
            {
                return "C-";
            }
            else if (knowledgeLevel >= 35)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        private double GetStudyLevel(StudyLevel studyLevel)
        {
            switch (studyLevel)
            {
                case StudyLevel.Beginner:
                    return 0.25;
                case StudyLevel.Intermediate:
                    return 0.5;
                case StudyLevel.Advanced:
                    return 0.75;
                case StudyLevel.Expert:
                    return 1.0;
                default:
                    return 0.0;
            }
        }
    }
}
