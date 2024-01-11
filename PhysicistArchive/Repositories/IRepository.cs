
using PhysicistArchive.Entities;

namespace PhysicistArchive.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}