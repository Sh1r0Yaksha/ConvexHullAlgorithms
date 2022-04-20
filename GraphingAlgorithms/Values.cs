namespace GraphingAlgorithms
{
    public partial class Values : Form
    {
        TextBox[] xTextBox;
        TextBox[] yTextBox;
        public static Point[] points;

        public static int scaleValue;

        public static int numOfCoordinates = new int();
        Button jarvisMarchButton = new Button();
        Button grahamScanButton = new Button();

        public Values()
        {
            InitializeComponent();
        }

        private void coordNumApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                numOfCoordinates = int.Parse(coordNumTextBox.Text);

                xTextBox = new TextBox[numOfCoordinates];
                yTextBox = new TextBox[numOfCoordinates];
                points = new Point[numOfCoordinates];

                int initialLabelYLocation = 152;
                int initialTextBoxYLocation = 175;

                for (int i = 0; i < numOfCoordinates; i++)
                {
                    Label labelX = new Label();
                    this.Controls.Add(labelX);
                    labelX.Text = $"X{i + 1}:";
                    labelX.Location = new Point(35, initialLabelYLocation + i * 53);

                    Label labelY = new Label();
                    this.Controls.Add(labelY);
                    labelY.Text = $"Y{i + 1}:";
                    labelY.TextAlign = ContentAlignment.TopRight;
                    labelY.Location = new Point(labelX.Location.X + 80, initialLabelYLocation + i * 53);

                    xTextBox[i] = new TextBox();
                    this.Controls.Add(xTextBox[i]);
                    xTextBox[i].Location = new Point(12, initialTextBoxYLocation + i * 53);
                    xTextBox[i].Size = new Size(80, 27);

                    yTextBox[i] = new TextBox(); 
                    this.Controls.Add(yTextBox[i]);
                    yTextBox[i].Location = new Point(xTextBox[i].Location.X + 152, xTextBox[i].Location.Y);
                    yTextBox[i].Size = new Size(80, 27);                 
                }

                this.Controls.Add(jarvisMarchButton);
                jarvisMarchButton.Location = new Point(xTextBox[numOfCoordinates - 1].Location.X, xTextBox[numOfCoordinates - 1].Location.Y + 53);
                jarvisMarchButton.Text = "JM";
                jarvisMarchButton.Size = new Size(80, 27);
                jarvisMarchButton.Click += JM_Click;

                grahamScanButton.Location = new Point(yTextBox[numOfCoordinates - 1].Location.X, yTextBox[numOfCoordinates - 1].Location.Y + 53);
                this.Controls.Add(grahamScanButton);
                grahamScanButton.Text = "GM";
                grahamScanButton.Size = new Size(80, 27);
                grahamScanButton.Click += GS_Click;

                scaleValue = int.Parse(scalingFactorTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void JM_Click(object sender, EventArgs e)
        {
            AddValues();
            JarvisMarch jm = new JarvisMarch();
            jm.ShowDialog();
        }

        private void GS_Click(object sender, EventArgs e)
        {
            AddValues();
            GrahamScan gs = new GrahamScan();
            gs.ShowDialog();
        }

        
        
         

        private void AddValues()
        {
            try
            {
                for (int i = 0; i < numOfCoordinates; i++)
                {
                    points[i] = new Point(int.Parse(xTextBox[i].Text), int.Parse(yTextBox[i].Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
            Values values = new Values();
            values.ShowDialog();          
        }
    }
}