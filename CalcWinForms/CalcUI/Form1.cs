using CalcUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcUI
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Типа вычислитель";

            //инициализируем
            _calculator = new Calculator();

            //устанавливаем привязки
            SetBindings();

            //события на нажатия цифровых кнопок
            _button0.Click += ButtonDigit_Click;
            _button1.Click += ButtonDigit_Click;
            _button2.Click += ButtonDigit_Click;
            _button3.Click += ButtonDigit_Click;
            _button4.Click += ButtonDigit_Click;
            _button5.Click += ButtonDigit_Click;
            _button6.Click += ButtonDigit_Click;
            _button7.Click += ButtonDigit_Click;
            _button8.Click += ButtonDigit_Click;
            _button9.Click += ButtonDigit_Click;
            //события на нажатия остальных кнопок
            _buttonClear.Click += Button_Click;
            _buttonPoint.Click += Button_Click;
            _buttonPlus.Click += Button_Click;
            _buttonMinus.Click += Button_Click;
            _buttonEqual.Click += Button_Click;

            _buttonBackspace.Click += ButtonBackspace_Click;
        }

        //установка привязок
        private void SetBindings()
        {
            _textBoxOutput.DataBindings.Add("Text", _calculator, nameof(_calculator.Output));
            _listBoxLog.DataSource = _calculator.Logs;
        }

        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            switch (button.Text)
            {
                case "0":
                    _calculator.Zero();
                    break;
                case "1":
                    _calculator.One();
                    break;
                case "2":
                    _calculator.Two();
                    break;
                case "3":
                    _calculator.Three();
                    break;
                case "4":
                    _calculator.Four();
                    break;
                case "5":
                    _calculator.Five();
                    break;
                case "6":
                    _calculator.Six();
                    break;
                case "7":
                    _calculator.Seven();
                    break;
                case "8":
                    _calculator.Eight();
                    break;
                case "9":
                    _calculator.Nine();
                    break;
                default:
                    Debug.WriteLine("Неправильный вызов на цифровой кнопке!");
                    break;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            switch (button.Text)
            {
                case "C":
                    _calculator.Clear();
                    break;
                case ",":
                    _calculator.DecimalPoint();
                    break;
                case "+":
                    _calculator.Addition();
                    break;
                case "-":
                    _calculator.Subtraction();
                    break;
                case "=":
                    _calculator.EqualSign();
                    break;
                default:
                    Debug.WriteLine("Неправильный вызов на нецифровой кнопке!");
                    break;
            }
        }

        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_calculator.Output)) return;

            _calculator.Output = _calculator.Output.Remove(_calculator.Output.Length - 1);
        }
    }
}
