
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
        Age = "XVw."
    });

    physicistRepository.Save();
}
static void AddPhysicistNobels(IWriteRepository<PhysicistNobel> physicistNobelRepository)
{
    physicistNobelRepository.Add(new PhysicistNobel
    {
        Name = "Fala świetlna to fala elektromagnetyczna",
        Surname = "Tak",
        Age = "Nie",
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