using Bosch.Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bosch.Events.Dal
{
    public class BoschEventsDbContext : DbContext
    {
        public BoschEventsDbContext()
        {

        }
        public BoschEventsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BoschEventsJuly24Db;Trusted_Connection=true;TrustServerCertificate=True;");
            }
        }
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>().HasKey("EventId", "EmployeeId");
            modelBuilder.Entity<Feedback>().HasKey("EventId", "EmployeeId");
        }
    }
}
