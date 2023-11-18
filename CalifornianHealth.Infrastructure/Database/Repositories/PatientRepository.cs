using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories
{
    public class PatientRepository
    {
        private DbSet<Patient> _dbSet;
        public PatientRepository(DbSet<Patient> dbSet)
        //: base(dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
