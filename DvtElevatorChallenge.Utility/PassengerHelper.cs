using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorChallenge.Data;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Utility
{
    public class PassengerHelper : IPassengerHelper
    {
        public bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers)
        {
            return numberOfPassengers < maximumPassengers;
        }

        public List<Passenger> AddPassengers(Elevator elevator, List<Passenger> passengersToAdd)
        {
            var passengers = new List<Passenger>(passengersToAdd);

            foreach (var passenger in passengers.Where(passenger => elevator.CurrentFloor == passenger.CurrentFloor && elevator.Passengers.Count < elevator.MaximumPassengers))
            {
                elevator.Passengers.Add(passenger);
            }

            return elevator.Passengers;
        }

        public List<Passenger> RemovePassengers(Elevator elevator)
        {
            var passengers = new List<Passenger>(elevator.Passengers);

            foreach (var passenger in passengers.Where(passenger => elevator.CurrentFloor == passenger.SelectedFloor))
            {
                elevator.Passengers.Remove(passenger);
            }

            return elevator.Passengers;
        }
    }
}
