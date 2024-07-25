using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility
{
    public class Passenger
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public int DestinationFloor { get; private set; }

        /// <summary>
        /// Constructor used to create an instance of the Passenger along with the requested floor they would like to go to
        /// </summary>
        /// <param name="id">Passenger Id</param>
        /// <param name="currentFloor">Current Floor the passenger is on</param>
        /// <param name="destinationFloor">Floor the passenger would like to go to</param>
        public Passenger(int id, int currentFloor, int destinationFloor)
        {
            if (currentFloor < 0 || destinationFloor < 0)
            {
                throw new ArgumentException("Floor numbers must be non-negative.");
            }

            if (currentFloor == destinationFloor)
            {
                throw new ArgumentException("Current floor and destination floor must be different.");
            }

            Id = id;
            CurrentFloor = currentFloor;
            DestinationFloor = destinationFloor;
        }

        public Enums.Direction Direction => DestinationFloor > CurrentFloor ? Enums.Direction.Up : Enums.Direction.Down;
    }
}
