namespace ItinerarySampleApp
{
    partial class MainForm
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
        /// 
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.PostCalendarButton = new System.Windows.Forms.Button();
			this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.StartDateLabel = new System.Windows.Forms.Label();
			this.EndDateLabel = new System.Windows.Forms.Label();
			this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.TripNameLabel = new System.Windows.Forms.Label();
			this.TripNameTextBox = new System.Windows.Forms.TextBox();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateItinButton = new System.Windows.Forms.Button();
			this.TripListView = new System.Windows.Forms.ListView();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.CreateItinGroupBox = new System.Windows.Forms.GroupBox();
			this.ListViewGroupBox = new System.Windows.Forms.GroupBox();
			this.PostItinFromCalendarButton = new System.Windows.Forms.Button();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.MenuStrip.SuspendLayout();
			this.CreateItinGroupBox.SuspendLayout();
			this.ListViewGroupBox.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PostCalendarButton
			// 
			this.PostCalendarButton.Location = new System.Drawing.Point(468, 205);
			this.PostCalendarButton.Name = "PostCalendarButton";
			this.PostCalendarButton.Size = new System.Drawing.Size(93, 23);
			this.PostCalendarButton.TabIndex = 0;
			this.PostCalendarButton.Text = "Post to Calendar";
			this.PostCalendarButton.UseVisualStyleBackColor = true;
			this.PostCalendarButton.Click += new System.EventHandler(this.PostCalendarButton_Click);
			// 
			// StartDateTimePicker
			// 
			this.StartDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartDateTimePicker.Location = new System.Drawing.Point(36, 47);
			this.StartDateTimePicker.MinDate = new System.DateTime(2013, 9, 26, 0, 0, 0, 0);
			this.StartDateTimePicker.Name = "StartDateTimePicker";
			this.StartDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.StartDateTimePicker.TabIndex = 4;
			this.StartDateTimePicker.Value = new System.DateTime(2013, 9, 26, 0, 0, 0, 0);
			// 
			// StartDateLabel
			// 
			this.StartDateLabel.AutoSize = true;
			this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartDateLabel.Location = new System.Drawing.Point(15, 29);
			this.StartDateLabel.Name = "StartDateLabel";
			this.StartDateLabel.Size = new System.Drawing.Size(64, 15);
			this.StartDateLabel.TabIndex = 5;
			this.StartDateLabel.Text = "Start Date:";
			// 
			// EndDateLabel
			// 
			this.EndDateLabel.AutoSize = true;
			this.EndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EndDateLabel.Location = new System.Drawing.Point(18, 70);
			this.EndDateLabel.Name = "EndDateLabel";
			this.EndDateLabel.Size = new System.Drawing.Size(61, 15);
			this.EndDateLabel.TabIndex = 6;
			this.EndDateLabel.Text = "End Date:";
			// 
			// EndDateTimePicker
			// 
			this.EndDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EndDateTimePicker.Location = new System.Drawing.Point(36, 88);
			this.EndDateTimePicker.MinDate = new System.DateTime(2013, 9, 26, 0, 0, 0, 0);
			this.EndDateTimePicker.Name = "EndDateTimePicker";
			this.EndDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.EndDateTimePicker.TabIndex = 7;
			this.EndDateTimePicker.Value = new System.DateTime(2013, 9, 26, 0, 0, 0, 0);
			// 
			// TripNameLabel
			// 
			this.TripNameLabel.AutoSize = true;
			this.TripNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TripNameLabel.Location = new System.Drawing.Point(11, 111);
			this.TripNameLabel.Name = "TripNameLabel";
			this.TripNameLabel.Size = new System.Drawing.Size(68, 15);
			this.TripNameLabel.TabIndex = 10;
			this.TripNameLabel.Text = "Trip Name:";
			// 
			// TripNameTextBox
			// 
			this.TripNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TripNameTextBox.Location = new System.Drawing.Point(36, 129);
			this.TripNameTextBox.Name = "TripNameTextBox";
			this.TripNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.TripNameTextBox.TabIndex = 11;
			// 
			// MenuStrip
			// 
			this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(594, 24);
			this.MenuStrip.TabIndex = 12;
			this.MenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// CreateItinButton
			// 
			this.CreateItinButton.Location = new System.Drawing.Point(346, 205);
			this.CreateItinButton.Name = "CreateItinButton";
			this.CreateItinButton.Size = new System.Drawing.Size(93, 23);
			this.CreateItinButton.TabIndex = 14;
			this.CreateItinButton.Text = "Create Itinerary";
			this.CreateItinButton.UseVisualStyleBackColor = true;
			this.CreateItinButton.Click += new System.EventHandler(this.CreateItinButton_Click);
			// 
			// TripListView
			// 
			this.TripListView.CheckBoxes = true;
			this.TripListView.LargeImageList = this.ImageList;
			this.TripListView.Location = new System.Drawing.Point(8, 19);
			this.TripListView.Name = "TripListView";
			this.TripListView.Size = new System.Drawing.Size(280, 200);
			this.TripListView.TabIndex = 15;
			this.TripListView.UseCompatibleStateImageBehavior = false;
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName(0, "plane.png");
			// 
			// CreateItinGroupBox
			// 
			this.CreateItinGroupBox.Controls.Add(this.StartDateLabel);
			this.CreateItinGroupBox.Controls.Add(this.StartDateTimePicker);
			this.CreateItinGroupBox.Controls.Add(this.EndDateLabel);
			this.CreateItinGroupBox.Controls.Add(this.EndDateTimePicker);
			this.CreateItinGroupBox.Controls.Add(this.TripNameTextBox);
			this.CreateItinGroupBox.Controls.Add(this.TripNameLabel);
			this.CreateItinGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreateItinGroupBox.Location = new System.Drawing.Point(325, 38);
			this.CreateItinGroupBox.Name = "CreateItinGroupBox";
			this.CreateItinGroupBox.Size = new System.Drawing.Size(258, 161);
			this.CreateItinGroupBox.TabIndex = 16;
			this.CreateItinGroupBox.TabStop = false;
			this.CreateItinGroupBox.Text = "Create Itinerary";
			// 
			// ListViewGroupBox
			// 
			this.ListViewGroupBox.Controls.Add(this.TripListView);
			this.ListViewGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ListViewGroupBox.Location = new System.Drawing.Point(12, 38);
			this.ListViewGroupBox.Name = "ListViewGroupBox";
			this.ListViewGroupBox.Size = new System.Drawing.Size(299, 227);
			this.ListViewGroupBox.TabIndex = 17;
			this.ListViewGroupBox.TabStop = false;
			this.ListViewGroupBox.Text = "Itineraries";
			// 
			// PostItinFromCalendarButton
			// 
			this.PostItinFromCalendarButton.Location = new System.Drawing.Point(372, 242);
			this.PostItinFromCalendarButton.Name = "PostItinFromCalendarButton";
			this.PostItinFromCalendarButton.Size = new System.Drawing.Size(174, 23);
			this.PostItinFromCalendarButton.TabIndex = 19;
			this.PostItinFromCalendarButton.Text = "Create Itineraries From Calendar";
			this.PostItinFromCalendarButton.UseVisualStyleBackColor = true;
			this.PostItinFromCalendarButton.Click += new System.EventHandler(this.PostItinFromCalendarButton_Click);
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 275);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(594, 22);
			this.StatusStrip.SizingGrip = false;
			this.StatusStrip.TabIndex = 18;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 297);
			this.Controls.Add(this.PostItinFromCalendarButton);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ListViewGroupBox);
			this.Controls.Add(this.CreateItinGroupBox);
			this.Controls.Add(this.CreateItinButton);
			this.Controls.Add(this.PostCalendarButton);
			this.Controls.Add(this.MenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.MenuStrip;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Itinerary Sample App";
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.CreateItinGroupBox.ResumeLayout(false);
			this.CreateItinGroupBox.PerformLayout();
			this.ListViewGroupBox.ResumeLayout(false);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PostCalendarButton;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label TripNameLabel;
        private System.Windows.Forms.TextBox TripNameTextBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button CreateItinButton;
        private System.Windows.Forms.ListView TripListView;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.GroupBox CreateItinGroupBox;
		private System.Windows.Forms.GroupBox ListViewGroupBox;
        private System.Windows.Forms.Button PostItinFromCalendarButton;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.StatusStrip StatusStrip;

    }
}

