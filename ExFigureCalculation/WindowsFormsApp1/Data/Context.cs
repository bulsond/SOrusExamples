using System.Collections.Generic;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Data
{
    public class Context
    {
        private List<Figure> _figures;

        //ctor
        public Context()
        {
            _figures = new List<Figure>
            {
                new EmptyFigure("Какая?", new EmptyFigureView()),
                new Circle("Окружность", new CircleView(), 1),
                new Trapezium("Трапеция", new TrapeziumView(), 1, 2, 1)
            };
        }

        public List<Figure> GetFigures()
        {
            return _figures;
        }
    }
}
