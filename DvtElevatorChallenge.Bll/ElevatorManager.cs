using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> _elevators;
        private readonly Dictionary<int, List<(int floor, Enums.Direction direction)>> _floorRequests;
        private readonly IRequestAllocationStrategy _allocationStrategy;

        public ElevatorManager(int numberOfElevators, IRequestAllocationStrategy allocationStrategy)
        {
            _elevators = new List<IElevator>();
            _floorRequests = new Dictionary<int, List<(int floor, Enums.Direction direction)>>();
            _allocationStrategy = allocationStrategy;

            for (var i = 0; i < numberOfElevators; i++)
            {
                _elevators.Add(new Elevator(i));
            }
        }

        public void RequestElevator(int floor, Enums.Direction direction)
        {
            if (!_floorRequests.TryGetValue(floor, out var value))
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
                    var bestElevator = _allocationStrategy.FindBestElevator(_elevators, request.floor, request.direction);
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