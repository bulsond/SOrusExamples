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
using WpfAppUI.Models;
using WpfAppUI.ViewModels;

namespace WpfAppUI
{
    public interface IMainWindow
    {
        string SelectSample();
        void ShowMessage(string message, string caption);
        void DrawPlace(FoundPlace place);
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainViewModel(this);
            this.DataContext = vm;
        }

        public string SelectSample()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            System.IO.FileInfo example = new System.IO.FileInfo("image.jpg");

            openFileDialog.CheckFileExists = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.Filter = string.Format("{0} файлы ({1})|*{1}",
                                    example.Extension.Substring(1).ToUpper(),
                                    example.Extension);

            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                return openFileDialog.FileName;
            }

            return String.Empty;
        }

        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void DrawPlace(FoundPlace place)
        {
            if (place == null) return;

            Rectangle rectangle = new Rectangle();
            rectangle.SetValue(Canvas.LeftProperty, place.Left + 10);
            rectangle.SetValue(Canvas.TopProperty, place.Top + 10);
            rectangle.Width = place.Width;
            rectangle.Height = place.Height;
            rectangle.Fill = new SolidColorBrush() { Color = Colors.Yellow, Opacity = 0.65f };

            _canvas.Children.Add(rectangle);
        }
    }
}
