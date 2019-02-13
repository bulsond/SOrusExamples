using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Data
{
    public class DataContext : IDataContext
    {
        public List<Modem> GetModems()
        {
            return new List<Modem>
            {
                new Modem("COM1"),
                new Modem("COM2"),
                new Modem("COM4")
            };
        }

        public List<PhoneNumber> GetPhoneNumbers()
        {
            return new List<PhoneNumber>
            {
                new PhoneNumber("1234567"),
                new PhoneNumber("7654321"),
                new PhoneNumber("4567890"),
                new PhoneNumber("9987654"),
                new PhoneNumber("9872341"),
                new PhoneNumber("7659012"),
                new PhoneNumber("6772344"),
                new PhoneNumber("2239873"),
            };
        }
    }
}
