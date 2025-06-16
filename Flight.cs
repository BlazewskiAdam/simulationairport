using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

public class Flight
{
    int counter = 1;
    public int PassengerCount { get; set; }
    private string FlightNumber { get; }
    public string flightnumber
    {
        get { return FlightNumber; }
    }
    public Plane AssignedPlane { get; }
    public string Status { get; set; }
    public int DelayMinutes { get; set; }
    public string CancelReason { get; set; } 

    public Flight(Plane assignedPlane)
    {
        FlightNumber = "FL" + counter;
        counter++;
        AssignedPlane = assignedPlane;
        DelayMinutes = 30;
    }
    Random rand = new Random();
    public void Schedule(List<Plane> planes, List<Employee> employees)
    {
        int minCheckIn = planes.Count * 2; 
        int minSecurity = planes.Count;    

        int checkInCount = employees.Count(e => e is CheckInWorker);
        int securityCount = employees.Count(e => e is SecurityWorker);

        int delayChance = 20;

        delayChance += Math.Max(0, minCheckIn - checkInCount) * 10;
        delayChance += Math.Max(0, minSecurity - securityCount) * 10;

        delayChance -= Math.Max(0, checkInCount - minCheckIn) * 5;
        delayChance -= Math.Max(0, securityCount - minSecurity) * 5;

        if (delayChance < 5) delayChance = 5;
        if (delayChance > 70) delayChance = 70;


        int cancelChance = 15;
        int randomize = rand.Next(100);

        if (randomize < cancelChance)
        {
            Status = "Canceled";
            return;
        }

        if (rand.Next(100) < delayChance)
        {
            Status = "Delayed";
            DelayMinutes = 30;
            return;
        }
        else
        {
            Status = "Ready";
            DelayMinutes = 0;
            return;
        }
    }

    public string CheckCancelReason()
    {
        int chance = rand.Next(2); 
        if (chance == 0)
        {
            return "Lot anulowany z powodu złej pogody.";
        }
        else
        {
            AssignedPlane.Functionality = false;
            return "Lot anulowany z powodu awarii samolotu.";
        }
    }

    public List<Passenger> Passengers { get; set; } = new List<Passenger>();

    public void GeneratePassengers(int count, string name)
    {
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            string id = "PSNG" + counter;
            Passengers.Add(new Passenger(name, id));
        }
    }
}