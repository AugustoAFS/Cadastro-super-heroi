using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class SuperHeroDbContext : DbContext
    {
        public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> options) : base(options)
        {}

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
