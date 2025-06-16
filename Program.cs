using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane1 = new Plane(true, null);
            Employee security1 = new SecurityWorker("John");
            Employee checkin1 = new CheckInWorker("Kate");
            
            Airport airport = new Airport(100, plane1, security1, checkin1); 

            while (true)
            {
                Console.WriteLine("\n ----- SYMULACJA LOTNISKA ------");
                Console.WriteLine("1. Uruchom symulacje ");
                Console.WriteLine("2. Dodaj samolot (max 5)");
                Console.WriteLine("3. Dodaj pracownika");
                Console.WriteLine("4. Zmień cenę biletu");
                Console.WriteLine("5. Wyświetl budżet i podsumowanie");
                Console.WriteLine("0. Wyjście");
                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    for (int i= 0; i < 15; i++) airport.EpochSimulation();
                        airport.GetProfit();
                        Console.WriteLine("symulacja zakonczona");
                        airport.SaveStatistics(clearFile: true);
                        break;

                    case "2":
                        if (airport.Planes.Count > 4)
                        {
                            Console.WriteLine("nie ma dostepnych samolotow");
                            break;
                        }

                        airport.Planes.Add(new Plane(true, null)); 
                        Console.WriteLine("Dodano samolot.");
                        break;

                    case "3":
                        Console.WriteLine("Typ pracownika do dodania: 1-Ochrona, 2-Odprawa");
                        string type = Console.ReadLine();
                        Console.Write("Ile chcesz dodać pracowników tego typu? ");
                        int count = int.Parse(Console.ReadLine());

                        for (int i = 0; i < count; i++)
                        {
                            if (type == "1")
                                airport.Employees.Add(new SecurityWorker(airport.generatename()));
                            else if (type == "2")
                                airport.Employees.Add(new CheckInWorker(airport.generatename()));
                        }
                        Console.WriteLine("Dodano pracowników.");
                        break;

                    case "4":
                        Console.Write("Nowa cena biletu: ");
                        int price = int.Parse(Console.ReadLine());
                        airport.TicketPrice = price;
                        Console.WriteLine("Zmieniono cenę biletu.");
                        break;

                    case "5":
                        Console.WriteLine("==========================");
                        Console.Write("\n");
                        Console.WriteLine($"Budżet: {airport.Budget}");
                        Console.WriteLine($"Liczba samolotów: {airport.Planes.Count}");
                        Console.WriteLine($"Liczba pracowników: {airport.Employees.Count}");
                        Console.WriteLine($"Cena biletu: {airport.TicketPrice}");
                        Console.Write("\n");
                        Console.WriteLine("==========================");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            }
        }
    }
}