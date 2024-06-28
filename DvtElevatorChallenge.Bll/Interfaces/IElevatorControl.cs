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
        List<string> SelectFloor(int floorSelected, List<Passenger> passengers);
    }
}
