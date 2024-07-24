using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using System.Drawing;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class ElevatorTest
    {
        [TestMethod]
        public void Move_IsInMaintenanceTrue()
        {
            var elevator = new Elevator(1);
            //Used to set the IsInMaintenance value to true
            elevator.PerformMaintenance();

            elevator.Move();

            Assert.IsTrue(elevator.IsInMaintenance);
        }

        [TestMethod]
        public void Move_IsInMaintenanceFalse_RequestsEqualZero()
        {
            var elevator = new Elevator(1);

            elevator.Move();

            Assert.AreEqual(Enums.Direction.Idle, elevator.Direction);
        }

        [TestMethod]
        public void Move_IsInMaintenanceFalse_RequestsMoreThanZero_CurrentFloorLessThanTarget()
        {
            var elevator = new Elevator(1);

            //Used to Add a request to the Elevator
            elevator.AddRequest(1);

            elevator.Move();
            
            Assert.AreEqual(1, elevator.CurrentFloor);
        }

        [TestMethod]
        public void Move_IsInMaintenanceFalse_RequestsMoreThanZero_CurrentFloorMoreThanTarget()
        {
            //Sets the CurrentFloor of the Elevator
            var elevator = new Elevator(1, 2);

            //Used to Add a request to the Elevator
            elevator.AddRequest(1);

            elevator.Move();

            Assert.AreEqual(1, elevator.CurrentFloor);
        }
        
        [TestMethod]
        public void CompleteMaintenanceTest()
        {
            var elevator = new Elevator(1);
            
            elevator.CompleteMaintenance();

            Assert.AreEqual(Enums.Direction.Idle, elevator.Direction);
        }

        [TestMethod]
        public void PerformMaintenanceTest()
        {
            var elevator = new Elevator(1);

            elevator.PerformMaintenance();

            Assert.IsTrue(elevator.IsInMaintenance);
        }
    }
}