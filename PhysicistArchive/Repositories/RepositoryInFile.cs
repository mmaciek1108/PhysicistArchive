
using System.Text.Json;
using PhysicistArchive.Entities;

namespace PhysicistArchive.Repositories;
public class RepositoryInFile<T> : IRepository<T> where T : class, IEntity
{
    private List<T>? items = new List<T>();
    private readonly string filePath;
    public event EventHandler<T> ItemAdded;
    public event EventHandler<T> ItemDeleted;

    public RepositoryInFile(string fileName)
    {
        filePath = fileName;
        LoadItems();
        this.ItemAdded += OnItemAdded;
        this.ItemDeleted += OnItemDeleted;
    }


    private void LoadItems()
    {
        if (File.Exists(filePath))
        {
            using (var reader = File.OpenText(filePath))
            {
                var line = reader.ReadLine();
                items = JsonSerializer.Deserialize<List<T>>(line) ?? new List<T>();
            }
        }
    }
    public void Add(T item)
    {
        items.Add(item);
        item.Id = items.Count();
        ItemAdded?.Invoke(this, item);
    }

    public IEnumerable<T> GetAll() => items ?? new List<T>();

    public T GetById(int id)
    {
        return items[id - 1]; // to trzeba sprawdzic 
    }

    public void Remove(T item)
    {
        items.Remove(item);
        ItemDeleted?.Invoke(this, item);
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            var json = JsonSerializer.Serialize(items);
            writer.WriteLine(json);
        }
    }

    private void OnItemAdded(object sender, T item)
    {
        LogChange($"Added: {item.ToString()}");
    }

    private void OnItemDeleted(object sender, T item)
    {
        LogChange($"Deleted: {item.ToString()}");
    }

    private void LogChange(string message)
    {
        string logFilePath = "ChangeLog.txt";
        using (StreamWriter sw = File.AppendText(logFilePath))
        {
            sw.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}