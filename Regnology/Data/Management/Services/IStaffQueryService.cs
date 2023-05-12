namespace Regnology.Data
{
    public interface IStaffQueryService
    {
        Task<Role> GetById(long id,CancellationToken cancellationToken);
    }
}
