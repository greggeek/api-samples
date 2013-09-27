namespace QuickExpenseSample
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TreeView = new System.Windows.Forms.TreeView();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ViewGroupBox = new System.Windows.Forms.GroupBox();
			this.ViewReceiptLinkLabel = new System.Windows.Forms.LinkLabel();
			this.ItemsPlace = new System.Windows.Forms.TextBox();
			this.ItemsLabel = new System.Windows.Forms.Label();
			this.OrderNumberPlace = new System.Windows.Forms.TextBox();
			this.AmountPlace = new System.Windows.Forms.TextBox();
			this.OrderNumberLabel = new System.Windows.Forms.Label();
			this.AmountLabel = new System.Windows.Forms.Label();
			this.DatePlace = new System.Windows.Forms.TextBox();
			this.DateLabel = new System.Windows.Forms.Label();
			this.CreatedLabel = new System.Windows.Forms.Label();
			this.MenuStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.ViewGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(523, 24);
			this.MenuStrip.TabIndex = 7;
			this.MenuStrip.Text = "Menu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// TreeView
			// 
			this.TreeView.ImageIndex = 0;
			this.TreeView.ImageList = this.ImageList;
			this.TreeView.Location = new System.Drawing.Point(12, 37);
			this.TreeView.Name = "TreeView";
			this.TreeView.SelectedImageIndex = 0;
			this.TreeView.Size = new System.Drawing.Size(289, 249);
			this.TreeView.TabIndex = 8;
			this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName(0, "concur.png");
			this.ImageList.Images.SetKeyName(1, "product.png");
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 296);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(523, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 9;
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// ViewGroupBox
			// 
			this.ViewGroupBox.Controls.Add(this.ViewReceiptLinkLabel);
			this.ViewGroupBox.Controls.Add(this.ItemsPlace);
			this.ViewGroupBox.Controls.Add(this.ItemsLabel);
			this.ViewGroupBox.Controls.Add(this.OrderNumberPlace);
			this.ViewGroupBox.Controls.Add(this.AmountPlace);
			this.ViewGroupBox.Controls.Add(this.OrderNumberLabel);
			this.ViewGroupBox.Controls.Add(this.AmountLabel);
			this.ViewGroupBox.Controls.Add(this.DatePlace);
			this.ViewGroupBox.Controls.Add(this.DateLabel);
			this.ViewGroupBox.Location = new System.Drawing.Point(322, 56);
			this.ViewGroupBox.Name = "ViewGroupBox";
			this.ViewGroupBox.Size = new System.Drawing.Size(189, 230);
			this.ViewGroupBox.TabIndex = 10;
			this.ViewGroupBox.TabStop = false;
			this.ViewGroupBox.Text = "Quick Expense";
			// 
			// ViewReceiptLinkLabel
			// 
			this.ViewReceiptLinkLabel.AutoSize = true;
			this.ViewReceiptLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ViewReceiptLinkLabel.Location = new System.Drawing.Point(6, 200);
			this.ViewReceiptLinkLabel.Name = "ViewReceiptLinkLabel";
			this.ViewReceiptLinkLabel.Size = new System.Drawing.Size(90, 15);
			this.ViewReceiptLinkLabel.TabIndex = 15;
			this.ViewReceiptLinkLabel.TabStop = true;
			this.ViewReceiptLinkLabel.Text = "View Receipt";
			this.ViewReceiptLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewReceiptLinkLabel_LinkClicked);
			// 
			// ItemsPlace
			// 
			this.ItemsPlace.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ItemsPlace.Location = new System.Drawing.Point(9, 169);
			this.ItemsPlace.Name = "ItemsPlace";
			this.ItemsPlace.ReadOnly = true;
			this.ItemsPlace.Size = new System.Drawing.Size(174, 20);
			this.ItemsPlace.TabIndex = 14;
			// 
			// ItemsLabel
			// 
			this.ItemsLabel.AutoSize = true;
			this.ItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ItemsLabel.Location = new System.Drawing.Point(6, 153);
			this.ItemsLabel.Name = "ItemsLabel";
			this.ItemsLabel.Size = new System.Drawing.Size(74, 13);
			this.ItemsLabel.TabIndex = 13;
			this.ItemsLabel.Text = "Total Items:";
			// 
			// OrderNumberPlace
			// 
			this.OrderNumberPlace.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.OrderNumberPlace.Location = new System.Drawing.Point(9, 124);
			this.OrderNumberPlace.Name = "OrderNumberPlace";
			this.OrderNumberPlace.ReadOnly = true;
			this.OrderNumberPlace.Size = new System.Drawing.Size(174, 20);
			this.OrderNumberPlace.TabIndex = 12;
			// 
			// AmountPlace
			// 
			this.AmountPlace.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.AmountPlace.Location = new System.Drawing.Point(9, 80);
			this.AmountPlace.Name = "AmountPlace";
			this.AmountPlace.ReadOnly = true;
			this.AmountPlace.Size = new System.Drawing.Size(174, 20);
			this.AmountPlace.TabIndex = 9;
			// 
			// OrderNumberLabel
			// 
			this.OrderNumberLabel.AutoSize = true;
			this.OrderNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OrderNumberLabel.Location = new System.Drawing.Point(6, 108);
			this.OrderNumberLabel.Name = "OrderNumberLabel";
			this.OrderNumberLabel.Size = new System.Drawing.Size(89, 13);
			this.OrderNumberLabel.TabIndex = 11;
			this.OrderNumberLabel.Text = "Order Number:";
			// 
			// AmountLabel
			// 
			this.AmountLabel.AutoSize = true;
			this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmountLabel.Location = new System.Drawing.Point(6, 64);
			this.AmountLabel.Name = "AmountLabel";
			this.AmountLabel.Size = new System.Drawing.Size(53, 13);
			this.AmountLabel.TabIndex = 8;
			this.AmountLabel.Text = "Amount:";
			// 
			// DatePlace
			// 
			this.DatePlace.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.DatePlace.Location = new System.Drawing.Point(9, 36);
			this.DatePlace.Name = "DatePlace";
			this.DatePlace.ReadOnly = true;
			this.DatePlace.Size = new System.Drawing.Size(174, 20);
			this.DatePlace.TabIndex = 5;
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DateLabel.Location = new System.Drawing.Point(6, 20);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(38, 13);
			this.DateLabel.TabIndex = 4;
			this.DateLabel.Text = "Date:";
			// 
			// CreatedLabel
			// 
			this.CreatedLabel.AutoSize = true;
			this.CreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreatedLabel.ForeColor = System.Drawing.Color.Teal;
			this.CreatedLabel.Location = new System.Drawing.Point(328, 34);
			this.CreatedLabel.Name = "CreatedLabel";
			this.CreatedLabel.Size = new System.Drawing.Size(0, 16);
			this.CreatedLabel.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(523, 318);
			this.Controls.Add(this.CreatedLabel);
			this.Controls.Add(this.ViewGroupBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.TreeView);
			this.Controls.Add(this.MenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.MenuStrip;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Quick Expense Sample App";
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ViewGroupBox.ResumeLayout(false);
			this.ViewGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TreeView TreeView;
		private System.Windows.Forms.ImageList ImageList;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.GroupBox ViewGroupBox;
		private System.Windows.Forms.TextBox DatePlace;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.TextBox AmountPlace;
		private System.Windows.Forms.Label AmountLabel;
		private System.Windows.Forms.TextBox OrderNumberPlace;
		private System.Windows.Forms.Label OrderNumberLabel;
		private System.Windows.Forms.TextBox ItemsPlace;
		private System.Windows.Forms.Label ItemsLabel;
		private System.Windows.Forms.Label CreatedLabel;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.LinkLabel ViewReceiptLinkLabel;
	}
}

