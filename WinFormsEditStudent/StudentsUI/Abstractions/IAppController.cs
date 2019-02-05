using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsUI.Abstractions
{
    public interface IAppController
    {
        IMainView GetMainView();
        void ShowError(string message);
        void ShowInfo(string message);
    }
}
