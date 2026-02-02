namespace Binary
{
	partial class IntroUI
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroUI));
            this.IntroToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LabelBinary = new System.Windows.Forms.Label();
            this.PictureBoxUpdates = new System.Windows.Forms.PictureBox();
            this.PictureBoxTools = new System.Windows.Forms.PictureBox();
            this.PictureBoxTheme = new System.Windows.Forms.PictureBox();
            this.ToolsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packList = new System.Windows.Forms.ListBox();
            this.createNewButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gameDirPath = new System.Windows.Forms.TextBox();
            this.gameDirLabel = new System.Windows.Forms.Label();
            this.gameDirOpenButton = new System.Windows.Forms.Button();
            this.gameTypePicker = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxUpdates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTools).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTheme).BeginInit();
            this.ToolsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelBinary
            // 
            this.LabelBinary.AutoSize = true;
            this.LabelBinary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelBinary.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelBinary.Location = new System.Drawing.Point(84, 16);
            this.LabelBinary.Name = "LabelBinary";
            this.LabelBinary.Size = new System.Drawing.Size(327, 54);
            this.LabelBinary.TabIndex = 2;
            this.LabelBinary.Text = "TexWizard Packer";
            this.LabelBinary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBinary.Click += this.LabelBinary_Click;
            // 
            // PictureBoxUpdates
            // 
            this.PictureBoxUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxUpdates.Location = new System.Drawing.Point(16, 11);
            this.PictureBoxUpdates.Name = "PictureBoxUpdates";
            this.PictureBoxUpdates.Size = new System.Drawing.Size(64, 64);
            this.PictureBoxUpdates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxUpdates.TabIndex = 3;
            this.PictureBoxUpdates.TabStop = false;
            this.PictureBoxUpdates.Click += this.PictureBoxUpdates_Click;
            // 
            // PictureBoxTools
            // 
            this.PictureBoxTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxTools.Location = new System.Drawing.Point(492, 11);
            this.PictureBoxTools.Name = "PictureBoxTools";
            this.PictureBoxTools.Size = new System.Drawing.Size(64, 64);
            this.PictureBoxTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxTools.TabIndex = 3;
            this.PictureBoxTools.TabStop = false;
            this.PictureBoxTools.Click += this.PictureBoxTools_Click;
            // 
            // PictureBoxTheme
            // 
            this.PictureBoxTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxTheme.Location = new System.Drawing.Point(562, 11);
            this.PictureBoxTheme.Name = "PictureBoxTheme";
            this.PictureBoxTheme.Size = new System.Drawing.Size(64, 64);
            this.PictureBoxTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxTheme.TabIndex = 3;
            this.PictureBoxTheme.TabStop = false;
            this.PictureBoxTheme.Click += this.PictureBoxTheme_Click;
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.newLauncherToolStripMenuItem, this.hasherToolStripMenuItem, this.raiderToolStripMenuItem, this.swatcherToolStripMenuItem, this.settingsToolStripMenuItem });
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolsMenu.Size = new System.Drawing.Size(203, 114);
            // 
            // newLauncherToolStripMenuItem
            // 
            this.newLauncherToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newLauncherToolStripMenuItem.Name = "newLauncherToolStripMenuItem";
            this.newLauncherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            this.newLauncherToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.newLauncherToolStripMenuItem.Text = "New Launcher...";
            this.newLauncherToolStripMenuItem.Click += this.newLauncherToolStripMenuItem_Click;
            // 
            // hasherToolStripMenuItem
            // 
            this.hasherToolStripMenuItem.Name = "hasherToolStripMenuItem";
            this.hasherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H;
            this.hasherToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hasherToolStripMenuItem.Text = "Hasher...";
            this.hasherToolStripMenuItem.Click += this.hasherToolStripMenuItem_Click;
            // 
            // raiderToolStripMenuItem
            // 
            this.raiderToolStripMenuItem.Name = "raiderToolStripMenuItem";
            this.raiderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R;
            this.raiderToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.raiderToolStripMenuItem.Text = "Raider...";
            this.raiderToolStripMenuItem.Click += this.raiderToolStripMenuItem_Click;
            // 
            // swatcherToolStripMenuItem
            // 
            this.swatcherToolStripMenuItem.Name = "swatcherToolStripMenuItem";
            this.swatcherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S;
            this.swatcherToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.swatcherToolStripMenuItem.Text = "Swatcher...";
            this.swatcherToolStripMenuItem.Click += this.swatcherToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += this.settingsToolStripMenuItem_Click;
            // 
            // packList
            // 
            this.packList.Enabled = false;
            this.packList.FormattingEnabled = true;
            this.packList.ItemHeight = 15;
            this.packList.Location = new System.Drawing.Point(16, 126);
            this.packList.Name = "packList";
            this.packList.Size = new System.Drawing.Size(610, 394);
            this.packList.TabIndex = 4;
            this.packList.SelectedIndexChanged += this.packList_SelectedIndexChanged;
            // 
            // createNewButton
            // 
            this.createNewButton.Enabled = false;
            this.createNewButton.Location = new System.Drawing.Point(16, 528);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(127, 27);
            this.createNewButton.TabIndex = 5;
            this.createNewButton.Text = "Create New Pack...";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += this.createNewButton_Click;
            // 
            // openButton
            // 
            this.openButton.Enabled = false;
            this.openButton.Location = new System.Drawing.Point(492, 528);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(134, 27);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open Pack";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += this.openButton_Click;
            // 
            // gameDirPath
            // 
            this.gameDirPath.Location = new System.Drawing.Point(241, 89);
            this.gameDirPath.Name = "gameDirPath";
            this.gameDirPath.Size = new System.Drawing.Size(304, 23);
            this.gameDirPath.TabIndex = 8;
            this.gameDirPath.TextChanged += this.GameDirPath_TextChanged;
            // 
            // gameDirLabel
            // 
            this.gameDirLabel.AutoSize = true;
            this.gameDirLabel.Location = new System.Drawing.Point(16, 92);
            this.gameDirLabel.Name = "gameDirLabel";
            this.gameDirLabel.Size = new System.Drawing.Size(92, 15);
            this.gameDirLabel.TabIndex = 9;
            this.gameDirLabel.Text = "Game Directory:";
            // 
            // gameDirOpenButton
            // 
            this.gameDirOpenButton.Location = new System.Drawing.Point(551, 87);
            this.gameDirOpenButton.Name = "gameDirOpenButton";
            this.gameDirOpenButton.Size = new System.Drawing.Size(75, 27);
            this.gameDirOpenButton.TabIndex = 10;
            this.gameDirOpenButton.Text = "Open...";
            this.gameDirOpenButton.UseVisualStyleBackColor = true;
            this.gameDirOpenButton.Click += this.gameDirOpenButton_Click;
            // 
            // gameTypePicker
            // 
            this.gameTypePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameTypePicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameTypePicker.FormattingEnabled = true;
            this.gameTypePicker.Items.AddRange(new object[] { "Carbon", "MostWanted", "Prostreet", "Undercover", "Underground1", "Underground2" });
            this.gameTypePicker.Location = new System.Drawing.Point(114, 89);
            this.gameTypePicker.Name = "gameTypePicker";
            this.gameTypePicker.Size = new System.Drawing.Size(121, 23);
            this.gameTypePicker.TabIndex = 11;
            this.gameTypePicker.SelectedIndexChanged += this.gameTypePicker_SelectedIndexChanged;
            // 
            // IntroUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 567);
            this.Controls.Add(this.gameTypePicker);
            this.Controls.Add(this.gameDirOpenButton);
            this.Controls.Add(this.gameDirLabel);
            this.Controls.Add(this.gameDirPath);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.packList);
            this.Controls.Add(this.PictureBoxTools);
            this.Controls.Add(this.PictureBoxTheme);
            this.Controls.Add(this.PictureBoxUpdates);
            this.Controls.Add(this.LabelBinary);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "IntroUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TexWizard Packer";
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxUpdates).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTools).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTheme).EndInit();
            this.ToolsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip IntroToolTip;
		private System.Windows.Forms.Label LabelBinary;
		private System.Windows.Forms.PictureBox PictureBoxUpdates;
		private System.Windows.Forms.PictureBox PictureBoxTools;
		private System.Windows.Forms.PictureBox PictureBoxTheme;
        private System.Windows.Forms.ContextMenuStrip ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem newLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raiderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ListBox packList;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox gameDirPath;
        private System.Windows.Forms.Label gameDirLabel;
        private System.Windows.Forms.Button gameDirOpenButton;
        private System.Windows.Forms.ComboBox gameTypePicker;
    }
}
