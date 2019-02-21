using NumberNotationsUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NumberNotationsUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //сервис нотаций
        private INotationService _service;

        //ctor
        public MainViewModel()
        {
            _service = new NotationService();

            InputNotations = _service.GetNotationsNames();
            OutputNotations = _service.GetNotationsNames();

            SelectedInputNotation = 0;
            SelectedOutputNotation = 0;
        }

        /// <summary>
        /// Входное число
        /// </summary>
        private string _Input;
        public string Input
        {
            get => _Input;
            set
            {
                _Input = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Input)));
                //
                SetOutput();
            }
        }

        /// <summary>
        /// Результат
        /// </summary>
        private string _Output;
        public string Output
        {
            get => _Output;
            set
            {
                _Output = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Output)));
            }
        }

        //списки нотаций для комбобоксов
        public List<string> InputNotations { get; private set; }
        public List<string> OutputNotations { get; private set; }


        /// <summary>
        /// Начальная нотация (выбор в верхн.комбобоксе)
        /// </summary>
        private string _SelectedInputNotation;
        public int SelectedInputNotation
        {
            get => InputNotations.FindIndex(n => n == _SelectedInputNotation);
            set
            {
                _SelectedInputNotation = InputNotations[value];
                SetOutput();
            }
        }

        /// <summary>
        /// Конечная нотация (выбор в нижн.комбобксе)
        /// </summary>
        private string _SelectedOutputNotation;
        public int SelectedOutputNotation
        {
            get => OutputNotations.FindIndex(n => n == _SelectedOutputNotation);
            set
            {
                _SelectedOutputNotation = OutputNotations[value];
                SetOutput();
            }
        }


        /// <summary>
        /// Вывод конечного числа
        /// </summary>
        private void SetOutput()
        {
            if (String.IsNullOrEmpty(Input))
            {
                Output = String.Empty;
                return;
            }

            Output = _service.GetNotationValue(_SelectedInputNotation,
                Input, _SelectedOutputNotation);

            if (String.IsNullOrEmpty(Output))
            {
                Output = "неприменимо";
            }
        }
    }
}
