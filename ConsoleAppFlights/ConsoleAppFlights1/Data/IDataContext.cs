using System.Collections.Generic;
using ConsoleAppFlights1.Models;

namespace ConsoleAppFlights1.Data
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