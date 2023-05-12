using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Regnology.Data
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).IsRequired();
            
            builder.HasMany(x => x.Employees).WithOne().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
