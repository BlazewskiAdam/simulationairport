public class Passenger
{
    public string Name { get; }
    private string passengerId { get; }
    public string PassengerId
    {
        get { return passengerId; }
    }
    // public bool BuyTicket()
    // {
    //informacja o zakupu biletu.
    // }

    public void Board()
    {
        //informacja, potwierdzenie obecnosci pasazera w samolocie
    }

    public Passenger(string name, string passengerId)
    {   
        Name = name;
        this.passengerId = passengerId;
    }
}