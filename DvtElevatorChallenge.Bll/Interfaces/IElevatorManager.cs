using DvtElevatorChallenge.Utility;

namespace DvtElevatorChallenge.Bll.Interfaces
{
    //Interface used to create an instance of the ElevatorManager class
    //Lists the methods which are exposed for use
    //Used to access the methods which are used to request the elevator and control the movement of the elevator
    public interface IElevatorManager
    {
        void RequestElevator(Passenger passenger);
        void MoveElevators();
        void PerformMaintenance(int elevatorId);
        void CompleteMaintenance(int elevatorId);
        void PrintStatus();
    }
}
