namespace Regnology.Data
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<Role> Management { get; set; }
    }
}
