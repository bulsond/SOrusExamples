using App1.Interfaces;
using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        private IFigure _selectedFigure;
        private bool _IsDrawing;

        public Form1()
        {
            InitializeComponent();

            SetDataToListBox();

            _listBoxFigures.SelectedIndexChanged += ListBoxFigures_SelectedChanged;
            _panelCanvas.MouseDown += PanelCanvas_MouseDown;
            _panelCanvas.MouseUp += PanelCanvas_MouseUp;
            _panelCanvas.Paint += PanelCanvas_Paint;

            this.CenterToScreen();
            this.Text = "Примерчик";
        }

        /// <summary>
        /// Заполнение списка
        /// </summary>
        private void SetDataToListBox()
        {
            _listBoxFigures.DataSource = new List<IFigure>
            {
                new Figure(FigureType.Line, "Отрезок"),
                new Figure(FigureType.Rectangle, "Прямоугольник"),
                new Figure(FigureType.Circle, "Окружность"),
            };
            _listBoxFigures.DisplayMember = nameof(IFigure.Name);
        }

        /// <summary>
        /// Обработка события выбора в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxFigures_SelectedChanged(object sender, EventArgs e)
        {
            if (_listBoxFigures.SelectedItem == null) return;

            _selectedFigure = _listBoxFigures.SelectedItem as IFigure;
        }

        /// <summary>
        /// Обработка события нажатия левой кнопки мыши на Панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedFigure == null) return;

            _selectedFigure.FirstPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Обработка события отпускания кнопки мыши на Панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectedFigure == null) return;

            _selectedFigure.SecondPoint = new Point(e.X, e.Y);

            _IsDrawing = true;
            _panelCanvas.Refresh();
        }

        /// <summary>
        /// Обработка события перерисовки Панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!_IsDrawing) return;

            switch (_selectedFigure.Type)
            {
                case FigureType.Circle:
                    throw new NotImplementedException();
                case FigureType.Line:
                    DrawLine(e.Graphics);
                    break;
                case FigureType.Rectangle:
                    DrawRectangle(e.Graphics);
                    break;
                case FigureType.Sector:
                    throw new NotImplementedException();
                case FigureType.Text:
                    throw new NotImplementedException();
                case FigureType.Ellipse:
                    throw new NotImplementedException();
                case FigureType.ShadedSector:
                    throw new NotImplementedException();
            }

            _IsDrawing = false;
        }

        /// <summary>
        /// Рисование Прямоугольника
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawRectangle(Graphics graphics)
        {
            var width = _selectedFigure.SecondPoint.X - _selectedFigure.FirstPoint.X;
            var height = _selectedFigure.SecondPoint.Y - _selectedFigure.FirstPoint.Y;

            var rectangle =
                new Rectangle(_selectedFigure.FirstPoint.X, _selectedFigure.FirstPoint.Y, width, height);
            Pen blackPen = new Pen(Color.Black, 5);
            graphics.DrawRectangle(blackPen, rectangle);
            blackPen.Dispose();
        }

        /// <summary>
        /// Рисование Линии
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawLine(Graphics graphics)
        {
            Pen blackPen = new Pen(Color.Black, 5);
            graphics.DrawLine(blackPen, _selectedFigure.FirstPoint, _selectedFigure.SecondPoint);
            blackPen.Dispose();
        }
    }
}
