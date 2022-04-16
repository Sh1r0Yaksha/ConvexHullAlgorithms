using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphingAlgorithms
{
    public partial class JarvisMarch : Form
    {
        public JarvisMarch()
        {
            InitializeComponent();
        }

        private void JarvisMarch_Paint(object sender, PaintEventArgs e)
        {
            // Create four Pen objects with red,
            // blue, green, and black colors and
            // different widths
            Pen redPen = new Pen(Color.Red, 1);
            Pen blackPen = new Pen(Color.Black, 2);
            Brush greenBrush = new SolidBrush(Color.Green);

            e.Graphics.DrawLine(blackPen, 10, 500, 550, 500); // HORIZONTAL AXIS
            e.Graphics.DrawLine(blackPen, 10, 500, 10, 0);

            Point[] newCoords = CoordinatesInMyAxis(Values.points);

            //(0,0) of graph at (10,500)

            for (int i = Values.scaleValue; i < Values.scaleValue * 13; i += Values.scaleValue)
            {
                e.Graphics.DrawLine(blackPen, i + 10, 497, i + 10, 503); // x-axis labels
                e.Graphics.DrawLine(blackPen, 7, (500 - i), 13, (500 - i)); // y-axis labels
            }

            for (int i = 0; i < newCoords.Length; i++)
            {
                e.Graphics.FillEllipse(greenBrush, newCoords[i].X - 2, newCoords[i].Y - 2, 4, 4);
            }

            Point[] convexHulls = ConvexHull(newCoords);

            for (int i = 0; i < convexHulls.Length - 1; i++)
            {
                Thread.Sleep(500);
                e.Graphics.DrawLine(redPen, convexHulls[i].X, convexHulls[i].Y, convexHulls[i + 1].X, convexHulls[i + 1].Y);


            }
            Thread.Sleep(500);
            e.Graphics.DrawLine(redPen, convexHulls[convexHulls.Length - 1].X, convexHulls[convexHulls.Length - 1].Y, convexHulls[0].X, convexHulls[0].Y);

        }

        public int orientation(Point p, Point q, Point r)
        {
            int val = (q.X - p.X) * (r.Y - q.Y) - (q.Y - p.Y) * (r.X - q.X);

            if (val == 0) return 0; // collinear
            return (val > 0) ? 1 : -1; // counterclock or clock wise
        }

        public Point[] ConvexHull(Point[] points)
        {
            // There must be at least 3 points

            if (points.Length > 3)
            {
                // Initialize Result
                List<Point> hull = new List<Point>();

                // Find the leftmost point
                int l = 0;
                for (int i = 1; i < points.Length; i++)
                    if (points[i].X < points[l].X)
                        l = i;

                // Start from leftmost point, keep moving
                // counterclockwise until reach the start point
                // again. This loop runs O(h) times where h is
                // number of points in result or output.
                int p = l, q;
                do
                {
                    // Add current point to result
                    hull.Add(points[p]);

                    // Search for a point 'q' such that
                    // orientation(p, q, x) is counterclockwise
                    // for all points 'x'. The idea is to keep
                    // track of last visited most counterclock-
                    // wise point in q. If any point 'i' is more
                    // counterclock-wise than q, then update q.
                    q = (p + 1) % points.Length;

                    for (int i = 0; i < points.Length; i++)
                    {
                        // If i is more counterclockwise than
                        // current q, then update q
                        if (orientation(points[p], points[i], points[q])
                                                            == 1)
                        {
                            q = i;
                        }

                    }

                    // Now q is the most counterclockwise with
                    // respect to p. Set p as q for next iteration,
                    // so that q is added to result 'hull'
                    p = q;

                } while (p != l); // While we don't come to first

                return hull.ToArray();

            }

            else
            {
                Point[] hull = new Point[1];
                hull[0] = new Point(0, 0);
                return hull.ToArray();
            }
        }

        public Point[] CoordinatesInMyAxis(Point[] point)
        {
            //for (int i = 0; i < point.Length; i++)
            //{
            //    point[i].X = 10 + (Values.Scale * point[i].X);
            //    point[i].Y = 500 - (Values.Scale * point[i].Y);
            //}

            return point;
        }
    }
}
