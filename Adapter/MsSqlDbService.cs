using System.Text;

namespace StructuralPatterns;

public class MsSqlDbService // Third-party service
{
    public object? Get(StringBuilder queryString) // Request data
    {
        Console.WriteLine("MsSqlDb::Get");
        
        return null;
    }

    public void Insert(object data) // Add data
    {
        Console.WriteLine("MsSqlDb::Insert");
    }
}