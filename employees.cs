public abstract class Employee
{
    protected Employee(string name, decimal salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public string name { get; }
    public decimal salary { get; }  
}

public class SecurityWorker : Employee
{
    public SecurityWorker(string name, decimal salary) : base(name, salary)
    {
        
    }

    public void InspectPassenger(Passenger passenger)
    {

    }

}

public class CheckInWorker : Employee
{
    public CheckInWorker(string name, decimal salary) : base(name, salary)
    {
        
    }
    public void CheckInPassenger(Passenger passenger)
    {

    }
}

public class Pilot : Employee
{
    public Pilot(string name, decimal salary) : base(name, salary)
    {

    }
    
    public void FlyPlane()
    {

    }

}