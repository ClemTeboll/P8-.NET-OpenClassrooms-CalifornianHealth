using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository
{
    public class ConsultantRepository : IConsultantRepository
    {
        private DbSet<Consultant> _dbSet;
        private readonly CalifornianHealthContext _dbContext;

        public ConsultantRepository(DbSet<Consultant> dbSet, CalifornianHealthContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;
        }

        public IEnumerable<Consultant> FetchConsultants()
        {
            var consultants = _dbContext.Consultants.ToList();
            return consultants;
        }
    }
}
