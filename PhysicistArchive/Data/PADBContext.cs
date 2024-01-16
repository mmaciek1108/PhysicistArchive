
using Microsoft.EntityFrameworkCore;
using PhysicistArchive.Entities;

namespace PhysicistArchive.Data
{
    public class PADBContext : DbContext
    {
        public DbSet<Physicist> Physicists => Set<Physicist>();
        public DbSet<Chemist> Chemists => Set<Chemist>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StoragePADb");
        }
    }
}