using Microsoft.EntityFrameworkCore;
using WebApplicationTASK14.Models;
namespace WebApplicationTASK14.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        public DbSet<Slide> Slides { get; set; }
    }
}
