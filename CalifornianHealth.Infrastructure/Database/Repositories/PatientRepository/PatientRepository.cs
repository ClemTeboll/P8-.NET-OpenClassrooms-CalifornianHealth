using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories.PatientRepository;

public class PatientRepository : IPatientRepository
{
    private DbSet<Patient> _dbSet;
    public PatientRepository(DbSet<Patient> dbSet)
    //: base(dbSet)
    {
        _dbSet = dbSet;
    }
}
