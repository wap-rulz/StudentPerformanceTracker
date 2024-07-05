using StudentPerformanceTracker.Models;

namespace StudentPerformanceTracker.Data
{
    public static class InMemoryDatabase
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Module> Modules { get; set; } = new List<Module>();
        public static List<StudySession> StudySessions { get; set; } = new List<StudySession>();

        static InMemoryDatabase()
        {
            //Initialize Database
            Users.Add(new User(1, "Adeesha", "Peiris", "adeesha", "1234"));

            Modules.Add(new Module(1, "Embedded Systems", 150));
            Modules.Add(new Module(2, "Distributed Systems", 100));
            Modules.Add(new Module(3, "Machine Learning", 200));

            StudySessions.Add(new StudySession(1, DateTime.Now.AddDays(-1), 60, 1, StudyLevel.Intermediate));
            StudySessions.Add(new StudySession(2, DateTime.Now.AddDays(-1), 30, 2, StudyLevel.Advanced));
        }
    }
}
