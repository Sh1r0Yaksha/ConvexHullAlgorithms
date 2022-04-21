namespace GraphingAlgorithms
{
    public partial class Values : Form
    {

        List<Point> points = new List<Point>();
        Pen blackPen = new Pen(Color.Black, 2);
        Pen redPen = new Pen(Color.Red, 1);
        

        public Values()
        {
            InitializeComponent();
        }

        int orientation(Point p, Point q, Point r)
        {
            int val = (q.X - p.X) * (r.Y - q.Y) - (q.Y - p.Y) * (r.X - q.X);

            if (val == 0) return 0; // collinear
            return (val > 0) ? 1 : -1; // positive - counterclock wise, negative - clock wise
        }

        public Point[] JarvisMarch(List<Point> points)
        {
            // There must be at least 3 points
            if (points.Count >= 3)
            {
                List<Point> hull = new List<Point>();

                //left-most point
                int l = 0;
                for (int i = 1; i < points.Count; i++)
                    if (points[i].X < points[l].X)
                        l = i;

                int p = l, q;
                do
                {
                    hull.Add(points[p]);

                    q = (p + 1) % points.Count;

                    for (int i = 0; i < points.Count; i++)
                    {
                        if (orientation(points[p], points[i], points[q]) == 1)
                            q = i; // most counter clockwise
                    }

                    p = q; // add most counter clockwise to hull

                } while (p != l); // While we don't come to first

                return hull.ToArray();
            }

            else
            {
                MessageBox.Show("At least three points are required to make a polygon!");
                Point[] nLessThan3Points = { new Point(0, 0), new Point(0, 0) };
                return nLessThan3Points;
            }
        }

        // Origin at (495,374)
        private void Values_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 2);

            e.Graphics.DrawLine(blackPen, 11, 374, 990, 374); // HORIZONTAL AXIS
            e.Graphics.DrawLine(blackPen, 495, 0, 495, 758); // VERTICAL AXIS
        }

        private void Values_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillEllipse(new SolidBrush(Color.Green), e.X - 2, e.Y - 2, 4, 4);

            points.Add(new Point(e.X, e.Y));
        }

        private void Jarvis_March_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            

            Point[] hullPoints = JarvisMarch(points);


            for (int i = 0; i < hullPoints.Length - 1; i++)
            {
                Thread.Sleep(500);
                g.DrawLine(redPen, hullPoints[i].X, hullPoints[i].Y, hullPoints[i + 1].X, hullPoints[i + 1].Y);


            }
            Thread.Sleep(500);
            g.DrawLine(redPen, hullPoints[hullPoints.Length - 1].X, hullPoints[hullPoints.Length - 1].Y, hullPoints[0].X, hullPoints[0].Y);

        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {            
            points.Clear();
            Graphics g = this.CreateGraphics();

            g.Clear(Color.White);

            g.DrawLine(blackPen, 11, 374, 990, 374); // HORIZONTAL AXIS
            g.DrawLine(blackPen, 495, 0, 495, 758); // VERTICAL AXIS

        }

        private void Graham_Scan_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Point[] hullPoints  = GrahamScan.GrahamScanMethod(points.ToArray());
            

            for (int i = 0; i < hullPoints.Length - 1; i++)
            {
                Thread.Sleep(500);
                g.DrawLine(redPen, hullPoints[i].X, hullPoints[i].Y, hullPoints[i + 1].X, hullPoints[i + 1].Y);

            }
            Thread.Sleep(500);
            g.DrawLine(redPen, hullPoints[hullPoints.Length - 1].X, hullPoints[hullPoints.Length - 1].Y, hullPoints[0].X, hullPoints[0].Y);

        }
    }
}