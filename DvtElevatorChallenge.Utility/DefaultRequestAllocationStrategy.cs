using DvtElevatorChallenge.Utility.Interfaces;
using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility
{
    public class DefaultRequestAllocationStrategy : IRequestAllocationStrategy
    {
        //Logic is applied to find the best elevator for the desired floor request
        //If the elevator is currently being maintained it will not be requested to pick up the passenger
        //Logic is applied to check the shortest distance to the next floor request
        public IElevator FindBestElevator(IEnumerable<IElevator> elevators, int floor, Enums.Direction direction)
        {
            IElevator bestElevator = null;
            var minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                if (elevator.IsInMaintenance) 
                    continue;

                if (elevator.Direction != Enums.Direction.Idle &&
                    (elevator.Direction != Enums.Direction.Up || direction != Enums.Direction.Up ||
                     elevator.CurrentFloor > floor) &&
                    (elevator.Direction != Enums.Direction.Down || direction != Enums.Direction.Down ||
                     elevator.CurrentFloor < floor))
                    continue;

                var distance = Math.Abs(elevator.CurrentFloor - floor);
                if (distance >= minDistance) 
                    continue;

                bestElevator = elevator;
                minDistance = distance;
            }

            return bestElevator ?? elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault(e => !e.IsInMaintenance);
        }
    }
}
