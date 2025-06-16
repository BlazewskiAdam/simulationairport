using System;

public class Plane
{
    private static int counter = 1; 
    private readonly string planeid;
    public string PlaneId
    {
        get { return planeid; }
    }
    public bool Functionality { get; set; }
    public Pilot AssignedPilot { get; set; }

    public int FlightsTotal { get; set; } = 0;
    public int FlightsDelayed { get; set; } = 0;
    public int FlightsCanceled { get; set; } = 0;
    public int PassengersTotal { get; set; } = 0;
    public int IncomeTotal { get; set; } = 0;

    public void Board()
    {
        Console.WriteLine($"Samolot {PlaneId}: pasażerowie wchodzą na pokład.");
    }
    public void Depart()
    {
        Console.WriteLine($"Samolot {PlaneId}: wystartował.");
    }
    public void Landed()
    {
        Console.WriteLine($"Samolot {PlaneId}: wylądował.");
    }

    public void delayed()
    {
        Console.WriteLine("Lot opozniony 30 minut");
    }

    public Plane(bool functionality, Pilot assignedpilot)
    {
        planeid = "PLEU-" + counter;
        counter++;
        this.Functionality = functionality;
        this.AssignedPilot = assignedpilot;
    }
}