
namespace PhysicistArchive.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? DateOfBirth { get; set; }
        public int? DateOfDeath { get; set; }
        public int? NobelYear { set; get; }

        public override string ToString() => $"{Id}: {Name} {Surname}, {DateOfBirth} - {DateOfDeath}";
    }
}