namespace Regnology.Controllers
{
    public class FilterStudentRequest
    {
        public string? SearchString { get; set; }
        public string? sortOrder { get; set; }
        public int? page { get; set; }
    }
}
