using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsUI.Abstractions
{
    public interface IMainPresenter
    {
        IMainView View { get; }
        IAppController Controller { get; }
    }
}
