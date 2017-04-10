namespace TestMotor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private RobotView.DriveCtrlView driveCtrlView1;
        private RobotView.MotorCtrlView motorCtrlView1;
        private RobotView.MotorCtrlView motorCtrlView2;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.driveCtrlView1 = new RobotView.DriveCtrlView();
            this.motorCtrlView1 = new RobotView.MotorCtrlView();
            this.motorCtrlView2 = new RobotView.MotorCtrlView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // driveCtrlView1
            // 
            this.driveCtrlView1.DriveCtrl = null;
            this.driveCtrlView1.Location = new System.Drawing.Point(122, 14);
            this.driveCtrlView1.Name = "driveCtrlView1";
            this.driveCtrlView1.Size = new System.Drawing.Size(274, 57);
            this.driveCtrlView1.TabIndex = 0;
            // 
            // motorCtrlView1
            // 
            this.motorCtrlView1.Location = new System.Drawing.Point(12, 14);
            this.motorCtrlView1.MotorCtrl = null;
            this.motorCtrlView1.Name = "motorCtrlView1";
            this.motorCtrlView1.Size = new System.Drawing.Size(431, 258);
            this.motorCtrlView1.TabIndex = 1;
            // 
            // motorCtrlView2
            // 
            this.motorCtrlView2.Location = new System.Drawing.Point(12, 18);
            this.motorCtrlView2.MotorCtrl = null;
            this.motorCtrlView2.Name = "motorCtrlView2";
            this.motorCtrlView2.Size = new System.Drawing.Size(431, 258);
            this.motorCtrlView2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 320);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.motorCtrlView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(454, 291);
            this.tabPage1.Text = "Motor links";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.motorCtrlView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(454, 291);
            this.tabPage2.Text = "Motor rechts";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(503, 409);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.driveCtrlView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

