
namespace PhysicistArchive.Entities
{
    public class Physicist : EntityBase
    {
        public string? FieldOfStudy { get; set; }
        public override string ToString() => base.ToString() + $", {FieldOfStudy}";
    };
}