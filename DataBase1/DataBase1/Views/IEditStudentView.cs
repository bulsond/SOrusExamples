using DataBase1.Models;
using DataBase1.Views.EventHandlers;
using System.ComponentModel;

namespace DataBase1.Views
{
    public interface IEditStudentView
    {
        //текущий редактируемый студент
        StudentModel CurrentStudent { get; set; }

        //список студенческих групп
        BindingList<GroupModel> Groups { get; set; }

        //выбранная группа
        GroupModel SelectedGroup { get; }

        //позиция выбранной группы
        int SelectedGroupPosition { get; set; }

        //кнопка ОК
        ButtonEventHandler OkStudent { set; }
    }
}
