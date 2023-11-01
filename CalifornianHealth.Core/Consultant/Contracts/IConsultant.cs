using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealth.Core.Consultant.Contracts
{
    public interface IConsultant
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Speciality { get; set; }
    }
}
