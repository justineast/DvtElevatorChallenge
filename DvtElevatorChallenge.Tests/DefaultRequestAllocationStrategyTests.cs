using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Tests
{
    [TestClass]
    public class DefaultRequestAllocationStrategyTests
    {
        [TestMethod]
        public void FindBestElevator_ZeroElevators()
        {
            var defaultRequestAllocationStrategy = new DefaultRequestAllocationStrategy();
            
            var response = defaultRequestAllocationStrategy.FindBestElevator(new List<IElevator>(), 1, Enums.Direction.Up);

            Assert.IsNull(response);
        }

        [TestMethod]
        public void FindBestElevator_ElevatorsAdded()
        {
            var defaultRequestAllocationStrategy = new DefaultRequestAllocationStrategy();
            var elevators = new List<IElevator>
            {
                new Elevator(1)
            };

            var response = defaultRequestAllocationStrategy.FindBestElevator(elevators, 1, Enums.Direction.Up);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Id);
            Assert.AreEqual(Enums.Direction.Up, response.Direction);
        }
    }
}