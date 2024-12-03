namespace FitnessTracker.Api.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } 
        public string ActivityType { get; set; }
        public double Duration { get; set; } 
        public double Distance { get; set; } 
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
