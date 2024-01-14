
namespace PhysicistArchive.Entities
{
    public class PhysicistNobel : Physicist
    {
        public string? NobelY { set; get; }
        public override string ToString() => $"{Id}: {Name} {Surname} {Age} received the Nobel Prize in {NobelY}";
    }
}