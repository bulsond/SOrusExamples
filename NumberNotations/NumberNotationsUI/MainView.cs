using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberNotationsUI
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();

            //привязки
            SetBindings();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Системы счисления";
        }

        private void SetBindings()
        {
            //текстбоксы
            Binding bdInputText = new Binding("Text", _viewModel, nameof(MainViewModel.Input));
            bdInputText.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _textBoxInput.DataBindings.Add(bdInputText);

            _textBoxOutput.DataBindings.Add("Text", _viewModel, nameof(MainViewModel.Output));

            //комбобоксы
            _comboBoxInput.DataSource = _viewModel.InputNotations;
            Binding bdInput = new Binding(nameof(ComboBox.SelectedIndex),
                _viewModel, nameof(MainViewModel.SelectedInputNotation));
            bdInput.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _comboBoxInput.DataBindings.Add(bdInput);

            _comboBoxOutput.DataSource = _viewModel.OutputNotations;
            Binding bdOutput = new Binding(nameof(ComboBox.SelectedIndex),
                _viewModel, nameof(MainViewModel.SelectedOutputNotation));
            bdOutput.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _comboBoxOutput.DataBindings.Add(bdOutput);
        }
    }
}
