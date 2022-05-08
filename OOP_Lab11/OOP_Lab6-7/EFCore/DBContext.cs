using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OOP_Lab6_7.EFCore.Entities;

namespace OOP_Lab6_7.EFCore
{
    public class DBContext : DbContext
    {
        private const string Connection =
            @"Data Source=DESKTOP-8HNL9IM;Initial Catalog=PREMIUM_CINEMA_TEST1;Integrated Security=True;TrustServerCertificate=Yes;";


        //public DBContext()
        //{

        //}


        public DbSet<Users> Users { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Orders> Orders { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
