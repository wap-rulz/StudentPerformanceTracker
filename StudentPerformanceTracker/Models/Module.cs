namespace StudentPerformanceTracker.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

		public Module()
		{
		}

		public Module(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }
    }
}
