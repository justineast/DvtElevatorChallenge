using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        Enums.Direction Direction { get; }
        bool IsInMaintenance { get; }

        void AddPassenger(Passenger passenger);
        void AddRequest(int floor);
        void Move();
        void PerformMaintenance();
        void CompleteMaintenance();
    }
}
