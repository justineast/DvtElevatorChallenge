using DvtElevatorChallenge.Data;

namespace DvtElevatorChallenge.Utility
{
    //Class written to manage the passengers selection odf choice
    public class Passenger
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public int DestinationFloor { get; private set; }

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
