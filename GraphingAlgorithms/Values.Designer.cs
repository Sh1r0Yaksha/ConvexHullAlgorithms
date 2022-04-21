namespace GraphingAlgorithms
{
    partial class Values
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Values));
            this.Graham_Scan = new System.Windows.Forms.Button();
            this.Jarvis_March = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Graham_Scan
            // 
            this.Graham_Scan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Graham_Scan.Location = new System.Drawing.Point(888, 682);
            this.Graham_Scan.Name = "Graham_Scan";
            this.Graham_Scan.Size = new System.Drawing.Size(94, 29);
            this.Graham_Scan.TabIndex = 0;
            this.Graham_Scan.Text = "GS";
            this.Graham_Scan.UseVisualStyleBackColor = false;
            this.Graham_Scan.Click += new System.EventHandler(this.Graham_Scan_Click);
            // 
            // Jarvis_March
            // 
            this.Jarvis_March.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Jarvis_March.Location = new System.Drawing.Point(12, 682);
            this.Jarvis_March.Name = "Jarvis_March";
            this.Jarvis_March.Size = new System.Drawing.Size(94, 29);
            this.Jarvis_March.TabIndex = 1;
            this.Jarvis_March.Text = "JM";
            this.Jarvis_March.UseVisualStyleBackColor = false;
            this.Jarvis_March.Click += new System.EventHandler(this.Jarvis_March_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(888, 12);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(94, 29);
            this.Reset_Button.TabIndex = 2;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // Values
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(994, 723);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Jarvis_March);
            this.Controls.Add(this.Graham_Scan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Values";
            this.Text = "Convex Hull";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Values_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Values_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Graham_Scan;
        private Button Jarvis_March;
        private Button Reset_Button;
    }
}