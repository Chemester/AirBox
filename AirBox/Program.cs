using System;

namespace AirBox
{
    class Program
    {
        private static string _path = @"C:\Users\Anton\RiderProjects\DataBaseTest\AirBox\TestData\TestData5.txt";
        
        static void Main(string[] args)
        {
            var fileReader = new ReadFile();
            var checkCargo = new CheckCargo();

            var cargo = fileReader.GetCargo(_path);
            var flight = fileReader.GetFlights(_path);

            var check = checkCargo.Check(cargo, flight);
            Console.WriteLine(check);
        }
    }
}