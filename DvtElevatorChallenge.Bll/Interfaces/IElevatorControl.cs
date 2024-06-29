using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Bll.Interfaces
{
    //Interface used to create an instance of the ElevatorControl class
    //Lists the methods which are exposed for use
    public interface IElevatorControl
    {
        Elevator SelectFloor(int floorSelected, List<Passenger> passengers);
    }
}
