namespace TestDrive
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        private RobotView.DriveCtrlView driveCtrlView1;
        private RobotView.CommonRunParameters commonRunParameters1;
        private RobotView.RunLineView runLineView1;
        private RobotView.RunTurnView runTurnView1;
        private RobotView.RunArcView runArcView1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.driveCtrlView1 = new RobotView.DriveCtrlView();
            this.commonRunParameters1 = new RobotView.CommonRunParameters();
            this.runLineView1 = new RobotView.RunLineView();
            this.runTurnView1 = new RobotView.RunTurnView();
            this.runArcView1 = new RobotView.RunArcView();
            this.SuspendLayout();
            // 
            // driveCtrlView1
            // 
            this.driveCtrlView1.DriveCtrl = null;
            this.driveCtrlView1.Location = new System.Drawing.Point(-2, 3);
            this.driveCtrlView1.Name = "driveCtrlView1";
            this.driveCtrlView1.Size = new System.Drawing.Size(274, 57);
            this.driveCtrlView1.TabIndex = 0;
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Acceleration = 0.3F;
            this.commonRunParameters1.Location = new System.Drawing.Point(278, 3);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(360, 84);
            this.commonRunParameters1.Speed = 0.5F;
            this.commonRunParameters1.TabIndex = 1;
            // 
            // runLineView1
            // 
            this.runLineView1.Acceleration = 0F;
            this.runLineView1.Drive = null;
            this.runLineView1.Location = new System.Drawing.Point(10, 93);
            this.runLineView1.Name = "runLineView1";
            this.runLineView1.Size = new System.Drawing.Size(340, 48);
            this.runLineView1.Speed = 0F;
            this.runLineView1.TabIndex = 2;
            // 
            // runTurnView1
            // 
            this.runTurnView1.Acceleration = 0F;
            this.runTurnView1.Drive = null;
            this.runTurnView1.Location = new System.Drawing.Point(10, 159);
            this.runTurnView1.Name = "runTurnView1";
            this.runTurnView1.Size = new System.Drawing.Size(335, 48);
            this.runTurnView1.Speed = 0F;
            this.runTurnView1.TabIndex = 3;
            // 
            // runArcView1
            // 
            this.runArcView1.Acceleration = 0F;
            this.runArcView1.Drive = null;
            this.runArcView1.Location = new System.Drawing.Point(10, 212);
            this.runArcView1.Name = "runArcView1";
            this.runArcView1.Size = new System.Drawing.Size(454, 111);
            this.runArcView1.Speed = 0F;
            this.runArcView1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(654, 327);
            this.Controls.Add(this.driveCtrlView1);
            this.Controls.Add(this.commonRunParameters1);
            this.Controls.Add(this.runLineView1);
            this.Controls.Add(this.runTurnView1);
            this.Controls.Add(this.runArcView1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

