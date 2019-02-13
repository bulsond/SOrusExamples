using System;
using System.ComponentModel;

/// <summary>
/// Использование
/// 
///     Во View
///         private BindingSource _bsAddStudent = new BindingSource();    
/// 
///         _bsAddStudent.DataSource = typeof(ButtonEventHandler);
///         _buttonAddStudent.DataBindings.Add(nameof(_buttonAddStudent.Enabled),
///             _bsAddStudent, nameof(ButtonEventHandler.Enabled)); //доступность кнопки
///         _buttonAddStudent.DataBindings.Add(nameof(_buttonAddStudent.Text),
///             _bsAddStudent, nameof(ButtonEventHandler.Text)); //надпись на кнопке
///         
///         public ButtonEventHandler AddStudent
///        {
///            set
///            {
///                //value.Text = "Надпись на кнопке";
///                _bsAddStudent.Clear();
///                _bsAddStudent.Add(value);
///                _buttonAddStudent.Click += value.Handler;
///            }
///        }
///         
///     В Presenter
///         _mainView.AddStudent = new ButtonEventHandler(OnAddStudent);
///     
/// </summary>

namespace DataBase1.Views.EventHandlers
{
    public class ButtonEventHandler : ABaseEventHandler, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //ctor
        public ButtonEventHandler(Action handler) : this(handler, null)
        { }
        public ButtonEventHandler(Action handler, Action setButtonEnabled): base(handler)
        {
            if (setButtonEnabled == null)
            {
                SetButtonEnabled = () => Enabled = true;
            }
            else
            {
                SetButtonEnabled = setButtonEnabled;
            }
        }

        /// <summary>
        /// Ссылка на метод, кот. будет устанавливать доступность кнопки
        /// </summary>
        public Action SetButtonEnabled { get; private set; }


        private bool _Enabled = true;
        /// <summary>
        /// Включение / выключение кнопки
        /// </summary>
        public bool Enabled
        {
            get => _Enabled;
            private set
            {
                _Enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enabled)));
            }
        }


        private string _Text = String.Empty;
        /// <summary>
        /// Надпись на кнопке
        /// </summary>
        public string Text
        {
            get => _Text;
            set
            {
                _Text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

    }
}
