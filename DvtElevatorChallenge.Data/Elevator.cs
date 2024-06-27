namespace DvtElevatorChallenge.Data
{
    public class Elevator
    {
        public Elevator(int maximumPassengers, int topFloor, List<Passenger> passengers)
        {
            MaximumPassengers = maximumPassengers;
            MaximumPassengerWeight = MaximumPassengers * 100;
            Passengers = passengers ?? new List<Passenger>();
            TopFloor = topFloor;
        }

        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public int NextFloor { get; set; }
        public int PreviousFloor { get; set; }
        public int TopFloor { get; set; }
        public Enums.Status Status { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Enums.ElevatorType ElevatorType { get; set; }
        public int MaximumPassengers { get; private set; }
        public int MaximumPassengerWeight { get; private set; }
    }
}