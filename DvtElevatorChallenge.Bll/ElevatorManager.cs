using DvtElevatorChallenge.Utility;
using DvtElevatorChallenge.Bll.Interfaces;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Bll
{
    public class ElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> _elevators;
        private readonly Dictionary<int, List<Passenger>> _passengerRequests;
        private readonly IRequestAllocationStrategy _allocationStrategy;

        /// <summary>
        /// Constructor used to create an instance of the ElevatorManager
        /// </summary>
        /// <param name="numberOfElevators">The Number of elevators</param>
        /// <param name="allocationStrategy">An instance of the AllocationStrategy class</param>
        public ElevatorManager(int numberOfElevators, IRequestAllocationStrategy allocationStrategy)
        {
            if (numberOfElevators <= 0)
            {
                throw new ArgumentException("Number of elevators must be positive.");
            }

            _elevators = new List<IElevator>();
            _passengerRequests = new Dictionary<int, List<Passenger>>();
            _allocationStrategy = allocationStrategy;

            //Based on the number of elevators passed in, the Elevator manager will create instances for each elevator 
            for (var i = 0; i < numberOfElevators; i++)
            {
                _elevators.Add(new Elevator(i));
            }
        }

        /// <summary>
        /// Method used to add a request to call the closest elevator to pick up the customer
        /// </summary>
        /// <param name="passenger">The passenger</param>
        public void RequestElevator(Passenger passenger)
        {
            ArgumentNullException.ThrowIfNull(passenger);

            if (!_passengerRequests.TryGetValue(passenger.CurrentFloor, out var value))
            {
                value = new List<Passenger>();
                _passengerRequests[passenger.CurrentFloor] = value;
            }

            value.Add(passenger);
            AllocateRequests();
        }
        
        /// <summary>
        /// Method used to allocate the best elevator to pick up the passenger
        /// Logic is applied to find the best elevator for the desired floor request
        /// </summary>
        private void AllocateRequests()
        {
            foreach (var passengerRequest in _passengerRequests.ToList())
            {

                var passengers = passengerRequest.Value.ToList();
                foreach (var passenger in passengers)
                {
                    try
                    {
                        var bestElevator = _allocationStrategy.FindBestElevator(_elevators, passenger.CurrentFloor, passenger.Direction);
                        if (bestElevator == null)
                            continue;

                        bestElevator.AddRequest(passenger.CurrentFloor);
                        bestElevator.AddPassenger(passenger);
                        _passengerRequests[passenger.CurrentFloor].Remove(passenger);
                        if (_passengerRequests[passenger.CurrentFloor].Count == 0)
                        {
                            _passengerRequests.Remove(passenger.CurrentFloor);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error allocating request for passenger {passenger.Id}: {ex.Message}");
                    }
                }
            }
        }
        
        /// <summary>
        /// Method used to move the elevators and Allocate the requests to the elevator
        /// </summary>
        public void MoveElevators()
        {
            foreach (var elevator in _elevators)
            {
                try
                {
                    elevator.Move();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error moving elevator {elevator.Id}: {ex.Message}");
                }
            }

            AllocateRequests();
        }

        public void PerformMaintenance(int elevatorId)
        {
            try
            {
                var elevator = _elevators.FirstOrDefault(e => e.Id == elevatorId);
                elevator?.PerformMaintenance();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing maintenance on elevator {elevatorId}: {ex.Message}");
            }
        }

        public void CompleteMaintenance(int elevatorId)
        {
            try
            {
                var elevator = _elevators.FirstOrDefault(e => e.Id == elevatorId);
                elevator?.CompleteMaintenance();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error completing maintenance on elevator {elevatorId}: {ex.Message}");
            }
        }

        public void PrintStatus()
        {
            foreach (var elevator in _elevators)
            {
                Console.WriteLine(elevator);
            }
        }
    }
}