using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorChallenge.Data
{
    public class Enums
    {
        public enum Status
        {
            MovingUp,
            MovingDown,
            Stopped
        }

        public enum ElevatorType
        {
            Passenger,
            Freight,
            HighSpeed,
            Glass,
            Service
        }

        public enum PassengerType
        {
            Person,
            Package
        }
    }
}
