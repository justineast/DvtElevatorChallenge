using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorChallenge.Utility.Interfaces;

namespace DvtElevatorChallenge.Utility
{
    public class PassengerHelper : IPassengerHelper
    {
        public bool ValidateNumberOfPassengers(int numberOfPassengers, int maximumPassengers)
        {
            return numberOfPassengers > maximumPassengers;
        }

        //private string CalculateNumberOfPassengers()
        //{
            //TODO: Calculate whether the weight and number of people in the lift has changed
        //}
    }
}
