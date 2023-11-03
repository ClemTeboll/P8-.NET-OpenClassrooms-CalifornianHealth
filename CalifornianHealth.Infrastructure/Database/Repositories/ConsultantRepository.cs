using CalifornianHealth.Core.Consultant.Contracts;
using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CalifornianHealth.Infrastructure.Database.Repositories
{
    public class ConsultantRepository
        //: IConsultantRepository
    {
        public ConsultantRepository(DbSet<Consultant> consultants)
        {
            
        }
    }
}
