namespace DvtElevatorChallenge.Data
{
    public class Enums
    {
        public enum Status
        {
            MovingUp,
            MovingDown,
            Stopped
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
