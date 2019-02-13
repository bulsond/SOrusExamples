using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase1.Models;
using DataBase1.Views.EventHandlers;

namespace DataBase1.Views
{
    public partial class EditStudentView : Form, IEditStudentView
    {
        private BindingSource _bsStudent = new BindingSource();
        private BindingSource _bsGroups = new BindingSource();
        private BindingSource _bsOk = new BindingSource();

        public EditStudentView()
        {
            InitializeComponent();

            SetBindings();
        }

        private void SetBindings()
        {
            //Студент текстбоксы
            _bsStudent.DataSource = typeof(StudentModel);
            _textBoxFirstName.DataBindings.Add("Text", _bsStudent, nameof(StudentModel.FirstName));
            _textBoxLastName.DataBindings.Add("Text", _bsStudent, nameof(StudentModel.LastName));

            //Группы комбобокс
            _bsGroups.DataSource = typeof(BindingList<GroupModel>);
            _comboBoxGroups.DisplayMember = nameof(GroupModel.Number);
            _comboBoxGroups.DataSource = _bsGroups;

            //Кнопка ОК
            _bsOk.DataSource = typeof(ButtonEventHandler);
        }

        /// <summary>
        /// Студент с привязанными именем и фамилией
        /// </summary>
        public StudentModel CurrentStudent
        {
            get => _bsStudent.Current as StudentModel;
            set
            {
                _bsStudent.Clear();
                _bsStudent.Add(value);
            }
        }


        /// <summary>
        /// ComboBox
        /// </summary>
        public BindingList<GroupModel> Groups
        {
            get => _bsGroups.List as BindingList<GroupModel>;
            set => _bsGroups.DataSource = value;
        }
        public GroupModel SelectedGroup => _bsGroups.Current as GroupModel;
        public int SelectedGroupPosition
        {
            get => _bsGroups.Position;
            set => _bsGroups.Position = value;
        }


        /// <summary>
        /// Кнопка ОК
        /// </summary>
        public ButtonEventHandler OkStudent
        {
            set
            {
                _bsOk.Clear();
                _bsOk.Add(value);
                _buttonOK.Click += value.Handler;
            }
        }
    }
}
