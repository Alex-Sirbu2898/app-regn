namespace Regnology.Data
{
    public class Project
    {
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime Deadline { get; set; }

    public string ClientId { get; set; }

    public virtual IList<Employee> Employee { get; set; }

    public virtual Client Client { get; set; }
    }
}
