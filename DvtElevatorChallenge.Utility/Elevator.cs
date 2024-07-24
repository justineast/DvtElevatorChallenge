using DvtElevatorChallenge.Utility.Interfaces;
using static DvtElevatorChallenge.Data.Enums;

namespace DvtElevatorChallenge.Utility
{
    public class Elevator : IElevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public Direction Direction { get; private set; }
        private readonly List<int> _requests;
        private readonly List<Passenger> _passengers;
        public bool IsInMaintenance { get; private set; }

        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = 0;
            Direction = Direction.Up;
            _requests = new List<int>();
            _passengers = new List<Passenger>();
            IsInMaintenance = false;
        }

        public void AddRequest(int floor)
        {
            if (!_requests.Contains(floor))
            {
                _requests.Add(floor);
            }
        }

        public void AddPassenger(Passenger passenger)
        {
            if (_passengers.Contains(passenger)) 
                return;

            _passengers.Add(passenger);
            AddRequest(passenger.DestinationFloor);
        }

        private void DropOffPassengers()
        {
            _passengers.RemoveAll(p => p.DestinationFloor == CurrentFloor);
        }

        public void PerformMaintenance()
        {
            IsInMaintenance = true;
        }

        public void CompleteMaintenance()
        {
            IsInMaintenance = false;
            Direction = Direction.Idle;
            _requests.Clear();
            _passengers.Clear();
        }

        public void Move()
        {
            if (IsInMaintenance)
            {
                return;
            }

            if (_requests.Count > 0)
            {
                _requests.Sort((a, b) => Math.Abs(CurrentFloor - a) - Math.Abs(CurrentFloor - b));
                var targetFloor = _requests[0];

                if (CurrentFloor < targetFloor)
                {
                    Direction = Direction.Up;
                    CurrentFloor++;
                }
                else if (CurrentFloor > targetFloor)
                {
                    Direction = Direction.Down;
                    CurrentFloor--;
                }

                if (CurrentFloor != targetFloor) 
                    return;

                _requests.RemoveAt(0);
                DropOffPassengers();

                if (_requests.Count == 0)
                {
                    Direction = Direction.Idle;
                }
            }
            else
            {
                Direction = Direction.Idle;
            }
        }

        public override string ToString()
        {
            return $"Elevator {Id}: Floor {CurrentFloor}, Direction {Direction}, Maintenance: {IsInMaintenance}, Passengers: {_passengers.Count}";
        }
    }
}
