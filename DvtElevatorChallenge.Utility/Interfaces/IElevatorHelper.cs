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
        string MoveElevator(int floorSelected, List<Passenger> numberOfPassengers);
        bool ValidateSelectedFloor(int floorSelected);
    }
}
