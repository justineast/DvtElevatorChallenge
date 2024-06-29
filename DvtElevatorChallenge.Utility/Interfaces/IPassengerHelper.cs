using DvtElevatorChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IPassengerHelper
    {
        List<Passenger> AddPassengers(Elevator elevator, List<Passenger> passengersToAdd);
        List<Passenger> RemovePassengers(Elevator elevator);
        bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers);
    }
}
