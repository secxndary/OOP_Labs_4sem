using Courses_EF_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Courses_EF_Core.Configs
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> entity)
        {
            entity.ToTable(nameof(Users));

            entity.Property(x => x.Email).IsRequired().IsUnicode(true).HasMaxLength(128);
            entity.Property(x => x.PasswordHash).IsRequired().IsUnicode(true).HasMaxLength(128);
            entity.Property(x => x.UserName).IsRequired().IsUnicode(true).HasMaxLength(128);
            entity.Property(x => x.UserSurname).IsRequired().IsUnicode(true).HasMaxLength(128);
            entity.Property(x => x.IsActive).IsRequired().HasColumnType("bit");

            entity.HasMany(x => x.Roles).WithMany(x => x.Users).UsingEntity<UsersRoles>
            (
                right => right.HasOne<Roles>().WithMany().HasForeignKey(x => x.RoleId),
                left => left.HasOne<Users>().WithMany().HasForeignKey(x => x.UserId),
                join => join.ToTable("UsersRoles")
            );
        }
    }
}
