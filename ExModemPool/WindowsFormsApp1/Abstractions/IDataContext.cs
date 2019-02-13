using System.Collections.Generic;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Abstractions
{
    public interface IDataContext
    {
        List<Modem> GetModems();
        List<PhoneNumber> GetPhoneNumbers();
    }
}
