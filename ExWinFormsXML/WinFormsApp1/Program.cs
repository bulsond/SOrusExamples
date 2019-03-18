using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Abstractions;
using WinFormsApp1.Data;
using WinFormsApp1.Views;

namespace WinFormsApp1
{
    static class Program
    {
        public static IPersonRepository PersonRepository { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //PersonRepository = new PersonTestRepository(); //данные в памяти программы

            //репозиторий реальный пишем/читаем XML файл
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.xml");
            PersonRepository = new PersonXmlRepository(path);

            Application.Run(new MainView());
        }
    }
}
