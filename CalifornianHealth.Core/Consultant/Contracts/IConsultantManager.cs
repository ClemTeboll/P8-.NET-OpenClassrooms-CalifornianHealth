namespace CalifornianHealth.Core.Consultant.Contracts
{
    public interface IConsultantManager
    {
        Task<IEnumerable<ConsultantOutputDto>> ListConsultants();
    }
}
