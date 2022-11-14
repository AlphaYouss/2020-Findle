namespace WPFFINDLE_BAS
{
    partial class DisplayUserlocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayUserlocation));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISetlocation = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMylocation = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMILogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pbRoom = new System.Windows.Forms.PictureBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnUnset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoom)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(357, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMMenu
            // 
            this.TSMMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMISearch,
            this.TSMISetlocation,
            this.TSMIMylocation,
            this.TSMILogout});
            this.TSMMenu.Name = "TSMMenu";
            this.TSMMenu.Size = new System.Drawing.Size(60, 24);
            this.TSMMenu.Text = "Menu";
            // 
            // TSMISearch
            // 
            this.TSMISearch.Name = "TSMISearch";
            this.TSMISearch.Size = new System.Drawing.Size(171, 26);
            this.TSMISearch.Text = "Search";
            this.TSMISearch.Click += new System.EventHandler(this.TSMISearch_Click);
            // 
            // TSMISetlocation
            // 
            this.TSMISetlocation.Name = "TSMISetlocation";
            this.TSMISetlocation.Size = new System.Drawing.Size(171, 26);
            this.TSMISetlocation.Text = "Set location";
            this.TSMISetlocation.Click += new System.EventHandler(this.TSMISetlocation_Click);
            // 
            // TSMIMylocation
            // 
            this.TSMIMylocation.Name = "TSMIMylocation";
            this.TSMIMylocation.Size = new System.Drawing.Size(171, 26);
            this.TSMIMylocation.Text = "My location";
            this.TSMIMylocation.Click += new System.EventHandler(this.TSMIMylocation_Click);
            // 
            // TSMILogout
            // 
            this.TSMILogout.Name = "TSMILogout";
            this.TSMILogout.Size = new System.Drawing.Size(171, 26);
            this.TSMILogout.Text = "Logout";
            this.TSMILogout.Click += new System.EventHandler(this.TSMILogout_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(21, 116);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(49, 17);
            this.lblRoom.TabIndex = 2;
            this.lblRoom.Text = "Room:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 79);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 17);
            this.lblDescription.TabIndex = 3;
            // 
            // pbRoom
            // 
            this.pbRoom.Location = new System.Drawing.Point(25, 134);
            this.pbRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbRoom.Name = "pbRoom";
            this.pbRoom.Size = new System.Drawing.Size(304, 283);
            this.pbRoom.TabIndex = 1;
            this.pbRoom.TabStop = false;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(25, 443);
            this.btnHide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(100, 28);
            this.btnHide.TabIndex = 4;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(25, 479);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 28);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(21, 41);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 6;
            // 
            // btnUnset
            // 
            this.btnUnset.Location = new System.Drawing.Point(229, 443);
            this.btnUnset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnset.Name = "btnUnset";
            this.btnUnset.Size = new System.Drawing.Size(100, 28);
            this.btnUnset.TabIndex = 7;
            this.btnUnset.Text = "Unset";
            this.btnUnset.UseVisualStyleBackColor = true;
            this.btnUnset.Click += new System.EventHandler(this.btnUnset_Click);
            // 
            // DisplayUserlocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 522);
            this.Controls.Add(this.btnUnset);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.pbRoom);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "DisplayUserlocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Findle - Location";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMMenu;
        private System.Windows.Forms.PictureBox pbRoom;
        private System.Windows.Forms.ToolStripMenuItem TSMILogout;
        private System.Windows.Forms.ToolStripMenuItem TSMISearch;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStripMenuItem TSMISetlocation;
        private System.Windows.Forms.ToolStripMenuItem TSMIMylocation;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnUnset;
    }
}