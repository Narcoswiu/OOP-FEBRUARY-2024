using _01.Vehicles.Core;
using _01.Vehicles.Core.Interaces;
using _01.Vehicles.Factories;
using _01.Vehicles.Factories.Interfaces;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory factory = new VehicleFactory();

            IEngine engine = new Engine(reader,writer,factory);

            engine.Run();
        }
    }
}