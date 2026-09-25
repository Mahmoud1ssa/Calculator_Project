using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//If you move this class file to a new project...
//don't forget to rename the "namespace" of this file to the project name.
namespace clsTools_File
{
    internal class clsTools
    {
        public enum enColor { Black = 0, White = 1 };
        public enum enCap { Round = 0, ArrowAnchor = 1, Flat = 2 };
        public enum enShape { Line = 0, Rectangle = 1, Ellipse = 2 };

        public void DrawShape(PaintEventArgs e, enColor PenColor, enCap Cap, enShape Shape, float Width,
            float StartCoordinateX, float StartCoordinateY, float EndCoordinateX, float EndCoordinateY)
        {
            // Setting the color of the pen...
            Color color;
            if (PenColor == enColor.Black)
                color = Color.FromArgb(255, 0, 0, 0);

            else
                color = Color.FromArgb(255, 255, 255, 255);


            // Defining the Pen and giving it the Color & Width...
            Pen DrawPen = new Pen(color);
            DrawPen.Width = Width;


            // Setting the Start & End Caps (both will have the same value)...
            if (Cap == enCap.ArrowAnchor)
            {
                DrawPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                DrawPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            }
            else if(Cap == enCap.Flat)
            {
                DrawPen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
                DrawPen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            else
            {
                DrawPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                DrawPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            }


            // Drawing the Shape wanted with the wanted coordinates...
            if (Shape == enShape.Ellipse)
                e.Graphics.DrawEllipse(DrawPen, StartCoordinateX, StartCoordinateY, EndCoordinateX, EndCoordinateY);
            
            else if(Shape == enShape.Rectangle)
                e.Graphics.DrawRectangle(DrawPen, StartCoordinateX, StartCoordinateY, EndCoordinateX, EndCoordinateY);

            else
                e.Graphics.DrawLine(DrawPen, StartCoordinateX, StartCoordinateY, EndCoordinateX, EndCoordinateY);

        }
    }
}
