public class Passenger
{
    public string Name { get; }
    private string passengerId { get; }
    public string PassengerId
    {
        get { return passengerId; }
    }

    public Passenger(string name, string passengerId)
    {
        Name = name;
        this.passengerId = passengerId;
    }

}