using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Regnology.Data
{
    public class StaffConfiguration: IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.SalaryBeforeTax).IsRequired();
            builder.Property(x => x.StartYear).IsRequired();
            builder.Property(x => x.StaffId).IsRequired();
            builder.HasIndex(x => x.StaffId).IsUnique();

            builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
