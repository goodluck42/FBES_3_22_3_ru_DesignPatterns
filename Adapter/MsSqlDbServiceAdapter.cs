using System.Text;

namespace StructuralPatterns;

public class MsSqlDbServiceAdapter : IDbService
{
    private MsSqlDbService _msSqlDbService;
    
    public MsSqlDbServiceAdapter(MsSqlDbService msSqlDbService)
    {
        _msSqlDbService = msSqlDbService;
    }
    
    public object? Query(string queryString)
    {
        var builder = new StringBuilder();

        builder.Append(queryString);

        return _msSqlDbService.Get(builder);
    }

    public void Put(object data)
    {
        _msSqlDbService.Insert(data);
    }
}