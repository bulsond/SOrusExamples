using StudentsUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsUI.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        //ctor
        public MainPresenter(IMainView view, IAppController controller)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public IMainView View { get; private set; }
        public IAppController Controller { get; private set; }
    }
}
