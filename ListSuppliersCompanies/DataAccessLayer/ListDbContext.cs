using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer
{
    public class ListDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public ListDbContext(DbContextOptions<ListDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
