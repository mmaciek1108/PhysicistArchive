
namespace PhysicistArchive.Entities
{
    public class PhysicistNobel : Physicist
    {
        public override string ToString() => $"{Id}: {Name} {Surname} {Age} received the Nobel Prize in {NobelYear}";
    }
}