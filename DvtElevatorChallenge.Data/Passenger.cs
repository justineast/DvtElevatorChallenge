﻿namespace DvtElevatorChallenge.Data
{
    public class Passenger
    {
        public int Id { get; set; }
        public Enums.PassengerType PassengerType { get; set; }
        public int CurrentFloor { get; set; }
        public int SelectedFloor { get; set; }
    }
}
