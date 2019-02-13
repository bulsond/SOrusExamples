using DataBase1.Models;
using DataBase1.Presenters;
using DataBase1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase1
{
    public class AppContorller
    {
        private MainView _mainView;

        /// <summary>
        /// Первоначальный старт программы
        /// </summary>
        /// <returns></returns>
        public IMainView GetMainView()
        {
            _mainView = new MainView();
            var presenter = new MainPresenter(_mainView);

            return _mainView;
        }

        /// <summary>
        /// Получение экземпляра нового студента
        /// </summary>
        /// <returns>null в случае если юзер отказался заполнять форму</returns>
        public StudentModel  GetNewStudent()
        {
            //создаем новый экземпляр студента
            var student = new StudentModel { FirstName = "<?>", LastName = "<?>" };

            var view = new EditStudentView();
            var presenter = new EditStudentPresenter(view, student);

            view.Text = "Новый студент";
            view.Owner = _mainView;
            var dResult = view.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                return student;
            }

            return null;
        }

        /// <summary>
        /// Редактирование данных по студенту
        /// </summary>
        /// <param name="student"></param>
        public StudentModel GetEditedStudent(StudentModel student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));

            var view = new EditStudentView();
            var presenter = new EditStudentPresenter(view, student);

            view.Text = "Редактирование данных по студенту";
            view.Owner = _mainView;
            var dResult = view.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                return student;
            }

            return null;
        }
    }
}
