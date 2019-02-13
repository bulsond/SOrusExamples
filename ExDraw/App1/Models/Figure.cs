using App1.Interfaces;
using System;
using System.Drawing;

namespace App1.Models
{
    class Figure : IFigure
    {
        //ctor
        public Figure(FigureType figureType, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

            Type = figureType;
            Name = name;
        }

        public FigureType Type { get; private set; }
        public string Name { get; private set; }
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
    }
}
