using Regnology.Data;

namespace Regnology.Business
{
    public class GetAllVacationsResponse
    {
        public IEnumerable<Vacation> Vacation { get; set; }
    }
}
