namespace WPFFINDLE_BAS
{
    partial class SetUserLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUserLocation));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMylocation = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMILogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetLocation = new System.Windows.Forms.Button();
            this.LocationPicture = new System.Windows.Forms.PictureBox();
            this.lblRooms = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.ListBox();
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(359, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMMenu
            // 
            this.TSMMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMISearch,
            this.TSMIMylocation,
            this.TSMILogout});
            this.TSMMenu.Name = "TSMMenu";
            this.TSMMenu.Size = new System.Drawing.Size(60, 24);
            this.TSMMenu.Text = "Menu";
            // 
            // TSMISearch
            // 
            this.TSMISearch.Name = "TSMISearch";
            this.TSMISearch.Size = new System.Drawing.Size(170, 26);
            this.TSMISearch.Text = "Search";
            this.TSMISearch.Click += new System.EventHandler(this.TSMISearch_Click);
            // 
            // TSMIMylocation
            // 
            this.TSMIMylocation.Name = "TSMIMylocation";
            this.TSMIMylocation.Size = new System.Drawing.Size(170, 26);
            this.TSMIMylocation.Text = "My location";
            this.TSMIMylocation.Click += new System.EventHandler(this.TSMIMylocation_Click);
            // 
            // TSMILogout
            // 
            this.TSMILogout.Name = "TSMILogout";
            this.TSMILogout.Size = new System.Drawing.Size(170, 26);
            this.TSMILogout.Text = "Logout";
            this.TSMILogout.Click += new System.EventHandler(this.TSMILogout_Click);
            // 
            // btnSetLocation
            // 
            this.btnSetLocation.Location = new System.Drawing.Point(116, 481);
            this.btnSetLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetLocation.Name = "btnSetLocation";
            this.btnSetLocation.Size = new System.Drawing.Size(99, 30);
            this.btnSetLocation.TabIndex = 2;
            this.btnSetLocation.Text = "Set location";
            this.btnSetLocation.UseVisualStyleBackColor = true;
            this.btnSetLocation.Visible = false;
            this.btnSetLocation.Click += new System.EventHandler(this.btnSetLocation_Click);
            // 
            // LocationPicture
            // 
            this.LocationPicture.Location = new System.Drawing.Point(35, 223);
            this.LocationPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LocationPicture.Name = "LocationPicture";
            this.LocationPicture.Size = new System.Drawing.Size(280, 254);
            this.LocationPicture.TabIndex = 3;
            this.LocationPicture.TabStop = false;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Location = new System.Drawing.Point(31, 129);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(56, 17);
            this.lblRooms.TabIndex = 4;
            this.lblRooms.Text = "Rooms:";
            // 
            // lbLevel
            // 
            this.lbLevel.FormattingEnabled = true;
            this.lbLevel.ItemHeight = 16;
            this.lbLevel.Location = new System.Drawing.Point(35, 80);
            this.lbLevel.Margin = new System.Windows.Forms.Padding(4);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(280, 36);
            this.lbLevel.TabIndex = 6;
            this.lbLevel.TabStop = false;
            this.lbLevel.SelectedIndexChanged += new System.EventHandler(this.lbLevel_SelectedIndexChanged);
            // 
            // lbRooms
            // 
            this.lbRooms.FormattingEnabled = true;
            this.lbRooms.ItemHeight = 16;
            this.lbRooms.Location = new System.Drawing.Point(35, 149);
            this.lbRooms.Margin = new System.Windows.Forms.Padding(4);
            this.lbRooms.Name = "lbRooms";
            this.lbRooms.Size = new System.Drawing.Size(280, 68);
            this.lbRooms.TabIndex = 8;
            this.lbRooms.TabStop = false;
            this.lbRooms.SelectedIndexChanged += new System.EventHandler(this.lbRooms_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(31, 60);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(46, 17);
            this.lblLevel.TabIndex = 9;
            this.lblLevel.Text = "Level:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(31, 33);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 10;
            // 
            // SetUserLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 522);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lbRooms);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.lblRooms);
            this.Controls.Add(this.LocationPicture);
            this.Controls.Add(this.btnSetLocation);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "SetUserLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Findle - Set location";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMMenu;
        private System.Windows.Forms.ToolStripMenuItem TSMISearch;
        private System.Windows.Forms.ToolStripMenuItem TSMILogout;
        private System.Windows.Forms.Button btnSetLocation;
        private System.Windows.Forms.PictureBox LocationPicture;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.ListBox lbLevel;
        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ToolStripMenuItem TSMIMylocation;
        private System.Windows.Forms.Label lblMessage;
    }
}