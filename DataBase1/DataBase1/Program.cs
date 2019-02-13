using DataBase1.Data;
using DataBase1.Presenters;
using DataBase1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase1
{
    static class Program
    {
        public static IRepository Repository { get; private set; } = new TestRepository();
        public static AppContorller Controller { get; private set; } = new AppContorller();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = Controller.GetMainView() as Form;

            Application.Run(view);
        }
    }
}
