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
            this.label1 = new System.Windows.Forms.Label();
            this.scalingFactorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.coordNumApplyButton = new System.Windows.Forms.Button();
            this.coordNumTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter scale of Graph";
            // 
            // scalingFactorTextBox
            // 
            this.scalingFactorTextBox.Location = new System.Drawing.Point(12, 32);
            this.scalingFactorTextBox.Name = "scalingFactorTextBox";
            this.scalingFactorTextBox.Size = new System.Drawing.Size(125, 27);
            this.scalingFactorTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter number of coordinates";
            // 
            // coordNumApplyButton
            // 
            this.coordNumApplyButton.Location = new System.Drawing.Point(143, 101);
            this.coordNumApplyButton.Name = "coordNumApplyButton";
            this.coordNumApplyButton.Size = new System.Drawing.Size(94, 27);
            this.coordNumApplyButton.TabIndex = 3;
            this.coordNumApplyButton.Text = "Apply";
            this.coordNumApplyButton.UseVisualStyleBackColor = true;
            this.coordNumApplyButton.Click += new System.EventHandler(this.coordNumApplyButton_Click);
            // 
            // coordNumTextBox
            // 
            this.coordNumTextBox.Location = new System.Drawing.Point(12, 101);
            this.coordNumTextBox.Name = "coordNumTextBox";
            this.coordNumTextBox.Size = new System.Drawing.Size(125, 27);
            this.coordNumTextBox.TabIndex = 2;
            // 
            // Values
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(267, 551);
            this.Controls.Add(this.coordNumTextBox);
            this.Controls.Add(this.coordNumApplyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scalingFactorTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Values";
            this.Text = "Values";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox scalingFactorTextBox;
        private Label label2;
        private Button coordNumApplyButton;
        private TextBox coordNumTextBox;
    }
}