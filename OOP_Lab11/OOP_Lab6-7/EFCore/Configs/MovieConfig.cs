using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP_Lab6_7.EFCore.Entities;
using System.Linq;

namespace OOP_Lab6_7.EFCore.Configs
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity.ToTable(nameof(Movie));

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(128);
            entity.Property(x => x.Director).IsRequired().HasMaxLength(128);
            entity.Property(x => x.Genre).IsRequired().HasMaxLength(64);
            entity.Property(x => x.Duration).IsRequired();
            entity.Property(x => x.Rating).HasColumnType("real");   // вроде избыточно
            entity.Property(x => x.Photo).IsRequired();


            entity.HasMany(x => x.Schedule);  // WithRequired, WithMany??
        }
    }
}
