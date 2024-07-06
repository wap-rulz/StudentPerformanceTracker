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

            Modules.Add(new Module(1, "Embedded Systems", 3));
            Modules.Add(new Module(2, "Distributed Systems", 4));
            Modules.Add(new Module(3, "Machine Learning", 2));

            StudySessions.Add(new StudySession(1, DateTime.Now.AddDays(-1), 90, 1, StudyLevel.Intermediate));
            StudySessions.Add(new StudySession(2, DateTime.Now.AddDays(-2), 150, 2, StudyLevel.Beginner));
            StudySessions.Add(new StudySession(5, DateTime.Now.AddDays(-2), 30, 3, StudyLevel.Advanced));
            StudySessions.Add(new StudySession(6, DateTime.Now.AddDays(-3), 60, 2, StudyLevel.Beginner));
            StudySessions.Add(new StudySession(7, DateTime.Now.AddDays(-4), 100, 1, StudyLevel.Intermediate));
            StudySessions.Add(new StudySession(8, DateTime.Now.AddDays(-5), 80, 3, StudyLevel.Advanced));
            StudySessions.Add(new StudySession(9, DateTime.Now.AddDays(-2), 100, 2, StudyLevel.Expert));
            StudySessions.Add(new StudySession(10, DateTime.Now.AddDays(-3), 90, 1, StudyLevel.Intermediate));
        }
    }
}
