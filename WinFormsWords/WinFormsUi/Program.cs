using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsUi.Presenters;
using WinFormsUi.Services;
using WinFormsUi.Views;

namespace WinFormsUi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new MainForm();
            var tService = new TokenService();
            var wService = new WordService();
            var presenter = new MainPresenter(form, tService, wService);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Пример";
            Application.Run(form);
        }
    }
}
