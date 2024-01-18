
namespace PhysicistArchive.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? NobelYear { set; get; }

        public override string ToString() => $"{Id}: {Name} {Surname}, {DateOfBirth.Value.ToString("dd.MM.yyyy")} - {DateOfDeath.Value.ToString("dd.MM.yyyy")}";
    }
}