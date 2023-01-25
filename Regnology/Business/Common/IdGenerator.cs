using System.Text;

namespace Regnology.Business
{
    public class IdGenerator
    {
        public string StudentIdValueGenerator(int enrolmentYear, int gender, string majorAbbreviation)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("D");
            stringBuilder.Append(enrolmentYear.ToString());
            stringBuilder.Append(gender.ToString());
            stringBuilder.Append(majorAbbreviation);
            stringBuilder.Append("-");
            Random rnd = new Random();
            stringBuilder.Append(rnd.Next(10000, 100000).ToString());

            return stringBuilder.ToString();
        }

        public string StaffIdValueGenerator(int startYear)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("F");
            stringBuilder.Append(startYear.ToString());
            stringBuilder.Append("-");
            Random rnd = new Random();
            stringBuilder.Append(rnd.Next(1000, 10000).ToString());

            return stringBuilder.ToString();
        }
    }
}
