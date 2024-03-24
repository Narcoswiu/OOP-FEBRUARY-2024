using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type,double fuelQuantity,double fuelConsumption);
    }
}
