namespace FactoryDesignPattern.EmployeeApp;

interface IEmployee{
    public int Id { get; set; }
    public string Name { get; set; }
}

/*
 * T - type parameter with rules: must be a class reference type, must inherit "U", must allow creation of "zero" argument object using "zero" argument constructor
 * U - type parameter with rules: must be a class reference type, must inherit "IEmployee" custom reference type.
 */
static class Factory<T,U> where T:class,U,new() where U:class,IEmployee{
    /*
    * We know that "T" inherits "U" as we set the constraint
    * Hence, "U" can be reference type for the object of "T"
    * Hence, we return "U" which holds the object "new T();"
    */
    static U GetInstance(){
        U u = new T();
        return u;
    }
}

public class Program{
    public static void Main(string[] args){

    }
}