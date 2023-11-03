using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database
{
    public class CalifornianHealthContext : DbContext
    {
        public CalifornianHealthContext(DbContextOptions<CalifornianHealthContext> options) : base(options) { }

        protected void OnConfiguring(ModelBuilder modelBuilder)
        {
            DatabaseConfig.Configure(modelBuilder);
        }

        public DbSet<Consultant> Consultants { get; set; }
    }
}
