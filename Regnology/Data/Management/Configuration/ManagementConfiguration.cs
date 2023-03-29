using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Regnology.Data
{
    public class ManagementConfiguration: IEntityTypeConfiguration<Management>
    {
        public void Configure(EntityTypeBuilder<Management> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasColumnType("nvarchar(150)");
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.CNP).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.IdSeriesNumber).IsRequired();

            builder.HasIndex(x => x.EmployeeId).IsUnique();
            builder.HasIndex(x => x.CNP).IsUnique();


            builder.HasOne(x => x.Division).WithMany().HasForeignKey(x => x.DivisionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Subordinates).WithOne().HasForeignKey(x => x.ManagerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
