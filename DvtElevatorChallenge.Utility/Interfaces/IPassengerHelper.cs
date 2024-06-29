using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    //Interface used to create an instance of the PassengerHelper class
    //Lists the methods which are exposed for use
    public interface IPassengerHelper
    {
        List<Passenger> AddPassengers(Elevator elevator, List<Passenger> passengersToAdd);
        List<Passenger> RemovePassengers(Elevator elevator);
        bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers);
    }
}
