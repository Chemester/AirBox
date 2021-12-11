using System.Collections.Generic;
using System.Linq;
using AirBox.Model;

namespace AirBox
{
    public class CheckCargo
    {
        public bool Check(Cargo cargo, List<Flight> flights)
        {
            if (cargo.Start == cargo.Finish)
                return true;
            
            var selectedFlights = flights.Where(x => x.Start == cargo.Start).ToList();
            foreach (var flight in selectedFlights)
            {
                var lostWeight = 0;
                var currentCargo = cargo;
                currentCargo.Start = flight.Finish;
                if (currentCargo.Weight > flight.Weight)
                {
                    lostWeight = currentCargo.Weight - flight.Weight;
                    currentCargo.Weight = flight.Weight;
                }

                var check = Check(currentCargo, flights.Where(x => x.Date > flight.Date).ToList());

                if (lostWeight <= 0 && check)
                {
                    return true;
                }

                if (check)
                {
                    var lostFlights = new List<Flight>(flights);
                    lostFlights.Remove(flight);
                    
                    var currentCargoV2 = cargo;
                    currentCargoV2.Weight = lostWeight;
                    
                    var checkV2 = Check(currentCargoV2, lostFlights);
                    if (checkV2)
                        return true;
                }
            }

            return false;
        }
    }
}