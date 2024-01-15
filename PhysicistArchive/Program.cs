
using PhysicistArchive.Data;
using PhysicistArchive.Entities;
using PhysicistArchive.Repositories;

Console.WriteLine("Hello in PhisicistArchive!!");

var physicistRepo = new SqlRepository<Physicist>(new PADBContext());
AddPhysicists(physicistRepo);
AddPhysicistNobels(physicistRepo);
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

    physicistRepository.Save();
}
static void AddPhysicistNobels(IWriteRepository<PhysicistNobel> physicistNobelRepository)
{
    physicistNobelRepository.Add(new PhysicistNobel
    {
        Name = "Albert",
        Surname = "Einstein",
        Age = "XXw",
        NobelY = 1921
    });
    physicistNobelRepository.Add(new PhysicistNobel
    {
        Name = "Enrico",
        Surname = "Fermi",
        Age = "XXw",
        NobelY = 1938
    });
    physicistNobelRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}