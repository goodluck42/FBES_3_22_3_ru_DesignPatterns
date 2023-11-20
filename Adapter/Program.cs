namespace StructuralPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        // serviceCollection.AddTransient<IDbService, MsSqlDbServiceAdapter>();
        IDbService dbService = new MsSqlDbServiceAdapter(new MsSqlDbService());
        
        dbService.Put("{data: 12}");
        dbService.Query("{data: {$qt: 5}}");
    }
}

// X -> A, B
// Y -> C, D
// YAdapter -> A (Y->C), B (Y->D)