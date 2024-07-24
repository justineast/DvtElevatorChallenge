using DvtElevatorChallenge.Utility;

namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class ElevatorTest
    {
        [TestMethod]
        public void AddRequest_RequestsDoesNotContainValue()
        {
            //var elevator = new Elevator(1);
            //elevator.AddRequest(-1);

            //Assert.IsTrue(elevator.);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorEqualToZero()
        {
            //var elevator = new Elevator(1);

            //var response = elevatorHelper.IsSelectedFloorOutOfRange(0);

            //Assert.IsFalse(response);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorMoreThanZero_LessThanTopFloor()
        {
            //var elevator = new Elevator(1);

            //var response = elevatorHelper.IsSelectedFloorOutOfRange(1);

            //Assert.IsFalse(response);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorMoreThanTopFloor()
        {
            //var elevator = new Elevator(1);

            //var response = elevatorHelper.IsSelectedFloorOutOfRange(11);

            //Assert.IsTrue(response);
        }
        
        [TestMethod]
        public void MoveElevator_FloorGreaterThanTopFloor()
        {
            //var elevator = new Elevator(1);

            //var response = elevatorHelper.MoveElevator(11, new List<Passenger>());

            //Assert.IsNotNull(response);
            //Assert.AreEqual(0, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_NumberOfPassengersGreaterThanMax()
        {
            //var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            //passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 5)).Returns(false);

            //var elevator = new Elevator(1);

            //var response = elevatorHelper.MoveElevator(1, new List<Passenger>());

            //Assert.IsNotNull(response);
            //Assert.AreEqual(0, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_FloorLessThanZero()
        {
            //var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            //passengerHelperMoq.SetReturnsDefault(true);
            //passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 15));

            //var elevator = new Elevator(1);

            //var response = elevatorHelper.MoveElevator(-1, new List<Passenger>());

            //Assert.IsNotNull(response);
            //Assert.AreEqual(-1, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_MoreThanOneButtonPress()
        {
            //var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            //passengerHelperMoq.SetReturnsDefault(true);
            //passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 15));

            //var buttonPressed = new List<int> { 1, 2 };

            //var elevator = new Elevator(1);

            //var response = elevatorHelper.MoveElevator(1, new List<Passenger>());

            //Assert.IsNotNull(response);
            //Assert.AreEqual(2, response.CurrentFloor);
        }
    }
}