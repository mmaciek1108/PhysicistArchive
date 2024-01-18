
namespace PhysicistArchive.Entities
{
    public class ExperimentalPhysicist : Physicist
    {
        public string? Laboratory { get; set; }
        public override string ToString() => base.ToString() + $", {Laboratory}";
    
    }
}