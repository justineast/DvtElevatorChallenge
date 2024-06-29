using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;
using Serilog;
using Serilog.Events;

namespace DvtElevatorChallenge.Utility
{
    public class ElevatorHelper : IElevatorHelper
    {
        private readonly IPassengerHelper _passengerHelper;
        private List<int> _buttonsPressed;
        private readonly int _maxPassengers;
        private readonly int _topFloor;
        private Elevator _elevator;

        public ElevatorHelper(List<int>? buttonsPressed = null, int maxPassengers = 10, int topFloor = 10, Elevator? elevator = null, IPassengerHelper? passengerHelper = null)
        {
            _passengerHelper = passengerHelper ?? new PassengerHelper();
            _buttonsPressed = buttonsPressed ?? new List<int>();
            _maxPassengers = maxPassengers;
            _topFloor = topFloor;
            _elevator = elevator ?? new Elevator(_maxPassengers, _topFloor, new List<Passenger>());
        }

        public bool IsSelectedFloorOutOfRange(int floorSelected)
        {
            return floorSelected < 0 || floorSelected > _topFloor;
        }

        public Elevator MoveElevator(int floorSelected, List<Passenger> passengers)
        {
            try
            {
                if (floorSelected > _topFloor)
                {
                    Log.Write(LogEventLevel.Error, new ArgumentOutOfRangeException(string.Format(Constants.TopFloorReachedError, _topFloor)), "Failure");
                    return _elevator;
                }

                _elevator.DestinationFloor = floorSelected;
                _elevator.Passengers = passengers;

                if (!_passengerHelper.ValidateNumberOfPassengers(passengers.Count, _maxPassengers))
                {
                    Log.Write(LogEventLevel.Error,
                        new ArgumentOutOfRangeException(string.Format(Constants.MaxPassengersReachedError,
                            _maxPassengers)), "Failure");
                    return _elevator;
                }

                _buttonsPressed.Add(floorSelected);
                _buttonsPressed = _buttonsPressed.Distinct().OrderBy(bp => bp).ToList();

                KeepMovingUntilAllButtonPressesComplete(floorSelected, passengers);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Error, ex, ex.Message);
            }

            return _elevator;
        }

        private void Move(int floorSelected, List<Passenger> passengers)
        {
            var destination = _buttonsPressed.First();
            
            if (destination < floorSelected)
            {
                MoveUp(floorSelected);
            }
            
            if (destination > floorSelected)
            {
                MoveDown(floorSelected);
            }

            _passengerHelper.AddPassengers(_elevator, passengers);
            _passengerHelper.RemovePassengers(_elevator);

            _buttonsPressed.RemoveAt(0);
            _elevator.CurrentFloor = destination;
        }
        
        private void KeepMovingUntilAllButtonPressesComplete(int floorSelected, List<Passenger> passengers)
        {
            while (_buttonsPressed.Count > 0)
            {
                if (IsSelectedFloorOutOfRange(_elevator.CurrentFloor))
                {
                    break;
                }

                _elevator.CurrentFloor = _buttonsPressed.First();

                if (_buttonsPressed.Count > 1)
                {
                    var nextIndex = _buttonsPressed.IndexOf(_elevator.CurrentFloor) + 1;

                    SetValuesForMovement(_buttonsPressed[nextIndex], _elevator.Status);
                }

                Move(_elevator.NextFloor, passengers);
            }

            StopElevator();
        }

        private void MoveUp(int floorSelected)
        {
            SetValuesForMovement(floorSelected, Enums.Status.MovingUp);
        }

        private void MoveDown(int floorSelected)
        {
            SetValuesForMovement(floorSelected, Enums.Status.MovingDown);
        }

        private void StopElevator()
        {
            _elevator.Status = Enums.Status.Stopped;
        }

        private void SetValuesForMovement(int floorSelected, Enums.Status status)
        {
            _elevator.NextFloor = floorSelected;
            _elevator.Status = status;
        }
    }
}