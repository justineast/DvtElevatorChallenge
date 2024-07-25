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

        /// /// <summary>
        /// Constructor used to set up the Elevator, currentFloor added as an optional for Unit testing purposes
        /// </summary>
        /// <param name="id">Elevator Id</param>
        /// <param name="currentFloor">An optional parameter to help with unit testing of an elevator at a specific floor</param>
        public Elevator(int id, int currentFloor = 0)
        {
            Id = id;
            CurrentFloor = currentFloor;
            Direction = Direction.Up;
            _requests = new List<int>();
            _passengers = new List<Passenger>();
            IsInMaintenance = false;
        }

        /// <summary>
        /// Method used to accept a floor request from a passenger
        /// </summary>
        /// <param name="floor">Selected Floor</param>
        public void AddRequest(int floor)
        {
            if (!_requests.Contains(floor))
            {
                _requests.Add(floor);
            }
        }

        /// <summary>
        /// Method used to add a passenger to the elevator
        /// </summary>
        /// <param name="passenger">The passenger to add</param>
        public void AddPassenger(Passenger passenger)
        {
            if (_passengers.Contains(passenger))
                return;

            _passengers.Add(passenger);
            AddRequest(passenger.DestinationFloor);
        }
        
        /// <summary>
        /// Method used to drop the passenger at the desired floor
        /// </summary>
        private void DropOffPassengers()
        {
            _passengers.RemoveAll(p => p.DestinationFloor == CurrentFloor);
        }
        
        /// <summary>
        /// Method used to perform maintenance on an elevator
        /// Set the Direction/Status of the elevator to stopped
        /// </summary>
        public void PerformMaintenance()
        {
            IsInMaintenance = true;
            Direction = Direction.Stopped;
        }

        /// <summary>
        /// Method used to complete maintenance on an elevator
        /// </summary>
        public void CompleteMaintenance()
        {
            IsInMaintenance = false;
            Direction = Direction.Idle;
            _requests.Clear();
            _passengers.Clear();
        }

        /// <summary>
        /// Method used to manage the movement of the Elevator.
        /// If there are no requests the Direction of the elevator is set to Idle
        /// If there is a request for a floor above the current elevator floor it will move up.
        /// If there is a request for a floor below the current elevator floor it will move down.
        /// Passengers will be dropped off at their desired floor as well
        /// </summary>
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

        /// <summary>
        /// Returns a string that represents the current elevator status.
        /// </summary>
        /// <returns>A string that represents the current elevator status.</returns>
        public override string ToString()
        {
            return $"Elevator {Id}: Current Floor {CurrentFloor}, Direction {Direction}, Maintenance: {(IsInMaintenance ? "Yes" : "No")}, Passengers: {_passengers.Count}";
        }
    }
}
