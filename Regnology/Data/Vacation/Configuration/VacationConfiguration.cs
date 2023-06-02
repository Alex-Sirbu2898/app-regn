using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Regnology.Data
{
    public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NoOfUsedDays).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();

            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
