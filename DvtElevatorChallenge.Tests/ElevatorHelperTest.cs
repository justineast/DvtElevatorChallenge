using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class ElevatorHelperTest
    {
        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorLessThanZero()
        {
            var elevatorHelper = new ElevatorHelper();
            
            var response = elevatorHelper.IsSelectedFloorOutOfRange(-1);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorEqualToZero()
        {
            var elevatorHelper = new ElevatorHelper();

            var response = elevatorHelper.IsSelectedFloorOutOfRange(0);

            Assert.IsFalse(response);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorMoreThanZero_LessThanTopFloor()
        {
            var elevatorHelper = new ElevatorHelper();

            var response = elevatorHelper.IsSelectedFloorOutOfRange(1);

            Assert.IsFalse(response);
        }

        [TestMethod]
        public void IsSelectedFloorOutOfRangeTest_FloorMoreThanTopFloor()
        {
            var elevatorHelper = new ElevatorHelper(topFloor: 10);

            var response = elevatorHelper.IsSelectedFloorOutOfRange(11);

            Assert.IsTrue(response);
        }
        
        [TestMethod]
        public void MoveElevator_FloorGreaterThanTopFloor()
        {
            var elevatorHelper = new ElevatorHelper(topFloor: 10);

            var response = elevatorHelper.MoveElevator(11, new List<Passenger>());

            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_NumberOfPassengersGreaterThanMax()
        {
            var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 5)).Returns(false);

            var elevatorHelper = new ElevatorHelper(topFloor: 10, passengerHelper: passengerHelperMoq.Object);

            var response = elevatorHelper.MoveElevator(1, new List<Passenger>());

            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_FloorLessThanZero()
        {
            var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            passengerHelperMoq.SetReturnsDefault(true);
            passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 15));

            var elevatorHelper = new ElevatorHelper(topFloor: 10, passengerHelper: passengerHelperMoq.Object);

            var response = elevatorHelper.MoveElevator(-1, new List<Passenger>());

            Assert.IsNotNull(response);
            Assert.AreEqual(-1, response.CurrentFloor);
        }

        [TestMethod]
        public void MoveElevator_MoreThanOneButtonPress()
        {
            var passengerHelperMoq = new Moq.Mock<IPassengerHelper>();
            passengerHelperMoq.SetReturnsDefault(true);
            passengerHelperMoq.Setup(pm => pm.ValidateNumberOfPassengers(10, 15));

            var buttonPressed = new List<int> { 1, 2 };

            var elevatorHelper = new ElevatorHelper(topFloor: 10, passengerHelper: passengerHelperMoq.Object, buttonsPressed: buttonPressed);

            var response = elevatorHelper.MoveElevator(1, new List<Passenger>());

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.CurrentFloor);
        }
    }
}