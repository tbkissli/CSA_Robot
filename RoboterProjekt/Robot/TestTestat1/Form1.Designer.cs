namespace TestTestat1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBreite = new System.Windows.Forms.TextBox();
            this.textBoxLänge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 264);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(94, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 69);
            this.label1.Text = "CSA Übungsblatt 7 - Testataufgabe\r\nRaphael Kissling && Pirmin Herger\r\n11. April 2" +
    "017\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxBreite
            // 
            this.textBoxBreite.Location = new System.Drawing.Point(154, 364);
            this.textBoxBreite.Name = "textBoxBreite";
            this.textBoxBreite.Size = new System.Drawing.Size(100, 23);
            this.textBoxBreite.TabIndex = 2;
            // 
            // textBoxLänge
            // 
            this.textBoxLänge.Location = new System.Drawing.Point(350, 364);
            this.textBoxLänge.Name = "textBoxLänge";
            this.textBoxLänge.Size = new System.Drawing.Size(100, 23);
            this.textBoxLänge.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(78, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.Text = "Breite:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(295, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.Text = "Länge:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(547, 427);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLänge);
            this.Controls.Add(this.textBoxBreite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBreite;
        private System.Windows.Forms.TextBox textBoxLänge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

