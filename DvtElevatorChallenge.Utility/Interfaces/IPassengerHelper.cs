using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IPassengerHelper
    {
        bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers);
    }
}
