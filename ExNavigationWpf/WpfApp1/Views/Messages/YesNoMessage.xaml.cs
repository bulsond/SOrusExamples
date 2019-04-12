using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Views.Messages
{
    /// <summary>
    /// Interaction logic for YesNoMessage.xaml
    /// </summary>
    public partial class YesNoMessage : UserControl
    {
        private bool _waitClick = true;
        private bool _result;

        public YesNoMessage()
        {
            InitializeComponent();

            DataContext = this;
        }

        public string Text { get; set; }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            _result = false;
            this.Visibility = Visibility.Collapsed;
            _waitClick = false;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            _result = true;
            this.Visibility = Visibility.Collapsed;
            _waitClick = false;
        }

        internal async Task<bool> GetResult()
        {
            Action action = () => { while (_waitClick) { } };
            await Task.Run(action);

            return _result;
        }

        
    }
}
