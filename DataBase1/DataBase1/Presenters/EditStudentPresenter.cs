using DataBase1.Models;
using DataBase1.Views;
using DataBase1.Views.EventHandlers;
using System;
using System.ComponentModel;
using System.Linq;

namespace DataBase1.Presenters
{
    public class EditStudentPresenter
    {
        private readonly IEditStudentView _editStudentView;
        private readonly StudentModel _student;

        //ctor
        public EditStudentPresenter(IEditStudentView newStudentView, StudentModel student)
        {
            _editStudentView = newStudentView ?? throw new ArgumentNullException(nameof(newStudentView));
            _student = student ?? throw new ArgumentNullException(nameof(student));

            //студент
            _editStudentView.CurrentStudent = _student;

            //группы
            var dbGroups = Program.Repository.GetAllGroups().OrderBy(g => g.Number);
            _editStudentView.Groups = new BindingList<GroupModel>();
            foreach (var group in dbGroups)
            {
                _editStudentView.Groups.Add(group);
            }

            //Кнопка ОК
            _editStudentView.OkStudent = new ButtonEventHandler(OnOkStudent);

            //если мы редактируем студента, а не создаем нового
            if (!String.IsNullOrEmpty(_student.GroupNumber))
            {
                //находим нужную группу
                var group = _editStudentView.Groups.First(g => g.Number.Equals(_student.GroupNumber));
                var index = _editStudentView.Groups.IndexOf(group);

                //выделяем ее
                _editStudentView.SelectedGroupPosition = index;
            }
        }

        //Кнопка ОК нажатие
        private void OnOkStudent()
        {
            _student.Group = _editStudentView.SelectedGroup;
            _student.GroupNumber = _editStudentView.SelectedGroup.Number;
        }
    }
}
