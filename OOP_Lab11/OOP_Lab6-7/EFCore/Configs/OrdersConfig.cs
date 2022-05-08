using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP_Lab6_7.EFCore.Entities;
using System.Linq;

namespace OOP_Lab6_7.EFCore.Configs
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> entity)
        {
            entity.ToTable(nameof(Orders));

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id_User).IsRequired();
            entity.Property(x => x.Id_Schedule).IsRequired();

            entity.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.Id_User);
        }
    }
}
