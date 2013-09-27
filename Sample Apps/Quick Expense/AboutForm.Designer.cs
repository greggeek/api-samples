namespace QuickExpenseSample
{
	partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.TitleLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LinkLabel = new System.Windows.Forms.LinkLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Location = new System.Drawing.Point(99, 24);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(27, 13);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Title";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(99, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(209, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Copyright 2013 - Concur Technologies Inc.";
			// 
			// LinkLabel
			// 
			this.LinkLabel.AutoSize = true;
			this.LinkLabel.LinkVisited = true;
			this.LinkLabel.Location = new System.Drawing.Point(99, 77);
			this.LinkLabel.Name = "LinkLabel";
			this.LinkLabel.Size = new System.Drawing.Size(126, 13);
			this.LinkLabel.TabIndex = 3;
			this.LinkLabel.TabStop = true;
			this.LinkLabel.Text = "http://www.concur.com/";
			this.LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(22, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(53, 42);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(328, 116);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.LinkLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TitleLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AboutForm";
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel LinkLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}