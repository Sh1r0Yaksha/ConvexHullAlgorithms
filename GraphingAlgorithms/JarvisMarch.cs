﻿using System;
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

        //(0,0) of graph at (495,374)

        private void JarvisMarch_Paint(object sender, PaintEventArgs e)
        {
            // Create four Pen objects with red,
            // blue, green, and black colors and
            // different widths
            Pen redPen = new Pen(Color.Red, 1);
            Pen blackPen = new Pen(Color.Black, 2);
            Brush greenBrush = new SolidBrush(Color.Green);

            e.Graphics.DrawLine(blackPen, 11, 374, 990, 374); // HORIZONTAL AXIS
            e.Graphics.DrawLine(blackPen, 495, 0, 495, 758); // VERTICAL AXIS

            Point[] newCoords = CoordinatesInMyAxis(Values.points);

            

            for (int i = 0; i < Values.scaleValue * 500; i += Values.scaleValue)
            {
                e.Graphics.DrawLine(blackPen, i + 495, 371, i + 495, 377); // x-axis labels
                e.Graphics.DrawLine(blackPen, 495 - i, 371, 495 - i, 377);
                e.Graphics.DrawLine(blackPen, 492, i + 374, 498, i + 374); // y-axis labels
                e.Graphics.DrawLine(blackPen, 492, 374 - i, 498, 374 - i);
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
                List<Point> hull = new List<Point>();
                hull.Add(new Point(0, 0));
                return hull.ToArray();
            }
        }

        public Point[] CoordinatesInMyAxis(Point[] point)
        {
            for (int i = 0; i < point.Length; i++)
            {
                point[i].X = 495 + (Values.scaleValue * point[i].X);
                point[i].Y = 374 - (Values.scaleValue * point[i].Y);
            }

            return point;
        }
    }
}