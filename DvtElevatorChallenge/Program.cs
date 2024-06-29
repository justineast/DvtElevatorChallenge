// See https://aka.ms/new-console-template for more information

using DvtElevatorChallenge.Bll;
using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

Console.WriteLine("Hello, World!");

var buttonsPressed = new List<int>
{
    1, 5, 4, 6, 7, 3, 4, 5
};

IElevatorHelper helper = new ElevatorHelper(buttonsPressed);
IElevatorControl elevator = new ElevatorControl(helper);

var passengers = new List<Passenger>
{
    new()
    {
        Id = 1,
        PassengerType = Enums.PassengerType.Person,
        SelectedFloor = 4
    },
    new()
    {
        Id = 2,
        PassengerType = Enums.PassengerType.Person,
        SelectedFloor = 3
    },
    new()
    {
        Id = 3,
        PassengerType = Enums.PassengerType.Person,
        SelectedFloor = 1
    },
    new()
    {
        Id = 4,
        PassengerType = Enums.PassengerType.Person,
        SelectedFloor = 5
    }
};
var selectedFloor = -5;
var responseElevator =  elevator.SelectFloor(selectedFloor, passengers);

Console.WriteLine($"The elevator stopped on Floor {responseElevator.CurrentFloor}");