using DvtElevatorChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorChallenge.Bll.Interfaces
{
    public interface IElevatorControl
    {
        string SelectFloor(int floorSelected, int topFloor, int maxPassengers, List<Passenger> numberOfPassengers);
    }
}
