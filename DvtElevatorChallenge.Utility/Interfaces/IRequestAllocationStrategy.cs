using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IRequestAllocationStrategy
    {
        IElevator FindBestElevator(IEnumerable<IElevator> elevators, int floor, Enums.Direction direction);
    }
}
