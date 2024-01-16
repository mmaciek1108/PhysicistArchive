
using PhysicistArchive.Data;
using PhysicistArchive.Entities;
using PhysicistArchive.Repositories;

Console.WriteLine("Hello in PhisicistArchive!!");

var physicistRepo = new SqlRepository<Physicist>(new PADBContext());
AddPhysicists(physicistRepo);
AddChemists(physicistRepo);
WriteAllToConsole(physicistRepo);

static void AddPhysicists(IRepository<Physicist> physicistRepository)
{
    physicistRepository.Add(new Physicist
    {
        Name = "Mikołaj",
        Surname = "Kopernik",
        Age = "XVIIw."
    });
    physicistRepository.Add(new Physicist
    {
        Name = "Giordano",
        Surname = "Bruno",
        Age = "XVIw."
    });
    physicistRepository.Add(new Physicist
    {
        Name = "Isaac",
        Surname = "Newton",
        Age = "XVIIw."
    });
    physicistRepository.Add(new Physicist
    {
        Name = "Albert",
        Surname = "Einstein",
        Age = "XXw.",
        NobelYear = 1921
    });

    physicistRepository.Save();
}
static void AddChemists(IWriteRepository<Chemist> chemistRepository)
{
    chemistRepository.Add(new Chemist
    {
        Name = "Jacobus",
        Surname = "Henricus",
        Age = "XXw.",
        NobelYear = 1901
    });

    chemistRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}