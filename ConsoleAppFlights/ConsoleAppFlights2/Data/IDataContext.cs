using ConsoleAppFlights2.Models;
using System.Collections.Generic;

namespace ConsoleAppFlights2.Data
{
    interface IDataContext
    {
        Flight GetFlight();
        List<Flight> GetFlightsByDestination(string destination);
        List<string> GetListDestinations();
        bool IsFlightCorrect();
        void SaveFlight();
        void SetDestinationFlight(string dest);
        void SetNumberFlight(string number);
        void SetSeatsFlight(int seats);
        void SetTypeFlight(string type);
    }
}
