namespace CalifornianHealth.Core.Consultant.Contracts;

public interface IConsultantManager
{
    IEnumerable<ConsultantOutputDto> ListConsultants();
}
