using DvtElevatorChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IElevatorHelper
    {
        string MoveElevator(Elevator elevator, int floorSelected, Dictionary<string, int> buttonsPressed);
        bool ValidateSelectedFloor(int floorSelected, int topFloor);
    }
}
