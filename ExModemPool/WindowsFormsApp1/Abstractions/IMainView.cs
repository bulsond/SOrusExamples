using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Presenters.EventHandlers;

namespace WindowsFormsApp1.Abstractions
{
    public interface IMainView
    {
        List<Modem> Modems { get; set; }
        List<PhoneNumber> PhoneNumbers { get; set; }
        ButtonEventHandler StartCalling { get; set; }
        ButtonEventHandler CancelCalling { get; set; }

        void AddLogRecord(string logMessage);
        void ChangeNumberOutput(PhoneNumber number, PhoneNumberStateChangedEventArgs e);
    }
}
