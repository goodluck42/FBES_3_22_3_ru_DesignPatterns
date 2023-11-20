namespace StructuralPatterns;

public class MongoDbService : IDbService
{
    public object? Query(string queryString) // Request data
    {
        Console.WriteLine("MongoDb::Query");
        
        return null;
    }

    public void Put(object data) // Add data
    {
        Console.WriteLine("MongoDb::Put");
    }
}