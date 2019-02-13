using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainView : Form, IMainView
    {
        private BindingSource _bsGroups = new BindingSource();
        private BindingSource _bsStudents = new BindingSource();
        private BindingSource _bsAddStudent = new BindingSource();
        private BindingSource _bsEditStudent = new BindingSource();

        public MainView()
        {
            InitializeComponent();

            SetBindings();

            this.Activated += MainView_Activated;
            this.Text = "Студенты и группы";
        }

        private void MainView_Activated(object sender, EventArgs e)
        {
            //при активации окна возвращаем в комбобоксе выбор всех групп
            _bsGroups.Position = 0;
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            //ComboBox
            _bsGroups.DataSource = typeof(BindingList<GroupModel>);
            _comboBoxGroups.DisplayMember = nameof(GroupModel.Number);
            _comboBoxGroups.DataSource = _bsGroups;

            //DataGridView
            _bsStudents.DataSource = typeof(BindingList<StudentModel>);
            _dataGridViewStudents.AutoGenerateColumns = false;
            _dataGridViewStudents.DataSource = _bsStudents;

            //Button Новый студент
            _bsAddStudent.DataSource = typeof(ButtonEventHandler);
            _buttonAddStudent.DataBindings.Add(nameof(_buttonAddStudent.Enabled),
                _bsAddStudent, nameof(ButtonEventHandler.Enabled));
            //_buttonAddStudent.DataBindings.Add(nameof(_buttonAddStudent.Text),
            //    _bsAddStudent, nameof(ButtonEventHandler.Text)); //для смены надписи на кнопке

            //Button Редактировать студента
            _bsEditStudent.DataSource = typeof(ButtonEventHandler);
            _buttonEditStudent.DataBindings.Add("Enabled", _bsEditStudent, "Enabled");
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
        public SimpleEventHandler SelectedGroupChanged
        {
            set
            {
                _bsGroups.CurrentChanged += value.Handler;
            }
        }

        /// <summary>
        /// DataGridView
        /// </summary>
        public BindingList<StudentModel> Students
        {
            get => _bsStudents.List as BindingList<StudentModel>;
            set => _bsStudents.DataSource = value;
        }
        public StudentModel SelectedStudent => _bsStudents.Current as StudentModel;

        /// <summary>
        /// Button _buttonAddStudent
        /// </summary>
        public ButtonEventHandler AddStudent
        {
            set
            {
                //value.Text = "Надпись на кнопке";
                _bsAddStudent.Clear();
                _bsAddStudent.Add(value);
                _buttonAddStudent.Click += value.Handler;
            }
        }

        /// <summary>
        /// Button _buttonEditStudent
        /// </summary>
        public ButtonEventHandler EditStudent
        {
            set
            {
                _bsEditStudent.Clear();
                _bsEditStudent.Add(value);
                _buttonEditStudent.Click += value.Handler;
            }
        }

        /// <summary>
        /// StatusLabel
        /// </summary>
        public string StatusCountStudents
        {
            get => _statusLabelCountStudents.Text;
            set => _statusLabelCountStudents.Text = value;
        }
    }
}
