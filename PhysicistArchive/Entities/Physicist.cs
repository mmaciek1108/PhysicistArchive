
namespace PhysicistArchive.Entities
{
    public class Physicist : EntityBase
    {
        public override string ToString() => $"{Id}: {Name} {Surname} {Age}";
    }
}