using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
    public abstract class Figure
    {
        //ctor
        public Figure(string figureName, UserControl userControl)
        {
            if (String.IsNullOrEmpty(figureName)) throw new ArgumentException(nameof(figureName));
            if (userControl == null) throw new ArgumentNullException(nameof(userControl));

            Name = figureName;
            Control = userControl;
        }

        public string Name { get; private set; }

        public UserControl Control { get; private set; }

        public double Area => GetArea();

        protected virtual double GetArea()
        {
            return 0;
        }
    }
}
