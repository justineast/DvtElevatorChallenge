using DvtElevatorChallenge.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility
{
    public class DefaultRequestAllocationStrategy : IRequestAllocationStrategy
    {
        public IElevator FindBestElevator(IEnumerable<IElevator> elevators, int floor, Enums.Direction direction)
        {
            IElevator bestElevator = null;
            var minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                if (elevator.IsInMaintenance) 
                    continue;

                if (elevator.State != Enums.State.Idle &&
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
