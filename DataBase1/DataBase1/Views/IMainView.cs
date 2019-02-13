using DataBase1.Models;
using DataBase1.Views.EventHandlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase1.Views
{
    public interface IMainView
    {
        //список студенческих групп
        BindingList<GroupModel> Groups { get; set; }

        //выбранная группа
        GroupModel SelectedGroup { get; }

        //была выбрана др.группа
        SimpleEventHandler SelectedGroupChanged { set; }

        //список студентов
        BindingList<StudentModel> Students { get; set; }

        //выбранный студент
        StudentModel SelectedStudent { get; }

        //кнопка Новый студент
        ButtonEventHandler AddStudent { set; }

        //кнопка Редактировать студента
        ButtonEventHandler EditStudent { set; }

        //вывод информации о количестве студентов в группе
        string StatusCountStudents { get; set; }
    }
}
