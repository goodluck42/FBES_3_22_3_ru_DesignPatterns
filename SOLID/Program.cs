// SOLID
// S - Single responsibility
// O - Open-close
// L - Liskov
// I - Interface segregation
// D - Dependency inversion

// Composition

{
    A obj = new A();
}

// Aggregation
{
    Service2 service2 = new Service2();
    Service1 service1 = new Service1(service2);
}


///////////////////

/////////////// Composition classes
class A
{
    private B _service;

    public A()
    {
        _service = new B();
    }
}


class B
{
}

/////////////// Aggregation classes

class Service1
{
    private Service2 _service2;

    public Service1(Service2 service2)
    {
        _service2 = service2;
    }
}

class Service2
{
}


// S - violation

class Person
{
}

class Item
{
}

class PersonManager // Service
{
    private List<Person> _persons = new();

    public void AddPerson(Person person)
    {
    }

    public void AddItem(Item item)
    {
    } // Violation!!!
}

// O - violation

class PersonManager_2
{
    public List<Person> _persons = new(); // Violation!!!

    public void AddPerson(Person person)
    {
    }

    public void RemovePerson(Person person)
    {
    }
}

// L - violation

abstract class Vehicle
{
    public virtual void Move()
    {
    }

    public int Speed { get; set; }
    public int Acceleration { get; set; }

    public abstract void Accelerate(); // Workaround!
}

class Motorcycle : Vehicle
{
    public Motorcycle()
    {
    }

    public override void Move()
    {
    }

    public void Nitro()
    {
    } // Violation!!!

    public override void Accelerate()
    {
        Acceleration += 5;
    }
}

class Bicycle : Vehicle
{
    public Bicycle()
    {
    }

    public override void Move()
    {
    }

    public override void Accelerate()
    {
        Acceleration += 1;
    }
}

// I - violation

class User
{
}

interface IUserManager
{
    void AddUser(User user);
    void RemoveUser(User user);
    void AddUserToDb(User user); // Violation!!!
    void RemoveUserFromDb(User user); // Violation!!!
}

// Workaround

interface ILocalUserManager
{
    void AddUser(User user);
    void RemoveUser(User user);
}

interface IDbUserManager
{
    void AddUserToDb(User user); // Ok!
    void RemoveUserFromDb(User user); // Ok!
}

// D - violation


interface IPerson
{
}

class Employee : IPerson
{
}

class SuperEmployee : IPerson
{
}

interface IEmployeeManager
{
    void AddEmployee(Employee person); // Violation!!!
    void RemoveEmployee(Employee person); // Violation!!!
    
    void AddSuperEmployee(SuperEmployee person); // Violation!!!
    void RemoveSuperEmployee(SuperEmployee person); // Violation!!!

    List<Employee> GetEmployees(); // Violation!!!
    List<SuperEmployee> GetSuperEmployees(); // Violation!!!
}

// Workaround

interface IEmployeeManager_2
{
    void AddPerson(IPerson person); // Ok!
    void RemovePerson(IPerson person); // Ok!
    
    IEnumerable<IPerson> GetPersons(); // Ok!
}