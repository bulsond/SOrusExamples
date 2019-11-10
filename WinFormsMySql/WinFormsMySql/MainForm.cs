using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsMySql.Interfaces;
using WinFormsMySql.Models;
using WinFormsMySql.Services;
using WinFormsMySql.Utils;

namespace WinFormsMySql
{
    public partial class MainForm : Form
    {
        //Источник данных для DGV
        private BindingSource _bsEmployees;
        //редактируемый сотрудник
        private BindingSource _bsCurrentEmployee;
        //работа с БД
        private IEmployeeRepository _repo;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пример работы с MySql";

            //установка привязок
            SetBindings();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //тестовый репозиторий
            _repo = new TestRepository();
            //реальный репозиторий
            //_repo = new MySqlRepository();

            //Загрузка данных
            LoadData();

            //кнопки
            _buttonAdd.Click += ButtonAdd_Click;
            _buttonRemove.Click += ButtonRemove_Click;
            _buttonSave.Click += ButtonSave_Click;
            _buttonNext.Click += ButtonNext_Click;
            _buttonPrev.Click += ButtonPrev_Click;
            //клик по строке в DGV
            _dataGridViewEmployees.MouseClick += (s, a) => SetCurrentEmployee();
        }

        private void SetBindings()
        {
            _bsEmployees = new BindingSource();
            _bsEmployees.DataSource = typeof(List<Employee>);
            //привязки для DGV
            _dataGridViewEmployees.AutoGenerateColumns = false;
            _dataGridViewEmployees.DataSource = _bsEmployees;
            //привязки у столбцов
            _columnNumber.DataPropertyName = nameof(Employee.OrderNumber);
            _columnFirstName.DataPropertyName = nameof(Employee.FirstName);
            _columnLastName.DataPropertyName = nameof(Employee.LastName);
            _columnPhone.DataPropertyName = nameof(Employee.Phone);

            //текстбоксы
            _bsCurrentEmployee = new BindingSource();
            _bsCurrentEmployee.DataSource = new List<Employee> { new Employee(0) };
            _textBoxFirstName.DataBindings.Add("Text", _bsCurrentEmployee, nameof(Employee.FirstName));
            _textBoxLastName.DataBindings.Add("Text", _bsCurrentEmployee, nameof(Employee.LastName));
            _textBoxPhone.DataBindings.Add("Text", _bsCurrentEmployee, nameof(Employee.Phone));
        }

        private async void LoadData()
        {
            //получаем
            var result = await _repo.GetEmployees();
            if (result)
            {
                //извлекаем
                List<Employee> employees = result.Value;
                //пронумеровываем
                int i = 1;
                employees.ForEach(e => e.OrderNumber = i++);
                //отображаем
                _bsEmployees.DataSource = employees;
                _bsEmployees.MoveFirst();
                SetCurrentEmployee();
            }
            else
            {
                MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //курсор на последнего
            _bsEmployees.MoveLast();
            //след.порядковый номер
            int number = (_bsEmployees.Current as Employee).OrderNumber + 1;
            //добавляем нового
            _bsEmployees.Add(new Employee(0) { OrderNumber = number });
            //выделяем его
            _bsEmployees.MoveNext();
            SetCurrentEmployee();
            //выделяем имя для редактирования
            _textBoxFirstName.Focus();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            SwitchOnWaiting();

            //получаем текущего
            var current = (Employee)_bsCurrentEmployee.Current;
            //проверяем введенную информацию заполнены
            if (!IsCorrectCurrent(current))
            {
                return;
            }

            Result<int> result;

            try
            {
                if (current.Id == 0)
                {
                    //добавляем нового сотрудника
                    result = await _repo.AddEmployee(current);
                }
                else
                {
                    //иначе обновляем существующего сотрудника
                    result = await _repo.UpdateEmployee(current);
                }

                if (result)
                {
                    //перечитываем данные
                    LoadData();
                }
            }
            finally
            {
                SwitchOffWaiting();
            }

            if(!result)
            {
                MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsCorrectCurrent(Employee employee)
        {
            bool isCorrect = true;

            string mask = "<?>";
            if (String.IsNullOrWhiteSpace(employee.FirstName)
                || String.IsNullOrEmpty(employee.FirstName)
                || employee.FirstName.Equals(mask))
            {
                isCorrect = false;
                var message = "Введите имя сотрудника.";
                MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (String.IsNullOrWhiteSpace(employee.LastName)
                || String.IsNullOrEmpty(employee.LastName)
                || employee.LastName.Equals(mask))
            {
                isCorrect = false;
                var message = "Введите фамилию сотрудника.";
                MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isCorrect;
        }

        private async void ButtonRemove_Click(object sender, EventArgs e)
        {
            SwitchOnWaiting();

            //получаем текущего
            var employee = (Employee)_bsEmployees.Current;
            Result<int> result;
            try
            {
                //удаляем из БД
                result = await _repo.RemoveEmployee(employee.Id);
                if (result)
                {
                    //удаляем из отображения
                    _bsEmployees.Remove(employee);
                    _bsEmployees.MoveFirst();
                    SetCurrentEmployee();
                }
            }
            finally
            {
                SwitchOffWaiting();
            }

            if (!result)
            {
                MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            _bsEmployees.MovePrevious();
            SetCurrentEmployee();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            _bsEmployees.MoveNext();
            SetCurrentEmployee();
        }

        private void SetCurrentEmployee()
        {
            if (_bsEmployees.Count > 0)
            {
                _bsCurrentEmployee.List[0] = Employee.GetClone((Employee)_bsEmployees.Current);
                 
            }
            else
            {
                _bsCurrentEmployee.List[0] = new Employee(0);
            }

            _bsCurrentEmployee.ResetItem(0);
        }

        private void SwitchOnWaiting()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
            _dataGridViewEmployees.Enabled = false;
            Cursor = Cursors.WaitCursor;
        }

        private void SwitchOffWaiting()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
            _dataGridViewEmployees.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}
