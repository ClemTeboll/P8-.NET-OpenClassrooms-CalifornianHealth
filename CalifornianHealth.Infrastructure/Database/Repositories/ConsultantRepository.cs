using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories
{
    public class ConsultantRepository
        //: IConsultant, IConsultantRepository
    {
        private DbSet<Consultant> _dbSet;
        public ConsultantRepository(DbSet<Consultant> dbSet)
            //: base(dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
