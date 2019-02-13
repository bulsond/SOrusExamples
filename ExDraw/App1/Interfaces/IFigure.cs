using System.Drawing;

namespace App1.Interfaces
{
    public enum FigureType
    {
        Circle,
        Line,
        Rectangle,
        Sector,
        Text,
        Ellipse,
        ShadedSector
    }

    interface IFigure
    {
        FigureType Type { get; }
        string Name { get; }
        Point FirstPoint { get; set; }
        Point SecondPoint { get; set; }
    }
}
