namespace Proxy;

public class MemoryRepository : IRepository // gets data from memory
{
    private readonly List<MyFile> _files = new();

    public MyFile? GetFileByName(string name)
    {
        return _files.FirstOrDefault(f => f.Name == name);
    }

    public void AddFile(MyFile file)
    {
        if (_files.Any(f => f.Name == file.Name))
        {
            return;
        }

        _files.Add(file);
    }
}