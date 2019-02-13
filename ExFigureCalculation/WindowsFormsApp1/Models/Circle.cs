using System;
using System.Windows.Forms;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Models
{
    public class Circle : Figure
    {

        public Circle(string figureName, UserControl userControl,
                      double diameter) : base(figureName, userControl)
        {
            if (diameter <= 0) throw new ArgumentException($"Неверное значение для {nameof(diameter)}");
            Diameter = diameter;

            //даем ссылку вьюшке
            (Control as CircleView).Circle = this;
        }

        private double _Diameter;
        public double Diameter
        {
            get => _Diameter;
            set
            {
                _Diameter = value;
                _Radius = _Diameter / 2;
            }
        }

        private double _Radius;
        public double Radius
        {
            get => _Radius;
            set
            {
                _Radius = value;
                _Diameter = _Radius * 2;
            }
        }

        protected override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
