namespace Proxy;

public interface IRepository
{
    MyFile? GetFileByName(string name);
    void AddFile(MyFile file);
}