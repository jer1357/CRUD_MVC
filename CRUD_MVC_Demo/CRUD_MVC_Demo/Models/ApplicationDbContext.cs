using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_Demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Shipper> Shippers { get; set; }
    }
}