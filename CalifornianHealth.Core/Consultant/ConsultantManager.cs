using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalifornianHealth.Core.Consultant.Contracts;

namespace CalifornianHealth.Core.Consultant
{
    public static class ConsultantManager
    {
        public static async Task<IEnumerable<ConsultantDto>> ListConsultant(IConsultantRepository repository)
        {
            var request = await repository.ToListAsync();

            return request.Select(request => new ConsultantDto
            (
                request.FirstName,
                request.LastName,
                request.Speciality
            ));
        }
    }
}
