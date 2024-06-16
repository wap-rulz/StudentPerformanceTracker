using StudentPerformanceTracker.Models;

namespace StudentPerformanceTracker.Data
{
    public static class InMemoryDatabase
    {
        public static List<StudySession> StudySessions { get; set; } = new List<StudySession>();
        public static List<KnowledgeLevel> KnowledgeLevels { get; set; } = new List<KnowledgeLevel>();

        static InMemoryDatabase()
        {
            //Initialize Database
            StudySessions.Add(new StudySession(1, DateTime.Now.AddDays(-1), 60, "Maths", "Study"));
            StudySessions.Add(new StudySession(2, DateTime.Now.AddDays(-1), 30, "Maths", "Break"));

            KnowledgeLevels.Add(new KnowledgeLevel("Maths", 50));
        }
    }
}
