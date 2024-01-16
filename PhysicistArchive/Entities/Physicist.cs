
namespace PhysicistArchive.Entities
{
    public class Physicist : EntityBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Age { get; set; }
        public int? NobelYear { set; get; }
        public override string ToString() => $"{Id}: {Name} {Surname} {Age}";
    }
}