
namespace PhysicistArchive.Entities
{
    public class Chemist : EntityBase
    {
        public string? ResearchArea { get; set; }

        public override string ToString() => base.ToString() + $", {ResearchArea}";
    }
}