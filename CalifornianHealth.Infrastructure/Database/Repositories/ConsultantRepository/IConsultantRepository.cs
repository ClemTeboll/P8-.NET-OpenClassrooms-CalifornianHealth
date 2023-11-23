using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;

public interface IConsultantRepository
{
    IEnumerable<Consultant> FetchConsultants();
}
