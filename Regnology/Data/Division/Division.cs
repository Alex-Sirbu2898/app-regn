namespace Regnology.Data
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual IList<Student> Students { get; set; }
        public virtual IList<Staff> Staffs { get; set; }
    }
}
