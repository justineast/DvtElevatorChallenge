using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorControl : IElevatorControl
    {
        private readonly IElevatorHelper _elevatorHelper;
        private readonly IPassengerHelper _passengerHelper;
        private Dictionary<string, int> _buttonsPressed;

        public ElevatorControl(IElevatorHelper elevatorHelper, IPassengerHelper passengerHelper)
        {
            _elevatorHelper = elevatorHelper ?? new ElevatorHelper();
            _passengerHelper = passengerHelper ?? new PassengerHelper();
            _buttonsPressed = new Dictionary<string, int>();
        }

        public string SelectFloor(int floorSelected, int topFloor, int maxPassengers, List<Passenger> numberOfPassengers)
        {
            var invalidResponse = $"An invalid floor has been selected, please try again";

            if (!_elevatorHelper.ValidateSelectedFloor(floorSelected, topFloor))
            {
                return invalidResponse;
            }

            if (!_buttonsPressed.ContainsValue(floorSelected))
            {
                return invalidResponse;
            }
            
            if (!_passengerHelper.ValidateNumberOfPassengers(numberOfPassengers.Count, maxPassengers))
            {
                return $"The elevator cannot exceed {maxPassengers} passengers.";
            }
            
            var elevator = new Elevator(maxPassengers, 10, numberOfPassengers);
            _elevatorHelper.MoveElevator(elevator, floorSelected, _buttonsPressed);

            return string.Empty;
        }
    }
}