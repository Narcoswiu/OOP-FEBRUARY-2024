using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increaseConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double increaseConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increaseConsumption = increaseConsumption;
        }
        public double FuelQuantity
        {
            get; private set;
        }

        public double FuelConsumption
        {
            get; private set;
        }

        public string Drive(double distance)
        {
            double totalConsumption = FuelConsumption + increaseConsumption;

            if (FuelQuantity < distance * totalConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount) => FuelQuantity += amount;


        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
