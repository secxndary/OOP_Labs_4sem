using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP_Lab6_7.EFCore.Entities;


namespace OOP_Lab6_7.EFCore.Configs
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> entity)
        {
            entity.ToTable(nameof(Schedule));

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id_Movie).IsRequired();
            entity.Property(x => x.DateTime).IsRequired();

            entity.HasOne(o => o.Movie).WithMany(u => u.Schedule).HasForeignKey(o => o.Id_Movie);

        }
    }
}
