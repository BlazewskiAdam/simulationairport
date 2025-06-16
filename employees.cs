public abstract class Employee
{
    int counter = 1;
    public string name { get; protected set; }
    public decimal salary { get; protected set; }
    private string Id { get; set; }

    public Employee()
    {
        Id = "AW" + counter;
        counter++;
    }
}

public class SecurityWorker : Employee
{
    private const decimal DefaultSalary = 3000;
    public SecurityWorker(string name) : base()
    {
        this.name = name;
        salary = DefaultSalary;
    }
}

public class CheckInWorker : Employee
{
    private const decimal DefaultSalary = 3000;
    public CheckInWorker(string name) :base()
    {
        this.name = name;
        salary = DefaultSalary;
    }
}

public class Pilot : Employee
{
    private const decimal DefaultSalary = 4500;
    public Pilot(string name) : base()
    {
        this.name = name;
        salary = DefaultSalary;
    }

    public Pilot AssignedPilot { get; set; }
}