
namespace PhysicistArchive.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Age { get; set; }
    }
}