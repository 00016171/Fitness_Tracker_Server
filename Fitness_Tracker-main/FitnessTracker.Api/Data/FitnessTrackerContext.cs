using FitnessTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Api.Data
{
    public class FitnessTrackerContext : DbContext
    {
        public FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
