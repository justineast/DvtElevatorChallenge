using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Bll;

namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class ElevatorManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequestElevator_PassengerEqualNull()
        {
            var elevatorManager = new ElevatorManager(1, new DefaultRequestAllocationStrategy());
            elevatorManager.RequestElevator(null);
        }
    }
}