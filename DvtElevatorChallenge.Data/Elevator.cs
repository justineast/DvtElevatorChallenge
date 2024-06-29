using static DvtElevatorChallenge.Data.Enums;

namespace DvtElevatorChallenge.Data
{
    public class Elevator
    {
        public Elevator(int maximumPassengers, int topFloor, List<Passenger> passengers, ElevatorType elevatorType = ElevatorType.Passenger)
        {
            MaximumPassengers = maximumPassengers;
            MaximumPassengerWeight = MaximumPassengers * 100;
            TopFloor = topFloor;
            CurrentFloor = 0;
            NextFloor = 0;
            Id = Guid.NewGuid();
            ElevatorType = elevatorType;
            Passengers = CheckIfPassengersAreOnTheGroundFloor(passengers);
        }

        public Guid Id { get; set; }
        public int CurrentFloor { get; set; }
        public int NextFloor { get; set; }
        public int DestinationFloor { get; set; }
        public int TopFloor { get; set; }
        public Enums.Status Status { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Enums.ElevatorType ElevatorType { get; set; }
        public int MaximumPassengers { get; private set; }
        public int MaximumPassengerWeight { get; private set; }

        private List<Passenger> CheckIfPassengersAreOnTheGroundFloor(List<Passenger> passengers)
        {
            return passengers.FindAll(p => p.CurrentFloor == CurrentFloor);
        }
    }
}