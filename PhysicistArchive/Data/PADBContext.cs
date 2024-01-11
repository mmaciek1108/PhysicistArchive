
using Microsoft.EntityFrameworkCore;
using PhysicistArchive.Entities;

namespace PhysicistArchive.Data
{
    public class PADBContext : DbContext
    {
        public DbSet<Physicist> Physicists => Set<Physicist>();
        public DbSet<PhysicistNobel> PhysicistNobels => Set<PhysicistNobel>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StoragePADb");
        }
    }
}