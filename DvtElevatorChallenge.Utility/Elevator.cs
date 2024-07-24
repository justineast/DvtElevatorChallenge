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

        //Constructor used to set up the Elevator, currentFloor added as an optional for Unit testing purposes
        public Elevator(int id, int currentFloor = 0)
        {
            Id = id;
            CurrentFloor = currentFloor;
            Direction = Direction.Up;
            _requests = new List<int>();
            _passengers = new List<Passenger>();
            IsInMaintenance = false;
        }

        //Method used to accept a floor request from a passenger
        public void AddRequest(int floor)
        {
            if (!_requests.Contains(floor))
            {
                _requests.Add(floor);
            }
        }

        //Method used to add a passenger to the elevator
        public void AddPassenger(Passenger passenger)
        {
            if (_passengers.Contains(passenger))
                return;

            _passengers.Add(passenger);
            AddRequest(passenger.DestinationFloor);
        }

        //Method used to drop the passenger at the desired floor
        private void DropOffPassengers()
        {
            _passengers.RemoveAll(p => p.DestinationFloor == CurrentFloor);
        }

        //Method used to perform maintenance on an elevator
        //Set the Direction/Status of the elevator to stopped
        public void PerformMaintenance()
        {
            IsInMaintenance = true;
            Direction = Direction.Stopped;
        }

        //Method used to complete maintenance on an elevator
        public void CompleteMaintenance()
        {
            IsInMaintenance = false;
            Direction = Direction.Idle;
            _requests.Clear();
            _passengers.Clear();
        }

        //Method used to manage the movement of the Elevator
        //If there are no requests the Direction of the elevator is set to Idle.
        //If there is a request for a floor above the current elevator floor it will move up.
        //If there is a request for a floor below the current elevator floor it will move down.
        //Passengers will be dropped off at their desired floor as well
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

        //Write the output to the console
        public override string ToString()
        {
            return $"Elevator {Id}: Current Floor {CurrentFloor}, Direction {Direction}, Maintenance: {(IsInMaintenance ? "Yes" : "No")}, Passengers: {_passengers.Count}";
        }
    }
}
