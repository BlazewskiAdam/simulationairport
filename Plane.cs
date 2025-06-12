using System;

public class Plane
{
    private readonly string planeid;
    public string PlaneId
    {
        get { return planeid; }
    }
    public bool Functionality { get; set; }
    public Pilot AssignedPilot { get; }

    public void Board()
    {

    }
    public void Depart()
    {

    }
    // public bool Repair()
    // {

    // }
    Random rand = new Random();
    public Plane( bool functionality, Pilot assignedpilot)
    {
        planeid = "PLEU-" + rand.Next(500, 999);
        functionality = Functionality;
        assignedpilot = AssignedPilot;
    }
}