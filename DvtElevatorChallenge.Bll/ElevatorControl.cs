using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;
using Serilog;
using Serilog.Events;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorControl : IElevatorControl
    {
        private readonly IElevatorHelper _elevatorHelper;

        public ElevatorControl(IElevatorHelper elevatorHelper)
        {
            _elevatorHelper = elevatorHelper;
        }

        //Method used to Interact with the elevator by pressing a button
        public Elevator SelectFloor(int floorSelected, List<Passenger> passengers)
        {
            try
            {
                if (!_elevatorHelper.IsSelectedFloorOutOfRange(floorSelected))
                    return _elevatorHelper.MoveElevator(floorSelected, passengers);
                
                throw new ArgumentOutOfRangeException(Constants.InvalidError);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Log.Write(LogEventLevel.Error, aore, Constants.InvalidError);
                return new Elevator(0, 0, new List<Passenger>());
            }
        }
    }
}