namespace DvtElevatorChallenge.Data
{
    public class Enums
    {
        public enum State
        {
            Moving,
            Idle,
            Stopped
        }
        public enum Direction
        {
            Up,
            Down
        }

        public enum ElevatorType
        {
            Passenger,
            Freight,
            HighSpeed,
            Glass,
            Service
        }

        public enum PassengerType
        {
            Person,
            Package
        }
    }
}
