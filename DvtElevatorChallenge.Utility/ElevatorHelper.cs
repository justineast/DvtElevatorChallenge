using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Utility
{
    public class ElevatorHelper : IElevatorHelper
    {
        public bool ValidateSelectedFloor(int floorSelected, int topFloor)
        {
            return !(floorSelected < 0 || floorSelected > topFloor);
        }

        public string MoveElevator(Elevator elevator, int floorSelected, Dictionary<string, int> buttonsPressed)
        {
            var response = string.Empty;
            
            if (elevator?.Passengers?.Count > elevator?.MaximumPassengers)
            {
                return $"The elevator cannot exceed {elevator?.MaximumPassengers} passengers.";
            }
            
            switch (elevator?.Status)
            {
                case Enums.Status.MovingDown:
                    while (buttonsPressed.Count > 0)
                    {
                        //MoveDown(ButtonPresses.Remove());

                        //TODO: Remove item from the dictionary/queue (TBD)
                    }

                    elevator.Status = Enums.Status.Stopped;
                    break;

                case Enums.Status.MovingUp:
                    while (buttonsPressed.Count > 0)
                    {
                        //MoveUp(ButtonPresses.Remove());

                        //TODO: Remove item from the dictionary/queue (TBD)
                    }

                    elevator.Status = Enums.Status.Stopped;
                    break;

                case Enums.Status.Stopped:
                    if (floorSelected > elevator.CurrentFloor)
                    {
                        elevator.Status = Enums.Status.MovingUp;
                    }

                    if (floorSelected <= elevator.CurrentFloor)
                    {
                        elevator.Status = Enums.Status.MovingDown;
                    }
                    //Move(floor);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return response;
        }

        private void CalculateMovement()
        {
            //TODO: calculate which elevator should move to the require position first
        }

        private void CalculateCurrentPosition()
        {
            //TODO: calculate where the elevator is currently
        }

        private string MoveUp()
        {
            //_buttonsPressed.Add("up", _elevator.NextFloor);
            return "up";
        }

        private string MoveDown()
        {
            //_buttonsPressed.Add("down", _elevator.NextFloor);
            return "down";
        }
    }
}