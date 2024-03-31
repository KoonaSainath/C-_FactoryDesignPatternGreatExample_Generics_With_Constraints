namespace FactoryDesignPattern.EmployeeApp;
enum Employee{
    SoftwareEngineer,
    BusinessAnalyst,
    Manager
}
interface IEmployee{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Technology { get; set; }
}

abstract class BaseEmployee : IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual string Technology { get; set; }
}

class SoftwareEngineer : BaseEmployee{
    public override string Technology 
    { 
        get{
            return "Microsoft web development";
        } 
    } 
}

class BusinessAnalyst : BaseEmployee{
    public override string Technology
    {
        get{
            return "Microsoft SQL Server";
        }
    }
}

class Manager : BaseEmployee{
    public override string Technology
    {
        get{
            return "Angular";
        }
    }
}

/*
 * T - type parameter with rules: must be a class reference type, must inherit "U", must allow creation of "zero" argument object using "zero" argument constructor
 * U - type parameter with rules: must be a class reference type, must inherit "IEmployee" custom reference type.
 */
internal static class Factory<T,U> where T:class,U,new() where U:class,IEmployee{
    /*
    * We know that "T" inherits "U" as we set the constraint
    * Hence, "U" can be reference type for the object of "T"
    * Hence, we return "U" which holds the object "new T();"
    */
    internal static U GetInstance(){
        U u = new T();
        return u;
    }
}

public class Program{
    internal static IEmployee CreateEmployeeInstance(Employee employeeEnum, int id, string name){
        IEmployee employee;
        switch(employeeEnum){
            case Employee.SoftwareEngineer:
                employee = Factory<SoftwareEngineer,IEmployee>.GetInstance();
                break;
            case Employee.BusinessAnalyst:
                employee = Factory<BusinessAnalyst,IEmployee>.GetInstance();
                break;
            case Employee.Manager:
                employee = Factory<Manager,IEmployee>.GetInstance();
                break;
            default:
                employee = null;
                break;
        }
        employee.Id = id;
        employee.Name = name;
        return employee;
    }
    public static void Main(string[] args){
        IEmployee softwareEngineer1 = CreateEmployeeInstance(Employee.SoftwareEngineer, 1, "Ben");
        IEmployee softwareEngineer2 = CreateEmployeeInstance(Employee.SoftwareEngineer, 2, "Jimmy");
        IEmployee businessAnalyst1 = CreateEmployeeInstance(Employee.BusinessAnalyst, 3, "Rob");
        IEmployee businessAnalyst2 = CreateEmployeeInstance(Employee.BusinessAnalyst, 4, "Mike");
        IEmployee manager1 = CreateEmployeeInstance(Employee.Manager, 5, "Jack");
        IEmployee manager2 = CreateEmployeeInstance(Employee.Manager, 6, "Kim");

        System.Console.WriteLine($"Software Engineer-1: {softwareEngineer1.Id} - {softwareEngineer1.Name}");
        System.Console.WriteLine($"Software Engineer-2: {softwareEngineer2.Id} - {softwareEngineer2.Name}");
        System.Console.WriteLine($"Business Analyst-1: {businessAnalyst1.Id} - {businessAnalyst1.Name}");
        System.Console.WriteLine($"Business Analyst-2: {businessAnalyst2.Id} - {businessAnalyst2.Name}");
        System.Console.WriteLine($"Manager-1: {manager1.Id} - {manager1.Name}");
        System.Console.WriteLine($"Manager-2: {manager2.Id} - {manager2.Name}");

    }
}