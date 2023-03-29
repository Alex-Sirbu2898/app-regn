namespace Regnology.Data
{
    public interface IStaffQueryService
    {
        Task<Management> GetById(long id,CancellationToken cancellationToken);
    }
}
