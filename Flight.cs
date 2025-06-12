using System;
using System.Collections.Generic;

public class Flight
{
    private string FlightNumber { get; }
    public string flightnumber
    {
        get { return FlightNumber; }
    }
    public Plane AssignedPlane { get; }
    public string Status { get; set; }
    public int DelayMinutes { get; set; }

    public Flight(string flightNumber, Plane assignedPlane, string status, int delayminutes)
    {
        FlightNumber = flightNumber;
        AssignedPlane = assignedPlane;
        Status = status;
        DelayMinutes = delayminutes;
    }
    Random rand = new Random();
    public void Schedule(List<Plane> planes, List<Employee> employees)
    {
        foreach (var plane in planes)
        {
            int checkInCount = employees.FindAll(i => i is CheckInWorker).Count;
            int securityCount = employees.FindAll(i => i is SecurityWorker).Count;

            int delaychance = 40 - (checkInCount + securityCount) * 5;
            if (delaychance < 10) delaychance = 10;
            if (delaychance > 40) delaychance = 40;

            bool IsDelayed = rand.Next(50) < delaychance;


            if (IsDelayed)
            {
                Status = "Delayed";
            }
            else
            {
                Status = "Ready";
            }
        }
    }
    
    public bool Cancel()
    {
        int CancelChance = 10;
        bool IsCanceled = rand.Next(50) < CancelChance;

        return IsCanceled;
    }
}               