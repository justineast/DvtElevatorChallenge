using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Bll.Interfaces;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorManager : IElevatorManager
    {
        private readonly List<Elevator> _elevators;
        private readonly Dictionary<int, List<(int floor, Enums.Direction direction)>> _floorRequests;

        public ElevatorManager(int numberOfElevators)
        {
            _elevators = new List<Elevator>();
            _floorRequests = new Dictionary<int, List<(int floor, Enums.Direction direction)>>();

            for (var i = 0; i < numberOfElevators; i++)
            {
                _elevators.Add(new Elevator(i));
            }
        }

        public void RequestElevator(int floor, Enums.Direction direction)
        {
            if (!_floorRequests.TryGetValue(floor, out List<(int floor, Enums.Direction direction)>? value))
            {
                value = new List<(int floor, Enums.Direction direction)>();
                _floorRequests[floor] = value;
            }

            value.Add((floor, direction));
            AllocateRequests();
        }

        private void AllocateRequests()
        {
            foreach (var floorRequest in _floorRequests.ToList())
            {
                var requests = floorRequest.Value.ToList();
                foreach (var request in requests)
                {
                    var bestElevator = FindBestElevator(request.floor, request.direction);
                    if (bestElevator == null)
                        continue;

                    bestElevator.AddRequest(request.floor);
                    _floorRequests[request.floor].Remove(request);
                    if (_floorRequests[request.floor].Count == 0)
                    {
                        _floorRequests.Remove(request.floor);
                    }
                }
            }
        }

        private Elevator? FindBestElevator(int floor, Enums.Direction direction)
        {
            Elevator? bestElevator = null;
            var minDistance = int.MaxValue;

            foreach (var elevator in _elevators)
            {
                if (elevator.IsInMaintenance) continue;

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

            return bestElevator ?? _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault(e => !e.IsInMaintenance);
        }

        public void MoveElevators()
        {
            foreach (var elevator in _elevators)
            {
                elevator.Move();
            }

            AllocateRequests();
        }

        public void PerformMaintenance(int elevatorId)
        {
            var elevator = _elevators.FirstOrDefault(e => e.Id == elevatorId);
            elevator?.PerformMaintenance();
        }

        public void CompleteMaintenance(int elevatorId)
        {
            var elevator = _elevators.FirstOrDefault(e => e.Id == elevatorId);
            elevator?.CompleteMaintenance();
        }

        public void PrintStatus()
        {
            foreach (var elevator in _elevators)
            {
                Console.WriteLine(elevator);
            }
        }
    }
}