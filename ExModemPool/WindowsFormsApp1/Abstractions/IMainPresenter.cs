using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Abstractions
{
    public interface IMainPresenter
    {
        IAppController Controller { get; }
        IMainView View { get; }
    }
}
