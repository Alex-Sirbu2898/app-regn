namespace Regnology.Data
{
    public class Management : Employee
    {
        public virtual IList<Employee> Subordinates { get; set; }
    }
}
