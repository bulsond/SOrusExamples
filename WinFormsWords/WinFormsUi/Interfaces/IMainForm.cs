using System;
using System.Collections.Generic;

namespace WinFormsUi.Interfaces
{
    public interface IMainForm
    {
        string InputOutputText { get; set; }
        List<ITFIDFWord> Words { get; set; }

        event EventHandler InputOutputTextChanged;
        event EventHandler ShowWordsClicked;

    }
}
