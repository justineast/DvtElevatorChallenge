// See https://aka.ms/new-console-template for more information

using DvtElevatorChallenge.Bll;
using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

Console.WriteLine("Hello, World!");

var buttonsPressed = new List<int>
{
    1, 5, 4, 6, 7, 2, 3, 4, 5
};

IElevatorHelper helper = new ElevatorHelper(null, buttonsPressed: buttonsPressed, elevator: null, maxPassengers: 10, topFloor: 4);
IElevatorControl elevator = new ElevatorControl(helper);

var passengers = new List<Passenger>
{
    new()
    {
        Id = 1,
        PassengerType = Enums.PassengerType.Person
    },
    new()
    {
        Id = 2,
        PassengerType = Enums.PassengerType.Person
    },
    new()
    {
        Id = 3,
        PassengerType = Enums.PassengerType.Person
    },
    new()
    {
        Id = 4,
        PassengerType = Enums.PassengerType.Person
    }
};

elevator.SelectFloor(5, passengers);