using Courses_EF_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courses_EF_Core.Configs
{
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> entity)
        {
            entity.ToTable(nameof(Roles));

            entity.HasKey(x => x.Id);
            entity.Property(x => x.RoleName).IsRequired().IsUnicode().HasMaxLength(32);
        }
    }
}
