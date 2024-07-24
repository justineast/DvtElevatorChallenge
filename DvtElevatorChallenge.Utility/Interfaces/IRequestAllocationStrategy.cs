using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IRequestAllocationStrategy
    {
        IElevator FindBestElevator(IEnumerable<IElevator> elevators, int floor, Enums.Direction direction);
    }
}
