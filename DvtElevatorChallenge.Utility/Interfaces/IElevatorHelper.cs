using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    //Interface used to create an instance of the ElevatorHelper class
    //Lists the methods which are exposed for use
    public interface IElevatorHelper
    {
        Elevator MoveElevator(int floorSelected, List<Passenger> numberOfPassengers);
        bool IsSelectedFloorOutOfRange(int floorSelected);
    }
}
