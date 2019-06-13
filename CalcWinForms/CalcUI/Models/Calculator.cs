using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CalcUI.Models
{
    public class Calculator : INotifyPropertyChanged
    {
        //INPC
        public event PropertyChangedEventHandler PropertyChanged;


        //выводная строка
        private string _Output;
        public string Output
        {
            get => _Output;
            set
            {
                _Output = value;
                //оповещаем об изменении значения
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Output)));
            }
        }
        //протокол (коллекция с оповещением об изменении своего состава)
        public BindingList<string> Logs { get; private set; } = new BindingList<string>();
        //регистр
        public float Register { get; private set; }
        //правый операнд
        public float Operand { get; private set; }
        //операция
        public char Operation { get; private set; } = 'N';

        //--Цифры
        public void Zero() => Output += 0;
        public void One() => Output += 1;
        public void Two() => Output += 2;
        public void Three() => Output += 3;
        public void Four() => Output += 4;
        public void Five() => Output += 5;
        public void Six() => Output += 6;
        public void Seven() => Output += 7;
        public void Eight() => Output += 8;
        public void Nine() => Output += 9;

        //Запятая
        public void DecimalPoint()
        {
            if (String.IsNullOrEmpty(Output) || Output.Contains(',')) return;

            Output += ',';
        }

        //--Операции
        //сложение
        public void Addition()
        {
            //проверяем ввод
            if (String.IsNullOrEmpty(Output)) return;

            //присваиваем регистру или вычисляем
            MakeOperation();
            //назначаем операцию
            Operation = '+';
            //очищаем вывод
            Output = String.Empty;
        }

        //вычитание
        public void Subtraction()
        {
            //проверяем ввод
            if (String.IsNullOrEmpty(Output)) return;

            //присваиваем регистру или вычисляем
            MakeOperation();
            //назначаем операцию
            Operation = '-';
            //очищаем вывод
            Output = String.Empty;
        }

        //Знак =
        public void EqualSign()
        {
            //проверяем ввод
            if (String.IsNullOrEmpty(Output)) return;

            //вычисляем
            Сalculate();

            //обнуляем операцию
            Operation = 'N';
            //выводим результат
            Output = Register.ToString();
        }

        //очистка
        public void Clear()
        {
            Register = 0.0f;
            Operand = 0.0f;
            Operation = 'N';
            Output = String.Empty;
            Logs.Clear();
        }

        //проведение операции присвоения регистру или запуск вычисления
        private void MakeOperation()
        {
            if (Operation == 'N')
            {
                Register = float.Parse(Output);
                //в протокол
                Logs.Add(Register.ToString());
            }
            else
            {
                Сalculate();
            }
        }

        //вычисление предыдущей операции
        private void Сalculate()
        {
            //получаем правый операнд
            Operand = float.Parse(Output);
            //в протокол
            Logs.Add($"{Operation} {Operand}");

            //проводим нужную операцию
            switch (Operation)
            {
                case '+':
                    Register += Operand;
                    break;
                case '-':
                    Register -= Operand;
                    break;
                default:
                    Debug.WriteLine($"Попытка выполнения ошибочной операции {Operation}");
                    Output = String.Empty;
                    break;
            }

            //в протокол
            Logs.Add($"= {Register}");
        }
    }
}
