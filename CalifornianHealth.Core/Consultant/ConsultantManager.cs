using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Core.Consultant
{
    public class ConsultantManager : IConsultantManager
    {
        private readonly IConsultantRepository _consultantRepository;

        public ConsultantManager(IConsultantRepository consultantRepository)
        {
            _consultantRepository = consultantRepository;
        }
        public Task<IEnumerable<ConsultantOutputDto>> ListConsultants()
        {
            var request = _consultantRepository.FetchConsultants();

            return (Task<IEnumerable<ConsultantOutputDto>>)request.Select(request => new ConsultantOutputDto
            (
                request.FirstName,
                request.LastName,
                request.Speciality
            ));
        }
    }
}
