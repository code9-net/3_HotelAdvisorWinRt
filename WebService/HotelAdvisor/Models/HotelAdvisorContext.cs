using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelAdvisor.Models
{
    public class HotelAdvisorContext : IdentityDbContext<ApplicationUser>
    {
        public HotelAdvisorContext() : base("DefaultConnection")
        {
        }

        public static HotelAdvisorContext Create()
        {
            return new HotelAdvisorContext();
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TestLog> TestLogs { get; set; }
    }
}