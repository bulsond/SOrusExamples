using DataBase1.Models;
using DataBase1.Views;
using DataBase1.Views.EventHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase1.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;

        //ctor
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));

            GetData();
            SetEventHandlers();
        }

        /// <summary>
        /// Загрузка данных для отображения
        /// </summary>
        private void GetData()
        {
            //группы
            var dbGroups = Program.Repository.GetAllGroups()
                                             .OrderBy(g => g.Number)
                                             .ToList();

            _mainView.Groups = new BindingList<GroupModel>();
            _mainView.Groups.Add(new GroupModel { Number = "Все группы" });
            foreach (var group in dbGroups)
            {
                _mainView.Groups.Add(group);
            }

            GetStartDataForStudents();
        }

        /// <summary>
        /// Загрузка первоначального полного списка студентов
        /// </summary>
        private void GetStartDataForStudents()
        {
            //студенты
            _mainView.Students = new BindingList<StudentModel>();
            var dbStudents = Program.Repository.GetAllStudents();
            SetNumbersAndShowStudents(dbStudents);
        }

        /// <summary>
        /// Назначение обработчиков событий
        /// </summary>
        private void SetEventHandlers()
        {
            _mainView.SelectedGroupChanged = new SimpleEventHandler(OnSelectGroup);
            _mainView.AddStudent = new ButtonEventHandler(OnAddStudent);
            _mainView.EditStudent = new ButtonEventHandler(OnEditStudent);
        }


        /// <summary>
        /// Обработка изменения выбранной группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectGroup()
        {
            List<StudentModel> dbStudents;
            if (_mainView.SelectedGroup.Number.Equals("Все группы"))
            {
                //студенты
                dbStudents = Program.Repository.GetAllStudents();
            }
            else
            {
                //студенты нужной группы
                dbStudents = Program.Repository.GetStudentsByGroup(_mainView.SelectedGroup.Number);
            }

            //пронумеруем студентов и отобразим их
            SetNumbersAndShowStudents(dbStudents);
        }

        /// <summary>
        /// Присвоение порядковых номеров студентам отображемым в списке
        /// </summary>
        /// <param name="dbStudents"></param>
        private void SetNumbersAndShowStudents(List<StudentModel> dbStudents)
        {
            //очищаем отображаемый список студентов
            _mainView.Students.Clear();
            //нумеруем и отображаем
            for (int i = 0; i < dbStudents.Count(); i++)
            {
                dbStudents[i].Number = i + 1;
                _mainView.Students.Add(dbStudents[i]);
            }

            //отобразим название группы и количество студентов в ней
            _mainView.StatusCountStudents = $@"Всего студентов в группе ""{_mainView.SelectedGroup.Number}"": {_mainView.Students.Count} студентов";
        }

        /// <summary>
        /// Добавление нового студента
        /// </summary>
        private void OnAddStudent()
        {
            //отображаем окно, которое должно вернуть экземпляр студента
            //если была нажата кнопка ОК иначе пусто
            StudentModel student = Program.Controller.GetNewStudent();
            if (student == null) return;

            //запоминаем в БД
            int result = Program.Repository.AddStudent(student);
            if (result == 0) return; //TODO: тут надо бы выводить сообщение для юзера

            GetStartDataForStudents();
        }

        /// <summary>
        /// Редактирование студента
        /// </summary>
        private void OnEditStudent()
        {
            //выбираем выделенного студента
            var student = _mainView.SelectedStudent;
            //отдаем на редактирование
            var editedStudent = Program.Controller.GetEditedStudent(student);
            if (editedStudent == null) return; //если редактировать отказались

            //запоминаем в БД
            int result = Program.Repository.UpdateStudent(editedStudent);
            if (result == 0) return;

            GetStartDataForStudents();
        }
    }
}
