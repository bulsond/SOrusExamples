using System;
using System.Windows.Forms;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Models
{
    public class Trapezium : Figure
    {
        public Trapezium(string figureName, UserControl userControl,
            double upperBase, double lowerBase, double height) : base(figureName, userControl)
        {
            if (upperBase <= 0) throw new ArgumentException($"Неверное значение для {nameof(upperBase)}");
            if (lowerBase <= 0) throw new ArgumentException($"Неверное значение для {nameof(lowerBase)}");
            if (height <= 0) throw new ArgumentException($"Неверное значение для {nameof(height)}");

            UpperBase = upperBase;
            LowerBase = lowerBase;
            Height = height;

            //даем ссылку вьюшке
            (Control as TrapeziumView).Trapezium = this;
        }

        public double UpperBase { get; set; }
        public double LowerBase { get; set; }
        public double Height { get; set; }

        protected override double GetArea()
        {
            return (UpperBase + LowerBase) * Height / 2;
        }
    }
}
