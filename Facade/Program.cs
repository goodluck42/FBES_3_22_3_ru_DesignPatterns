// See https://aka.ms/new-console-template for more information

Console.WriteLine();



public class AuthService
{
}

public class RegisterService
{
}

public class Facade
{
    public Facade(AuthService authService, RegisterService registerService)
    {
        AuthService = authService;
        RegisterService = registerService;
    }

    public AuthService AuthService { get; set; }
    public RegisterService RegisterService { get; set; }

    // ...
}

public static class StaticFacade
{
    public static AuthService? AuthService { get; set; }
    public static RegisterService? RegisterService { get; set; }

    // ...
}