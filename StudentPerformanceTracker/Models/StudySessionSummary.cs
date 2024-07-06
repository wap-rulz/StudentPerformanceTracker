namespace StudentPerformanceTracker.Models
{
    public class StudySessionSummary
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int TotalSessions { get; set; }
        public int TotalDuration { get; set; }
        public double KnowledgeLevel { get; set; }
        public string PredictedGrade { get; set; }
    }
}
