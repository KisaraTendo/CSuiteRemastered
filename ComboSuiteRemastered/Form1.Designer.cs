namespace ComboSuiteRemastered
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.MinimizeBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.TitleLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.MenuBarPanel = new System.Windows.Forms.Panel();
            this.ExtractTab = new Bunifu.Framework.UI.BunifuImageButton();
            this.MergeTab = new Bunifu.Framework.UI.BunifuImageButton();
            this.SplitTab = new Bunifu.Framework.UI.BunifuImageButton();
            this.DuplicatesTab = new Bunifu.Framework.UI.BunifuImageButton();
            this.MenuBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MiscTab = new Bunifu.Framework.UI.BunifuImageButton();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBtn)).BeginInit();
            this.MenuBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtractTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MergeTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicatesTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscTab)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.TitlePanel.Controls.Add(this.CloseBtn);
            this.TitlePanel.Controls.Add(this.MinimizeBtn);
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(800, 32);
            this.TitlePanel.TabIndex = 0;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.ImageActive = null;
            this.CloseBtn.Location = new System.Drawing.Point(765, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(32, 32);
            this.CloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.Zoom = 5;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBtn.Image")));
            this.MinimizeBtn.ImageActive = null;
            this.MinimizeBtn.Location = new System.Drawing.Point(730, 0);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(32, 32);
            this.MinimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MinimizeBtn.TabIndex = 1;
            this.MinimizeBtn.TabStop = false;
            this.MinimizeBtn.Zoom = 0;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TitleLabel.Location = new System.Drawing.Point(3, 4);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(311, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "ComboSuite Remastered [By Kisara]";
            // 
            // MenuBarPanel
            // 
            this.MenuBarPanel.BackColor = System.Drawing.Color.Black;
            this.MenuBarPanel.Controls.Add(this.MiscTab);
            this.MenuBarPanel.Controls.Add(this.ExtractTab);
            this.MenuBarPanel.Controls.Add(this.MergeTab);
            this.MenuBarPanel.Controls.Add(this.SplitTab);
            this.MenuBarPanel.Controls.Add(this.DuplicatesTab);
            this.MenuBarPanel.Controls.Add(this.MenuBtn);
            this.MenuBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuBarPanel.Location = new System.Drawing.Point(0, 32);
            this.MenuBarPanel.Name = "MenuBarPanel";
            this.MenuBarPanel.Size = new System.Drawing.Size(41, 458);
            this.MenuBarPanel.TabIndex = 1;
            // 
            // ExtractTab
            // 
            this.ExtractTab.Image = ((System.Drawing.Image)(resources.GetObject("ExtractTab.Image")));
            this.ExtractTab.ImageActive = null;
            this.ExtractTab.Location = new System.Drawing.Point(3, 112);
            this.ExtractTab.Name = "ExtractTab";
            this.ExtractTab.Size = new System.Drawing.Size(32, 32);
            this.ExtractTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ExtractTab.TabIndex = 5;
            this.ExtractTab.TabStop = false;
            this.ExtractTab.Zoom = 10;
            this.ExtractTab.Click += new System.EventHandler(this.ExtractTab_Click);
            // 
            // MergeTab
            // 
            this.MergeTab.Image = ((System.Drawing.Image)(resources.GetObject("MergeTab.Image")));
            this.MergeTab.ImageActive = null;
            this.MergeTab.Location = new System.Drawing.Point(3, 215);
            this.MergeTab.Name = "MergeTab";
            this.MergeTab.Size = new System.Drawing.Size(32, 32);
            this.MergeTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MergeTab.TabIndex = 4;
            this.MergeTab.TabStop = false;
            this.MergeTab.Zoom = 10;
            this.MergeTab.Click += new System.EventHandler(this.MergeTab_Click);
            // 
            // SplitTab
            // 
            this.SplitTab.Image = ((System.Drawing.Image)(resources.GetObject("SplitTab.Image")));
            this.SplitTab.ImageActive = null;
            this.SplitTab.Location = new System.Drawing.Point(3, 162);
            this.SplitTab.Name = "SplitTab";
            this.SplitTab.Size = new System.Drawing.Size(32, 32);
            this.SplitTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SplitTab.TabIndex = 3;
            this.SplitTab.TabStop = false;
            this.SplitTab.Zoom = 10;
            this.SplitTab.Click += new System.EventHandler(this.SplitTab_Click);
            // 
            // DuplicatesTab
            // 
            this.DuplicatesTab.Image = ((System.Drawing.Image)(resources.GetObject("DuplicatesTab.Image")));
            this.DuplicatesTab.ImageActive = null;
            this.DuplicatesTab.Location = new System.Drawing.Point(3, 64);
            this.DuplicatesTab.Name = "DuplicatesTab";
            this.DuplicatesTab.Size = new System.Drawing.Size(32, 32);
            this.DuplicatesTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DuplicatesTab.TabIndex = 1;
            this.DuplicatesTab.TabStop = false;
            this.DuplicatesTab.Zoom = 10;
            this.DuplicatesTab.Click += new System.EventHandler(this.DuplicatesTab_Click);
            // 
            // MenuBtn
            // 
            this.MenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("MenuBtn.Image")));
            this.MenuBtn.ImageActive = null;
            this.MenuBtn.Location = new System.Drawing.Point(1, 6);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(40, 33);
            this.MenuBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuBtn.TabIndex = 0;
            this.MenuBtn.TabStop = false;
            this.MenuBtn.Zoom = 10;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.TitlePanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(38, 32);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(762, 458);
            this.MainPanel.TabIndex = 2;
            // 
            // MiscTab
            // 
            this.MiscTab.Image = ((System.Drawing.Image)(resources.GetObject("MiscTab.Image")));
            this.MiscTab.ImageActive = null;
            this.MiscTab.Location = new System.Drawing.Point(3, 267);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(32, 32);
            this.MiscTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MiscTab.TabIndex = 6;
            this.MiscTab.TabStop = false;
            this.MiscTab.Zoom = 10;
            this.MiscTab.Click += new System.EventHandler(this.MiscTab_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuBarPanel);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBtn)).EndInit();
            this.MenuBarPanel.ResumeLayout(false);
            this.MenuBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtractTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MergeTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicatesTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel MenuBarPanel;
        private System.Windows.Forms.Panel TitlePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel TitleLabel;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton MergeTab;
        private Bunifu.Framework.UI.BunifuImageButton SplitTab;
        private Bunifu.Framework.UI.BunifuImageButton DuplicatesTab;
        private Bunifu.Framework.UI.BunifuImageButton ExtractTab;
        private System.Windows.Forms.Panel MainPanel;
        private Bunifu.Framework.UI.BunifuImageButton MinimizeBtn;
        private Bunifu.Framework.UI.BunifuImageButton CloseBtn;
        private Bunifu.Framework.UI.BunifuImageButton MenuBtn;
        private Bunifu.Framework.UI.BunifuImageButton MiscTab;
    }
}

