using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
    public class EmptyFigure : Figure
    {
        public EmptyFigure(string figureName, UserControl userControl) : base(figureName, userControl)
        {
        }

        protected override double GetArea()
        {
            return base.GetArea();
        }
    }
}
