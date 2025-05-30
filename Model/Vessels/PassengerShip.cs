﻿using System.Windows;

namespace Sea_Transportation_Management_System.Model.Vessels
{
    class PassengerShip : Vessel
    {
        private int _passengers;
        public int Passengers
        {
            get { return _passengers; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Amount of passengers cannot be negative!");
                    return;
                }
                _passengers = value;
            }
        }
        public PassengerShip(int id, string? name, float fuelCapacity) : base(id, name, fuelCapacity)
        {

        }

        public override double CalculateFuelConsumption(double distance)
        {
            if (_passengers == default)
            {
                MessageBox.Show("Input amount of passengers!");
                return 0;
            }
            return distance;
        }
    }
}
