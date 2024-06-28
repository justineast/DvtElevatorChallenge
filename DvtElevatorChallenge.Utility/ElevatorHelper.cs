using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;
using System.Collections.Generic;

namespace DvtElevatorChallenge.Utility
{
    public class ElevatorHelper : IElevatorHelper
    {
        private readonly IPassengerHelper _passengerHelper;
        private List<int> _buttonsPressed;
        private readonly int _maxPassengers;
        private readonly int _topFloor;
        private Elevator _elevator;

        public ElevatorHelper(IPassengerHelper? passengerHelper, List<int>? buttonsPressed, Elevator? elevator, int maxPassengers, int topFloor)
        {
            _passengerHelper = passengerHelper ?? new PassengerHelper();
            _buttonsPressed = buttonsPressed ?? new List<int>();
            _maxPassengers = maxPassengers;
            _topFloor = topFloor;
            _elevator = elevator ?? new Elevator(_maxPassengers, _topFloor, new List<Passenger>());
        }

        public bool ValidateSelectedFloor(int floorSelected)
        {
            return !(floorSelected < 0 || floorSelected > _topFloor);
        }

        public string MoveElevator(int floorSelected, List<Passenger> passengers)
        {
            var response = string.Empty;

            _elevator.NextFloor = floorSelected;
            _elevator.Passengers = passengers;

            if (!_passengerHelper.ValidateNumberOfPassengers(passengers.Count, _maxPassengers))
            {
                return $"The elevator cannot exceed {_maxPassengers} passengers.";
            }

            _buttonsPressed.Add(floorSelected);
            _buttonsPressed.Sort();
            _buttonsPressed = _buttonsPressed.ToHashSet().ToList();

            CalculateMovement(floorSelected);
            Move(floorSelected, passengers);

            return response;
        }

        private void CalculateMovement(int floorSelected)
        {
            if (_elevator.CurrentFloor == 0 || _elevator.CurrentFloor < floorSelected || _buttonsPressed.Last() < floorSelected)
            {
                MoveUp(floorSelected);
            }

            if (_elevator.CurrentFloor == _elevator.TopFloor || _elevator.CurrentFloor > floorSelected || _buttonsPressed.Last() > floorSelected)
            {
                MoveDown(floorSelected);
            }

            if (floorSelected == _elevator.CurrentFloor)
            {
                _elevator.Status = Enums.Status.Stopped;
            }
        }

        private void Move(int floorSelected, List<Passenger> passengers)
        {
            while (true)
            {
                switch (_elevator?.Status)
                {
                    case Enums.Status.MovingDown: case Enums.Status.MovingUp:
                        KeepMovingUntil();
                        break;

                    case Enums.Status.Stopped:
                        if (floorSelected > _elevator.CurrentFloor)
                        {
                            _elevator.Status = Enums.Status.MovingUp;
                        }

                        if (floorSelected <= _elevator.CurrentFloor)
                        {
                            _elevator.Status = Enums.Status.MovingDown;
                        }

                        continue;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                break;
            }
        }

        private void KeepMovingUntil()
        {
            while (_buttonsPressed.Count > 0)
            {
                _elevator.CurrentFloor = _buttonsPressed.First();

                if (_buttonsPressed.Count > 1)
                {
                    var nextIndex = _buttonsPressed.IndexOf(_elevator.CurrentFloor + 1);
                    
                    SetValuesForMovement(_buttonsPressed[nextIndex], _elevator.Status);
                }

                _buttonsPressed.Remove(_buttonsPressed.First());
            }

            _elevator.Status = Enums.Status.Stopped;
        }

        private void MoveUp(int floorSelected)
        {
            SetValuesForMovement(floorSelected, Enums.Status.MovingUp);
        }

        private void MoveDown(int floorSelected)
        {
            SetValuesForMovement(floorSelected, Enums.Status.MovingDown);
        }

        private void SetValuesForMovement(int floorSelected, Enums.Status status)
        {
            _elevator.NextFloor = floorSelected;
            _elevator.PreviousFloor = _elevator.CurrentFloor;
            _elevator.Status = status;
        }
    }
}