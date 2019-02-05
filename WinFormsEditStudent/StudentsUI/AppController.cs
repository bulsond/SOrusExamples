using StudentsUI.Abstractions;
using StudentsUI.Presenters;
using StudentsUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsUI
{
    class AppController : IAppController
    {
        private IMainView _mainView;

        public IMainView GetMainView()
        {
            if (_mainView != null) return _mainView;

            _mainView = new MainView();
            (_mainView as Form).StartPosition = FormStartPosition.CenterScreen;
            (_mainView as Form).Text = "Пример работы с привязками";

            var presenter = new MainPresenter(_mainView, this);

            return _mainView;
        }

        public void ShowError(string message)
        {
            if (String.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            MessageBox.Show(null, message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string message)
        {
            if (String.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            MessageBox.Show(null, message, "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
