using System;
using System.ComponentModel;

namespace WpfApp1
{
    public class RadioButtonViewModel : INotifyPropertyChanged
    {
        private readonly string _template;
        private readonly Func<string, bool> _checkEqualsTemplate;
        private readonly Action<string> _assigningValue;

        //ctor
        public RadioButtonViewModel(string template,
                            Func<string, bool> checkEqualsTemplate, Action<string> assigningValue)
        {
            if (String.IsNullOrEmpty(template))
                throw new ArgumentNullException(nameof(template));

            _template = template;

            _checkEqualsTemplate = checkEqualsTemplate
                ?? throw new ArgumentNullException(nameof(checkEqualsTemplate));

            _assigningValue = assigningValue
                ?? throw new ArgumentNullException(nameof(assigningValue));
        }

        public bool RadioButtonValue
        {
            get => _checkEqualsTemplate(_template);
            set => _assigningValue(_template);
        }

        public void RaisePropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RadioButtonValue)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
