using System.Collections.Generic;

namespace NumberNotationsUI.Models
{
    public interface INotationService
    {
        List<string> GetNotationsNames();
        string GetNotationValue(string inputNotation, string inputValue, string outputNotation);
    }
}
