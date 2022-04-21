using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphingAlgorithms
{
    internal class GrahamScan
    {
        // To find the Next to top point in stack
        static Point NextToTop(Stack<Point> s)
        {
            Point p = s.Pop();
            Point res = s.Peek();
            s.Push(p);
            return res;
        }          

        // For New coordinates with origin at (495, 374) from top left
        static Point[] NewCoordinates(Point[] points)
        {            
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = points[i].X - 495;
                points[i].Y = 374 - points[i].Y;
            }
            return points;
        }

        // To get back old points in terms of coordinates from top left
        static Point[] OldCoordinates(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = points[i].X + 495;
                points[i].Y = 374 - points[i].Y;
            }
            return points;
        }

        static int Orientation(Point p, Point q, Point r)
        {
            float val = (float)((q.X - p.X) * (r.Y - q.Y) - (q.Y - p.Y) * (r.X - q.X));

            if (val == 0) return 0; // collinear
            return (val > 0) ? 1 : -1; // positive - counterclock wise, negative - clock wise
        }

        static float Slope(Point p, Point q)
        {
            if (q.X - p.X != 0)
            {
                return (float)(q.Y - p.Y)/(q.X - p.X);
            }
            else
            {
                return float.MaxValue;
            }
           
        }

        public static void SortByAngle(Point[] points)
        {       
            float[] anglesArray = new float[points.Length];
            anglesArray[0] = float.MinValue;

            for (int i = 1; i < points.Length; i++)
            {
                anglesArray[i] = Slope(points[0], points[i]);
            }

            Point tempPoint = new Point();
            float tempAngle = new float();
            for (int i = 0; i < anglesArray.Length; i++)
            {
                for (int j = 1; j < anglesArray.Length - 1; j++)
                {
                    if (anglesArray[j] < anglesArray[j+1])
                    {
                        tempAngle = anglesArray[j + 1];
                        anglesArray[j + 1] = anglesArray[j];
                        anglesArray[j] = tempAngle;

                        tempPoint = points[j + 1];
                        points[j + 1] = points[j];
                        points[j] = tempPoint;
                    }
                }
            }

        }


        public static Point[] GrahamScanMethod(Point[] pointsList)
        {
            if (pointsList.Length >= 3)
            {
                Point[] myPoints = NewCoordinates(pointsList);
                
                //left-most point
                int l = 0;
                for (int i = 0; i < myPoints.Length; i++)
                    if (myPoints[i].X <= myPoints[l].X)
                        l = i;


                // Swap Points
                Point temp = myPoints[l];
                myPoints[l] = myPoints[0];
                myPoints[0] = temp;


                SortByAngle(myPoints);

                Stack<Point> pointsStack = new Stack<Point>();

                pointsStack.Push(myPoints[0]);
                pointsStack.Push(myPoints[1]);

                for (int i = 2; i < myPoints.Length; i++)
                {
                    // Check Clockwise
                    if (Orientation(NextToTop(pointsStack), pointsStack.Peek(), myPoints[i]) <= 0)
                    {
                        pointsStack.Push(myPoints[i]);
                    }
                    else
                    {
                        pointsStack.Pop();
                        i--;
                    }
                }
                return OldCoordinates(pointsStack.ToArray());
            }
            else
            {
                MessageBox.Show("At least three points are required to make a polygon!");
                Point[] nLessThan3Points = { new Point(0, 0), new Point(0, 0) };
                return nLessThan3Points;
            }
        }
    }
}
