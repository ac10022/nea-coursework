using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automatic_question_generation_testing
{
    internal class GraphingHelper
    {
        private Func<double, double> function;
        private double increment;
        private int domainMin;
        private int domainMax;
        private List<PointD> points;
        private Panel panel;
        // manual override scalars
        private double X_scalar;
        private double Y_scalar;

        /// <summary>
        /// Constructor for GraphingHelper; 
        /// - function is a function in x
        /// - increment affects accuracy of graph, for linear graphs, use a double > 1, for trigonometric or polynomial graphs use a value 0.01 <= x <= 0.1.
        /// - domainMin, domainMax used to specify domain
        /// - panelReference is the panel the graph should be displayed on, this should preferably be 200 * 200
        /// - (optional) X_scalar, Y_scalar - manual scalars to zoom-in/out, 20 for both works well.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="increment"></param>
        /// <param name="domainMin"></param>
        /// <param name="domainMax"></param>
        /// <param name="panelReference"></param>
        /// <param name="X_scalar"></param>
        /// <param name="Y_scalar"></param>
        public GraphingHelper(Func<double, double> function, double increment, int domainMin, int domainMax, Panel panelReference, double X_scalar = 0, double Y_scalar = 0)
        {
            this.function = function;
            this.increment = increment;
            this.domainMin = domainMin;
            this.domainMax = domainMax;
            this.panel = panelReference;
            this.X_scalar = X_scalar;
            this.Y_scalar = Y_scalar;
        }

        public List<PointD> GetPointsInFunctionRange()
        {
            List<PointD> pointList = new List<PointD>();
            for (double i = domainMin; i <= domainMax; i += increment)
            {
                if (i == 0) continue; // prevent divide by 0 errors
                double mapping = DoubleClamp(function(i), -1000, 1000); // prevent overflow errors
                pointList.Add(new PointD(Math.Round(i, 2), Math.Round(mapping, 2)));
            }
            this.points = pointList;
            return pointList;
        }

        private (double rangeMin, double rangeMax) GetRange()
        {
            return (points.Min(x => x.Y), points.Max(x => x.Y));
        }

        public (double rangeMin, double rangeMax) GetRangeFromPoints(List<PointD> points)
        {
            return (points.Min(x => x.Y), points.Max(x => x.Y));
        }

        public void DrawAxis(object sender, PaintEventArgs paintEvent)
        {
            int panelWidth = panel.Width;
            Graphics g = paintEvent.Graphics;
            Pen pen = new Pen(Color.Gray, 2f);

            g.DrawLine(pen, panelWidth / 2, 0, panelWidth / 2, panelWidth); // y-axis
            g.DrawLine(pen, 0, panelWidth / 2, panelWidth, panelWidth / 2); // x-axis

            Font font = new Font(FontFamily.GenericSansSerif, 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            double Xscalar, Yscalar;
            if (X_scalar != 0 || Y_scalar != 0)
            {
                Xscalar = X_scalar;
                Yscalar = Y_scalar;
            }
            else
            {
                double scalar = FindScalar();
                Xscalar = scalar;
                Yscalar = scalar;
            }

            //x-axis
            for (int x = 0; x <= panelWidth / (int)Xscalar; x++)
            {
                g.DrawString((x - (0.5*panelWidth / (int)Xscalar)).ToString(), font, brush, (float)(x * Xscalar) - 8, panelWidth / 2 - 8);
            }

            //y-axis
            for (int y = 0; y <= panelWidth / (int)Yscalar; y++)
            {
                g.DrawString((-1 * (y - (0.5 * panelWidth / (int)Yscalar))).ToString(), font, brush, panelWidth / 2 - 8, (float)(y * Yscalar) - 8);
            }
        }

        public void DrawPoints(object sender, PaintEventArgs paintEvent)
        {
            Graphics g = paintEvent.Graphics;
            Pen pen = new Pen(Color.Red, 2f);
            for (int i = 0; i < points.Count - 1; i++)
            {
                PointD point = points[i];
                PointD nextPoint = points[i + 1];
                // prevent a line being drawn in place of an asymptote
                if (Math.Abs(nextPoint.X - point.X) > 100 || Math.Abs(nextPoint.Y - point.Y) > 100) continue;
                g.DrawLine(pen, (float)point.X, (float)point.Y, (float)nextPoint.X, (float)nextPoint.Y);
            }
        }

        public double FindScalar()
        {
            double panelHeight = panel.Size.Height;
            (double rangeMin, double rangeMax) = GetRange();
            double maxDistanceFromAxis;
            if ((rangeMin >= 0 && rangeMax >= 0) || rangeMin <= 0 && rangeMax <= 0)
            {
                maxDistanceFromAxis = Math.Max(Math.Abs(rangeMin), Math.Abs(rangeMax)) + 1;
            }
            else
            {
                maxDistanceFromAxis = Math.Min(Math.Abs(rangeMin), Math.Abs(rangeMax)) + 1;
            }
            return panelHeight / (maxDistanceFromAxis * 2);
        }

        public List<PointD> ScalePoints()
        {
            double Xscalar, Yscalar;
            if (X_scalar != 0 || Y_scalar != 0)
            {
                Xscalar = X_scalar;
                Yscalar = Y_scalar;
            }
            else
            {
                double scalar = FindScalar();
                Xscalar = scalar;
                Yscalar = scalar;
            }
            foreach (PointD point in points)
            {
                point.X *= Xscalar;
                point.X += (panel.Height / 2);
                point.Y *= -1 * Yscalar;
                point.Y += (panel.Height / 2);
            }
            return points;
        }

        public double DoubleClamp(double num, double min, double max)
        {
            if (num < min)
                return min;
            if (num > max)
                return max;
            return num;
        }

        public (Bitmap image, List<PointD> points) PlotFunction()
        {
            GetPointsInFunctionRange();
            ScalePoints();
            panel.Paint += new PaintEventHandler(DrawAxis);
            panel.Paint += new PaintEventHandler(DrawPoints);
            Bitmap graphImage = ExportGraph();
            panel.Refresh();
            List<PointD> pointRef = points;
            points.Clear();
            return (graphImage, pointRef);
        }

        private Bitmap ExportGraph()
        {
            Bitmap bmp = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));
            return bmp;
        }
    }

    public class PointD
    {
        public double X;
        public double Y;

        public PointD(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}