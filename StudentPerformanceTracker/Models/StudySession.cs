namespace StudentPerformanceTracker.Models
{
    public class StudySession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; } // Study or Break

        public StudySession()
        {
        }

        public StudySession(int id, DateTime date, int duration, string subject, string type)
        {
            Id = id;
            Date = date;
            Duration = duration;
            Subject = subject;
            Type = type;
        }
    }
}
