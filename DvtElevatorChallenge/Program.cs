// See https://aka.ms/new-console-template for more information

using DvtElevatorChallenge.Bll;
using DvtElevatorChallenge.Data;

var manager = new ElevatorManager(3);

// Simulate some requests
manager.RequestElevator(5, Enums.Direction.Up);
manager.RequestElevator(3, Enums.Direction.Down);
manager.RequestElevator(1, Enums.Direction.Up);

// Perform maintenance on elevator 1
manager.PerformMaintenance(1);

// Move the elevators a few times
for (var i = 0; i < 10; i++)
{
    Console.WriteLine($"--- Step {i + 1} ---");
    manager.MoveElevators();
    manager.PrintStatus();
    Thread.Sleep(1000); // Simulate time passing
}

// Complete maintenance on elevator 1
manager.CompleteMaintenance(1);

// More requests after maintenance
manager.RequestElevator(7, Enums.Direction.Up);
manager.RequestElevator(4, Enums.Direction.Down);

// Move the elevators again
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"--- Step {i + 1} ---");
    manager.MoveElevators();
    manager.PrintStatus();
    Thread.Sleep(1000); // Simulate time passing
}