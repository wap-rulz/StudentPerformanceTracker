namespace StudentPerformanceTracker.Models
{
    public class StudySession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int ModuleId { get; set; }
        public StudyLevel StudyLevel { get; set; }

		public StudySession()
		{
		}

		public StudySession(int id, DateTime date, int duration, int moduleId, StudyLevel studyLevel)
        {
            Id = id;
            Date = date;
            Duration = duration;
            ModuleId = moduleId;
            StudyLevel = studyLevel; 
        }
    }

    public enum StudyLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert
    }
}
