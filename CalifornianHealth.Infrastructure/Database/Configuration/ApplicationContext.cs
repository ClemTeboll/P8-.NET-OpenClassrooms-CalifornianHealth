using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Configuration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Consultant.Configure(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(default);
        }
        public ConsultantRepository ConsultantRepository => new(Set<Consultant>());
    }
}
