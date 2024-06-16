namespace StudentPerformanceTracker.Models
{
    public class KnowledgeLevel
    {
        public string Subject { get; set; }
        public int Level { get; set; } // 0 - 100


        public KnowledgeLevel(string subject, int level)
        {
            Subject = subject;
            Level = level;
        }
    }
}
