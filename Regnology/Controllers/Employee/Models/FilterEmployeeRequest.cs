namespace Regnology.Controllers
{
    public class FilterEmployeeRequest
    {
        public string? SearchString { get; set; }
        public string? sortOrder { get; set; }
        public int? page { get; set; }
    }
}
