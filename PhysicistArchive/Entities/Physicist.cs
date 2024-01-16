
namespace PhysicistArchive.Entities
{
    public class Physicist : EntityBase
    {
        public int? NobelYear { set; get; }
        public override string ToString() => $"{Id}: {Name} {Surname} {Age}";
    }
}