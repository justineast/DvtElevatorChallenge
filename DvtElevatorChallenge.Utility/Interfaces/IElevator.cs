using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        Enums.State State { get; }
        Enums.Direction Direction { get; }
        bool IsInMaintenance { get; }

        void AddRequest(int floor);
        void Move();
        void PerformMaintenance();
        void CompleteMaintenance();
    }
}
