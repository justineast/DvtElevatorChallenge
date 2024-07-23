using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Utility
{
    //Class written to manage the passenger movement, both into and out of the Elevator
    public class PassengerHelper : IPassengerHelper
    {
        //Method written to validate the number of passengers
        public bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers)
        {
            return numberOfPassengers < maximumPassengers;
        }

        //Method written to manage the passenger movement into the Elevator
        public List<Passenger> AddPassengers(Elevator elevator, List<Passenger> passengersToAdd)
        {
            //var passengers = new List<Passenger>(passengersToAdd);

            //foreach (var passenger in passengers.Where(passenger => elevator.CurrentFloor == passenger.CurrentFloor && elevator.Passengers.Count < elevator.MaximumPassengers))
            //{
            //    elevator.Passengers.Add(passenger);
            //}

            return null;
        }

        //Method written to manage the passenger movement out of the Elevator
        public List<Passenger> RemovePassengers(Elevator elevator)
        {
            //var passengers = new List<Passenger>(elevator.Passengers);

            //foreach (var passenger in passengers.Where(passenger => elevator.CurrentFloor == passenger.SelectedFloor))
            //{
            //    //elevator.Passengers.Remove(passenger);
            //}

            //return elevator.Passengers;
            return null;
        }
    }
}
