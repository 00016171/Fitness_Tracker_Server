using System.Diagnostics;

namespace FitnessTracker.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; } 
        public double Weight { get; set; } 

        public ICollection<Activity> Activities { get; set; }
    }
}
