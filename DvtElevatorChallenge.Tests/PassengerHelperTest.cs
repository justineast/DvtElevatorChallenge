namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class PassengerHelperTest
    {
        [TestMethod]
        public void ValidateNumberOfPassengers_PassengersLessThanMax()
        {
            //var passengerHelper = new PassengerHelper();
            
            //var response = passengerHelper.ValidateNumberOfPassengers(1, 2);

            //Assert.IsTrue(response);
        }

        [TestMethod]
        public void ValidateNumberOfPassengers_PassengersMoreThanMax()
        {
            //var passengerHelper = new PassengerHelper();

            //var response = passengerHelper.ValidateNumberOfPassengers(3, 2);

            //Assert.IsFalse(response);
        }

        [TestMethod]
        public void ValidateNumberOfPassengers_PassengersEqualsMax()
        {
            //var passengerHelper = new PassengerHelper();

            //var response = passengerHelper.ValidateNumberOfPassengers(2, 2);

            //Assert.IsFalse(response);
        }

        [TestMethod]
        public void AddPassengers_FloorEqualForElevatorAndPassenger()
        {
            //var passengerHelper = new PassengerHelper();

            //var response = passengerHelper.AddPassengers(new Elevator(10), new List<Data.Passenger>());

            //Assert.IsNotNull(response);
            //Assert.AreEqual(0, response.Count);
        }

        [TestMethod]
        public void AddPassengers_PassengerAdded()
        {
            //var passengerHelper = new PassengerHelper();

            //var passengers = new List<Data.Passenger>
            //{
            //    new()
            //    {
            //        CurrentFloor = 0,
            //        PassengerType = Enums.PassengerType.Person
            //    }
            //};

            //var response = passengerHelper.AddPassengers(new Elevator(10), passengers);

            //Assert.IsNotNull(response);
            //Assert.AreEqual(1, response.Count);
            //Assert.AreEqual(Enums.PassengerType.Person, response.First().PassengerType);
        }

        [TestMethod]
        public void RemovePassengers_FloorEqualForElevatorAndPassenger()
        {
            //var passengerHelper = new PassengerHelper();
            
            //var response = passengerHelper.RemovePassengers(new Elevator(10));

            //Assert.IsNotNull(response);
            //Assert.AreEqual(0, response.Count);
        }

        [TestMethod]
        public void RemovePassengers_PassengerRemoved()
        {
            //var passengerHelper = new PassengerHelper();

            //var passengers = new List<Data.Passenger>
            //{
            //    new()
            //    {
            //        CurrentFloor = 0,
            //        PassengerType = Enums.PassengerType.Person
            //    }
            //};

            //var elevator = new Elevator(10);
            //var response = passengerHelper.RemovePassengers(elevator);

            //Assert.IsNotNull(response);
            //Assert.AreEqual(0, response.Count);
        }
    }
}