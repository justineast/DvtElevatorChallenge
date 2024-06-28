using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorControl : IElevatorControl
    {
        private readonly IElevatorHelper _elevatorHelper;

        public ElevatorControl(IElevatorHelper elevatorHelper)
        {
            _elevatorHelper = elevatorHelper;
        }

        public List<string> SelectFloor(int floorSelected, List<Passenger> passengers)
        {
            var response = new List<string>();

            if (!_elevatorHelper.ValidateSelectedFloor(floorSelected))
            {
                response.Add(Constants.InvalidError);
            }
            
            _elevatorHelper.MoveElevator(floorSelected, passengers);

            return response;
        }
    }
}