
using PhysicistArchive.Data;
using PhysicistArchive.Entities;
using PhysicistArchive.Repositories;

Console.WriteLine("Hello in PhisicistArchive!!");

var physicistRepo = new SqlRepository<Physicist>(new PADBContext());
AddPhysicists(physicistRepo);
AddExperimentalPhysicist(physicistRepo);
WriteAllToConsole(physicistRepo);

static void AddPhysicists(IRepository<Physicist> physicistRepository)
{
    physicistRepository.Add(new Physicist
    {
        Name = "Mikołaj",
        Surname = "Kopernik",
        DateOfBirth = new DateTime(1473, 2, 19),
        DateOfDeath = new DateTime(1543, 5, 24),
        FieldOfStudy = "Astronomy"

    });
    physicistRepository.Add(new Physicist
    {
        Name = "Isaac",
        Surname = "Newton",
        DateOfBirth = new DateTime(1642, 12, 25),
        DateOfDeath = new DateTime(1727, 3, 20),
        FieldOfStudy = "Newton's Law of Universal Gravitation",
    });

    physicistRepository.Save();
}

static void AddExperimentalPhysicist(IWriteRepository<ExperimentalPhysicist> experimentalRepository)
{
    experimentalRepository.Add(new ExperimentalPhysicist
    {
        Name = "Ernest",
        Surname = "Rutherford",
        DateOfBirth = new DateTime(1871, 8, 30),
        DateOfDeath = new DateTime(1937, 10, 19),
        NobelYear = 1908,
        FieldOfStudy = "Atomic structure",
        Laboratory = "Cavendish Laboratory"
    });

    experimentalRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}