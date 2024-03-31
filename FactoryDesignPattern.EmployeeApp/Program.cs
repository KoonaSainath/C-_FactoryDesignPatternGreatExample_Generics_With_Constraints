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
        }
        employee.Id = id;
        employee.Name = name;
        return employee;
    }
    public static void Main(string[] args){
        
    }
}