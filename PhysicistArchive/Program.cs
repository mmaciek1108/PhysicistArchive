
using PhysicistArchive.Entities;
using PhysicistArchive.Repositories;

Console.WriteLine("Hello in PhisicistArchive!!");

var physicistRepoInFile = new RepositoryInFile<Physicist>("physicists.json");
var chemistRepoInFile = new RepositoryInFile<Chemist>("chemists.json");


while (true)
{
    Console.WriteLine("Choose option");
    Console.WriteLine("Press 1 to Add New Physicist");
    Console.WriteLine("Press 2 to Add New Chemist");
    Console.WriteLine("Press 3 to View All Physicists");
    Console.WriteLine("Press 4 to View all Nobel Prize Laureates");
    Console.WriteLine("Press 5 to delete Physicist from file");
    Console.WriteLine("Press 6 to View All Chemists");
    Console.WriteLine("Press 7 to delete Chemist from file");
    Console.WriteLine("To exit insert 'x' ");

    var userChoise = Console.ReadLine();
    try
    {
        switch (userChoise)
        {
            case "1":
                AddNewPhysicist(physicistRepoInFile);
                break;
            case "2":
                AddNewChemist(chemistRepoInFile);
                break;
            case "3":
                WriteAllToConsole(physicistRepoInFile);
                break;
            case "4":
                ViewNobelPrizeLaureates(physicistRepoInFile);
                break;
            case "5":
                DeleteItem<Physicist>(physicistRepoInFile);
                break;
            case "6":
                WriteAllToConsole(chemistRepoInFile);
                break;
            case "7":
                DeleteItem<Chemist>(chemistRepoInFile);
                break;

            case "x":
            case "X":
                return;
            default:
                Console.WriteLine("Invalid operation!");
                break;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception caught: {e.Message}");
    }
}

static int? ConvertToInt(string value, bool allowEmpty = false)
{
    if (allowEmpty && string.IsNullOrWhiteSpace(value))
    {
        return null;
    }
    if (int.TryParse(value, out int number))
    {
        Console.WriteLine("The conversion success.");
        return number;
    }
    else
    {
        Console.WriteLine("The conversion wasn't successful.");
        return null;
    }
}

void ViewNobelPrizeLaureates(RepositoryInFile<Physicist> physicistRepoInFile)
{
    var nobelLaureates = physicistRepoInFile.GetAll().Where(p => p.NobelYear.HasValue).ToList();
    if (nobelLaureates.Any())
    {
        foreach (var laureate in nobelLaureates)
        {
            Console.WriteLine($"Name: {laureate.Name} {laureate.Surname}, Year: {laureate.NobelYear}");
        }
    }
    else
    {
        Console.WriteLine("No Nobel Prize Laureates found.");
    }
}

void AddNewPhysicist(RepositoryInFile<Physicist> physicistRepoInFile)
{
    Console.WriteLine("Insert name:");
    var namePhysicist = Console.ReadLine();

    Console.WriteLine("Insert surname:");
    var surnamePhysicist = Console.ReadLine();

    var dateOfBirthInt = PromptForYear("Insert Date of birth:");
    var dateOfDeathInt = PromptForYear("Insert Date of death (year) or leave empty if still alive:");

    Console.WriteLine("Insert field of study:");
    var fieldOfStudy = Console.ReadLine();

    var nobelPrizeYear = PromptForYear("Insert Nobel Prize Year (leave empty if none):");

    physicistRepoInFile.Add(new Physicist
    {
        Name = namePhysicist,
        Surname = surnamePhysicist,
        FieldOfStudy = fieldOfStudy,
        DateOfBirth = dateOfBirthInt,
        DateOfDeath = dateOfDeathInt,
        NobelYear = nobelPrizeYear
    });

    physicistRepoInFile.Save();
    Console.WriteLine("Physicist added!");
}

void AddNewChemist(RepositoryInFile<Chemist> chemistRepoInFile)
{
    Console.WriteLine("Insert name:");
    var nameChemist = Console.ReadLine();

    Console.WriteLine("Insert surname:");
    var surnameChemist = Console.ReadLine();

    var dateOfBirthInt = PromptForYear("Insert Date of birth:");
    var dateOfDeathInt = PromptForYear("Insert Date of death (year) or leave empty if still alive:");

    Console.WriteLine("Insert Research Area:");
    var researchArea = Console.ReadLine();

    var nobelPrizeYear = PromptForYear("Insert Nobel Prize Year (leave empty if none):");

    chemistRepoInFile.Add(new Chemist
    {
        Name = nameChemist,
        Surname = surnameChemist,
        ResearchArea = researchArea,
        DateOfBirth = dateOfBirthInt,
        DateOfDeath = dateOfDeathInt,
        NobelYear = nobelPrizeYear
    });
    chemistRepoInFile.Save();
    Console.WriteLine("Chemist added! ");
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static int? PromptForYear(string promptMessage)
{
    while (true)
    {
        Console.WriteLine(promptMessage);
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if (int.TryParse(input, out int year))
        {
            if (year > 0 && year <= DateTime.Now.Year)
            {
                return year;
            }
            else
            {
                Console.WriteLine("Please enter a valid year (greater than 0 and not in the future).");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}

void DeleteItem<T>(RepositoryInFile<T> repository) where T : class, IEntity
{
    WriteAllToConsole(repository);
    Console.WriteLine("Enter the Id to delete:");
    var deleteId = Console.ReadLine();
    var deleteIdInt = ConvertToInt(deleteId, true);
    if (deleteIdInt.HasValue)
    {
        try
        {
            var item = repository.GetById(deleteIdInt.Value);
            if (item != null)
            {
                repository.Remove(item);
                repository.Save();
                Console.WriteLine($"{typeof(T).Name} deleted successfully.");
            }
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"{typeof(T).Name} not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }
}
