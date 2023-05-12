namespace Regnology.Data
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public virtual IList<Employee> Employees { get; set; }
    }
}
