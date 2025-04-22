namespace AlarmClock_desktop
{
    partial class Form1
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

        private void InitializeComponent()
        {
            lblInstruction = new Label();
            txtTargetTime = new TextBox();
            btnStart = new Button();
            lblCurrentTime = new Label();
            SuspendLayout();

            lblInstruction.AutoSize = true;
            lblInstruction.Location = new Point(16, 23);
            lblInstruction.Margin = new Padding(4, 0, 4, 0);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(216, 20);
            lblInstruction.TabIndex = 0;
            lblInstruction.Text = "Enter Target Time (HH:MM:SS): ";

            txtTargetTime.Location = new Point(259, 18);
            txtTargetTime.Margin = new Padding(4, 5, 4, 5);
            txtTargetTime.Name = "txtTargetTime";
            txtTargetTime.Size = new Size(132, 27);
            txtTargetTime.TabIndex = 1;

            btnStart.Location = new Point(400, 15);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 35);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;

            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentTime.Location = new Point(16, 77);
            lblCurrentTime.Margin = new Padding(4, 0, 4, 0);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(248, 29);
            lblCurrentTime.TabIndex = 3;
            lblCurrentTime.Text = "Current Time: --:--:--";
 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 171);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnStart);
            Controls.Add(txtTargetTime);
            Controls.Add(lblInstruction);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "D";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtTargetTime;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblCurrentTime;


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        #endregion
    }
}
