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
            this.removeButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileButton = new System.Windows.Forms.Button();
            this.fileTreeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxUpdates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTools).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PictureBoxTheme).BeginInit();
            this.ToolsMenu.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.ToolsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.hasherToolStripMenuItem, this.raiderToolStripMenuItem, this.swatcherToolStripMenuItem, this.settingsToolStripMenuItem });
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolsMenu.Size = new System.Drawing.Size(168, 92);
            // 
            // hasherToolStripMenuItem
            // 
            this.hasherToolStripMenuItem.Name = "hasherToolStripMenuItem";
            this.hasherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H;
            this.hasherToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.hasherToolStripMenuItem.Text = "Hasher...";
            this.hasherToolStripMenuItem.Click += this.hasherToolStripMenuItem_Click;
            // 
            // raiderToolStripMenuItem
            // 
            this.raiderToolStripMenuItem.Name = "raiderToolStripMenuItem";
            this.raiderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R;
            this.raiderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.raiderToolStripMenuItem.Text = "Raider...";
            this.raiderToolStripMenuItem.Click += this.raiderToolStripMenuItem_Click;
            // 
            // swatcherToolStripMenuItem
            // 
            this.swatcherToolStripMenuItem.Name = "swatcherToolStripMenuItem";
            this.swatcherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S;
            this.swatcherToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.swatcherToolStripMenuItem.Text = "Swatcher...";
            this.swatcherToolStripMenuItem.Click += this.swatcherToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += this.settingsToolStripMenuItem_Click;
            // 
            // packList
            // 
            this.packList.Enabled = false;
            this.packList.FormattingEnabled = true;
            this.packList.ItemHeight = 15;
            this.packList.Location = new System.Drawing.Point(0, 0);
            this.packList.Name = "packList";
            this.packList.Size = new System.Drawing.Size(602, 364);
            this.packList.TabIndex = 4;
            this.packList.SelectedIndexChanged += this.packList_SelectedIndexChanged;
            this.packList.MouseDoubleClick += this.packList_MouseDoubleClick;
            // 
            // createNewButton
            // 
            this.createNewButton.Enabled = false;
            this.createNewButton.Location = new System.Drawing.Point(6, 368);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(127, 27);
            this.createNewButton.TabIndex = 5;
            this.createNewButton.Text = "Add / Create New...";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += this.createNewButton_Click;
            // 
            // openButton
            // 
            this.openButton.Enabled = false;
            this.openButton.Location = new System.Drawing.Point(462, 368);
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
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(265, 368);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 27);
            this.removeButton.TabIndex = 12;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += this.removeButton_Click;
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(151, 368);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(51, 27);
            this.upButton.TabIndex = 13;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += this.upButton_Click;
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(208, 368);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(51, 27);
            this.downButton.TabIndex = 14;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += this.downButton_Click;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Location = new System.Drawing.Point(16, 126);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(610, 429);
            this.tabs.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.packList);
            this.tabPage1.Controls.Add(this.createNewButton);
            this.tabPage1.Controls.Add(this.removeButton);
            this.tabPage1.Controls.Add(this.downButton);
            this.tabPage1.Controls.Add(this.upButton);
            this.tabPage1.Controls.Add(this.openButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Texture Packs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fileTreeView);
            this.tabPage2.Controls.Add(this.openFileButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFileButton
            // 
            this.openFileButton.Enabled = false;
            this.openFileButton.Location = new System.Drawing.Point(462, 368);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(134, 27);
            this.openFileButton.TabIndex = 7;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += this.openFileButton_Click;
            // 
            // fileTreeView
            // 
            this.fileTreeView.Location = new System.Drawing.Point(0, 0);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.Size = new System.Drawing.Size(602, 362);
            this.fileTreeView.TabIndex = 8;
            this.fileTreeView.AfterSelect += fileTreeView_AfterSelect;
            this.fileTreeView.NodeMouseDoubleClick += fileTreeView_NodeMouseDoubleClick;
            // 
            // IntroUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 567);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.gameTypePicker);
            this.Controls.Add(this.gameDirOpenButton);
            this.Controls.Add(this.gameDirLabel);
            this.Controls.Add(this.gameDirPath);
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
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TreeView fileTreeView;
    }
}
