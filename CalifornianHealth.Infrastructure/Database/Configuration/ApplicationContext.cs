using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Configuration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User.Configure(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(default);
        }
        //public UserRepository UserRepository => new UserRepository(Set<User>());
    }
}
