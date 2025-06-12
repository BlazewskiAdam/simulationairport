using System;
using System.Collections.Generic;


public class Airport
{
    private int budget;
    public int Budget
    {
        get { return budget; }
    }
    public List<Plane> Planes { get; set; } //agregacja
    public List<Employee> Employees { get; set; } //agregacja
    private int FuelCostPerFlight { get; }
    private int RepairCost { get; }
    private int DelayCost { get; }
    private int ticketPrice;
    public  int TicketPrice
    {
        get { return ticketPrice; }
        set { ticketPrice = value; }
    }

    public List<Flight> Flights { get; set; } = new List<Flight>();

    public List<string> names = new List<string> { "John", "Anna", "Walter", "Katarzyna", "Jaroslaw", "Jan", "Krol", "Wiktoria", "Henry" };

    Random rand = new Random();
    public string generatename()
    {
        string randomname = names[rand.Next(names.Count)];
        return randomname;
    }

    public Airport(int InitialTicketPrice)
    {
        ticketPrice = InitialTicketPrice;
        Planes = new List<Plane>();
        Employees = new List<Employee>();
        //Budget, FuelCostPeFlight, RepairCost oraz DelayCost beda atrybutami stalymi, ich wartosc bedzie ustalona oczywiscie w tym konstruktorze w dalszej implementacji projektu.
    }
    public void EpochSimulation()
    {
        Flights.Clear();
        foreach (var plane in Planes)
        {
            var pilot = new Pilot(generatename(), 4500);
            // var flight = new Flight(plane, pilot);
            // Flights.Add(flight);
        }
    }
    

    public void CalculateProfit()
    {
        //obliczanie zysku/deficytu budzetu lotniska z jednej epoki
    }
}
