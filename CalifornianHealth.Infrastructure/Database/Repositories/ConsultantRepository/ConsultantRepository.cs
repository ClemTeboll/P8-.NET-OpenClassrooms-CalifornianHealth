using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository
{
    public class ConsultantRepository : IConsultantRepository
    {
        private readonly CalifornianHealthContext _dbContext;

        public ConsultantRepository(CalifornianHealthContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Consultant> FetchConsultants()
        {
            var consultants = _dbContext.Consultants.ToList();
            return consultants;
        }
    }
}
