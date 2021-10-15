using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace appdev.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TraineeUser> TraineeUsers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}