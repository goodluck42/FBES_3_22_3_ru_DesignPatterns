namespace StructuralPatterns;

public interface IDbService
{
    object? Query(string queryString);
    void Put(object data);
}