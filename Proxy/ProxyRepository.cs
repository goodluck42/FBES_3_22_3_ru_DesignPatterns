using System.Text.Json;

namespace Proxy;

public class ProxyRepository : IRepository // gets data from memory OR ssd
{
    private readonly MemoryRepository _memoryRepository;
    private const string Name = "data.json";

    public ProxyRepository(MemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }
    
    public MyFile? GetFileByName(string name)
    {
        var file = _memoryRepository.GetFileByName(name);
        
        if (file != null)
        {
            Console.WriteLine("Read MyFile from memory!");
            
            return file;
        }
        
        var result = LoadData();

        file = result?.FirstOrDefault(f => f.Name == name);

        if (file != null)
        {
            Console.WriteLine("MyFile read from file!");
            
            Console.WriteLine("Added MyFile to memory!");
            _memoryRepository.AddFile(file);
        }
        
        return file;
    }

    public void AddFile(MyFile file)
    {
        var result = LoadData();

        if (result == null)
        {
            return;
        }

        
        // Added to ssd
        result.Add(file);
        
        File.WriteAllText(Name, JsonSerializer.Serialize(result));
    }

    private List<MyFile>? LoadData()
    {
        var json = File.ReadAllText(Name);
        var result = JsonSerializer.Deserialize<List<MyFile>>(json);

        return result;
    }
}