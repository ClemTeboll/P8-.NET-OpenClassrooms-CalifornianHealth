using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealth.Core.Consultant.Contracts
{
    public interface IConsultantRepository : IQueryable<IConsultant> { }
}
