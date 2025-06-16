using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

public class Airport
{
    private int budget;
    public int Budget
    {
        get { return budget; }
    }
    public int totalprofit { get; set; }
    public List<Plane> Planes { get; set; } 
    public List<Employee> Employees { get; set; } 
    private static  int FuelCostPerFlight { get; set; }
    private static  int RepairCost { get; set; }
    private static int DelayCost { get; set; }
    private int ticketPrice;
    public int TicketPrice
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

    public Airport(int InitialTicketPrice, Plane plane, Employee employee, Employee employee1)
    {
        ticketPrice = InitialTicketPrice;
        Planes = new List<Plane>();
        Employees = new List<Employee>();
        Flights = new List<Flight>();
        budget = 100000;
        FuelCostPerFlight = 9000;
        RepairCost = 8000;
        DelayCost = 7000;
    }

    public void EpochSimulation()
    {
        foreach (var plane in Planes)
        {
            var pilot = new Pilot(generatename());
            plane.AssignedPilot = pilot;
            var flight = new Flight(plane);
            flight.Schedule(Planes, Employees);

            int passengers = CalculatePassengers(TicketPrice);
            flight.PassengerCount = passengers;

            plane.Board();
            System.Threading.Thread.Sleep(500);

            if (flight.Status != "Canceled" && flight.Status != "Delayed")
            {
                plane.FlightsTotal++;
                plane.PassengersTotal += passengers;
                plane.IncomeTotal += passengers * TicketPrice;

                plane.Depart();
                System.Threading.Thread.Sleep(500);
                plane.Landed();
                System.Threading.Thread.Sleep(500);


                Flights.Add(flight);
                Console.WriteLine("Status lotu: WYKONANY");
            }
            else if (flight.Status == "Canceled")
            {
                plane.FlightsCanceled++;
                string reason = flight.CheckCancelReason();
                Console.WriteLine($"Samolot {plane.PlaneId}: lot anulowany, powód: {reason}");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("Status lotu: ANULOWANY");
            }
            else
            {
                plane.FlightsDelayed++;
                plane.FlightsTotal++;
                plane.PassengersTotal += passengers;
                plane.IncomeTotal += passengers * TicketPrice;

                plane.delayed();
                System.Threading.Thread.Sleep(1000);
                plane.Depart();
                System.Threading.Thread.Sleep(500);
                plane.Landed();
                Console.WriteLine("Status lotu: OPÓŹNIONY");
            }

            Console.WriteLine(new string('=', 40));
            System.Threading.Thread.Sleep(800);
            Console.WriteLine();
        }
    }
    public void RemoveCanceledFlights()
    {
        Flights.RemoveAll(flight => flight.Status == "Canceled");
    }

    private int CalculatePassengers(int ticketPrice)
{
    int maxPassengers = 180;
    int minPassengers = 10;
    int maxPrice = 300;

    int passengers = maxPassengers - (ticketPrice * (maxPassengers - minPassengers) / maxPrice);
    if (passengers < minPassengers) passengers = minPassengers;
    return passengers;
}

    private int CalculateProfit()
    {
        int totalIncome = Planes.Sum(p => p.IncomeTotal);
        int salaries = Employees.Sum(e => (int)e.salary);
        int fuel = Planes.Sum(p => p.FlightsTotal) * FuelCostPerFlight;
        int delay = Planes.Sum(p => p.FlightsDelayed) * DelayCost;
        int repair = Flights.Count(f => f.Status == "Canceled" && f.AssignedPlane.Functionality == false) * RepairCost;
        int profit = totalIncome - salaries - fuel - repair - delay;
        budget += profit;
        return profit;
    }

    public int GetProfit()
    {
    return CalculateProfit();
    }

    public void SaveStatistics(string FilePath = "statistics.csv", bool clearFile = false)
    {
        string header = "Samolot,Pilot,Loty,Opóźnione,Anulowane,Liczba pasazerow,Przychód";
        if (clearFile || !File.Exists(FilePath))
            File.WriteAllText(FilePath, header + Environment.NewLine);

        foreach (var plane in Planes)
        {
            string pilotName = plane.AssignedPilot != null ? plane.AssignedPilot.name : "brak";
            string line = $"{plane.PlaneId},{pilotName},{plane.FlightsTotal},{plane.FlightsDelayed},{plane.FlightsCanceled},{plane.PassengersTotal},{plane.IncomeTotal}";
            File.AppendAllText(FilePath, line + Environment.NewLine);
        }
        int netProfit = Budget - 100000;
        File.AppendAllText(FilePath, Environment.NewLine + $"Zysk netto lotniska:;{netProfit}" + Environment.NewLine);
    }
}
