// See https://aka.ms/new-console-template for more information

using DvtElevatorChallenge.Bll;
using DvtElevatorChallenge.Utility;

try
{
    var allocationStrategy = new DefaultRequestAllocationStrategy();
    var manager = new ElevatorManager(3, allocationStrategy);

    // Simulate some passenger requests
    try
    {
        var passenger1 = new Passenger(1, 0, 5);
        var passenger2 = new Passenger(2, 3, 1);
        var passenger3 = new Passenger(3, 2, 8);

        manager.RequestElevator(passenger1);
        manager.RequestElevator(passenger2);
        manager.RequestElevator(passenger3);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating passengers: {ex.Message}");
    }

    // Perform maintenance on elevator 1
    manager.PerformMaintenance(1);

    // Move the elevators a few times
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"--- Step {i + 1} ---");
        manager.MoveElevators();
        manager.PrintStatus();
        Thread.Sleep(1000); // Simulate time passing
    }

    // Complete maintenance on elevator 1
    manager.CompleteMaintenance(1);

    // More passenger requests after maintenance
    try
    {
        var passenger4 = new Passenger(4, 6, 2);
        var passenger5 = new Passenger(5, 1, 7);

        manager.RequestElevator(passenger4);
        manager.RequestElevator(passenger5);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating passengers: {ex.Message}");
    }

    // Move the elevators again
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"--- Step {i + 1} ---");
        manager.MoveElevators();
        manager.PrintStatus();
        Thread.Sleep(1000); // Simulate time passing
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}