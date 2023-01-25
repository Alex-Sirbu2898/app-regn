namespace Regnology.Data
{
    public interface IStaffQueryService
    {
        Task<Staff> GetById(long id,CancellationToken cancellationToken);
    }
}
