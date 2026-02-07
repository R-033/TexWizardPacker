using Binary.Properties;

namespace Binary.UI
{
    partial class TextureEditor
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureEditor));
            this.TexEditorMenuStrip = new System.Windows.Forms.CustomMenuStrip();
            this.TexEditorTexturesStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorAddTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorAddTextureFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorRemoveTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorOptionsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorExportAllItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorFindReplaceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorToolsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorHasherItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexEditorRaiderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.EditorFindTextBox = new System.Windows.Forms.TextBox();
            this.TexEditorListView = new System.Windows.Forms.ListView();
            this.ColumnOriginalName = new System.Windows.Forms.ColumnHeader();
            this.ColumnNewName = new System.Windows.Forms.ColumnHeader();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TexEditorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.originalNameText = new System.Windows.Forms.TextBox();
            this.openOrigFileButton = new System.Windows.Forms.Button();
            this.applyOrigParamsButton = new System.Windows.Forms.Button();
            this.fromFileText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TexEditorImage = new System.Windows.Forms.PictureBox();
            this.AddTextureDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExportTextureDialog = new System.Windows.Forms.SaveFileDialog();
            this.AddTextureFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TexEditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.TexEditorImage).BeginInit();
            this.SuspendLayout();
            // 
            // TexEditorMenuStrip
            // 
            this.TexEditorMenuStrip.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TexEditorMenuStrip.ImageMarginGradientBegin = System.Drawing.Color.Maroon;
            this.TexEditorMenuStrip.ImageMarginGradientEnd = System.Drawing.Color.WhiteSmoke;
            this.TexEditorMenuStrip.ImageMarginGradientMiddle = System.Drawing.Color.WhiteSmoke;
            this.TexEditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TexEditorTexturesStrip, this.TexEditorOptionsStrip, this.TexEditorToolsStrip });
            this.TexEditorMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TexEditorMenuStrip.MenuBorder = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuItemBorder = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuItemPressedGradientBegin = System.Drawing.Color.DimGray;
            this.TexEditorMenuStrip.MenuItemPressedGradientEnd = System.Drawing.Color.DimGray;
            this.TexEditorMenuStrip.MenuItemPressedGradientMiddle = System.Drawing.Color.DimGray;
            this.TexEditorMenuStrip.MenuItemSelected = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuItemSelectedGradientBegin = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuItemSelectedGradientEnd = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuStripForeColor = System.Drawing.Color.WhiteSmoke;
            this.TexEditorMenuStrip.MenuStripGradientBegin = System.Drawing.Color.Black;
            this.TexEditorMenuStrip.MenuStripGradientEnd = System.Drawing.Color.DimGray;
            this.TexEditorMenuStrip.Name = "TexEditorMenuStrip";
            this.TexEditorMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.TexEditorMenuStrip.Size = new System.Drawing.Size(1148, 24);
            this.TexEditorMenuStrip.TabIndex = 0;
            this.TexEditorMenuStrip.Text = "StrEditorMenuStrip";
            // 
            // TexEditorTexturesStrip
            // 
            this.TexEditorTexturesStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TexEditorAddTextureItem, this.TexEditorAddTextureFolderItem, this.TexEditorRemoveTextureItem });
            this.TexEditorTexturesStrip.Name = "TexEditorTexturesStrip";
            this.TexEditorTexturesStrip.Size = new System.Drawing.Size(62, 20);
            this.TexEditorTexturesStrip.Text = "Textures";
            // 
            // TexEditorAddTextureItem
            // 
            this.TexEditorAddTextureItem.Name = "TexEditorAddTextureItem";
            this.TexEditorAddTextureItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.A;
            this.TexEditorAddTextureItem.Size = new System.Drawing.Size(267, 22);
            this.TexEditorAddTextureItem.Text = "Add/Update Texture(s)";
            this.TexEditorAddTextureItem.Click += this.TexEditorAddTextureItem_Click;
            // 
            // TexEditorAddTextureFolderItem
            // 
            this.TexEditorAddTextureFolderItem.Name = "TexEditorAddTextureFolderItem";
            this.TexEditorAddTextureFolderItem.Size = new System.Drawing.Size(267, 22);
            this.TexEditorAddTextureFolderItem.Text = "Add/Update From Folder";
            this.TexEditorAddTextureFolderItem.Click += this.TexEditorAddTextureFolderItem_Click;
            // 
            // TexEditorRemoveTextureItem
            // 
            this.TexEditorRemoveTextureItem.Name = "TexEditorRemoveTextureItem";
            this.TexEditorRemoveTextureItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D;
            this.TexEditorRemoveTextureItem.Size = new System.Drawing.Size(267, 22);
            this.TexEditorRemoveTextureItem.Text = "Remove Texture(s)";
            this.TexEditorRemoveTextureItem.Click += this.TexEditorRemoveTextureItem_Click;
            // 
            // TexEditorOptionsStrip
            // 
            this.TexEditorOptionsStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TexEditorExportAllItem, this.TexEditorFindReplaceItem, this.selectAllToolStripMenuItem });
            this.TexEditorOptionsStrip.Name = "TexEditorOptionsStrip";
            this.TexEditorOptionsStrip.Size = new System.Drawing.Size(61, 20);
            this.TexEditorOptionsStrip.Text = "Options";
            // 
            // TexEditorExportAllItem
            // 
            this.TexEditorExportAllItem.Name = "TexEditorExportAllItem";
            this.TexEditorExportAllItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.E;
            this.TexEditorExportAllItem.Size = new System.Drawing.Size(239, 22);
            this.TexEditorExportAllItem.Text = "Export Selected";
            this.TexEditorExportAllItem.Click += this.TexEditorExportAllItem_Click;
            // 
            // TexEditorFindReplaceItem
            // 
            this.TexEditorFindReplaceItem.Name = "TexEditorFindReplaceItem";
            this.TexEditorFindReplaceItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.R;
            this.TexEditorFindReplaceItem.Size = new System.Drawing.Size(239, 22);
            this.TexEditorFindReplaceItem.Text = "Find And Replace";
            this.TexEditorFindReplaceItem.Click += this.TexEditorFindReplaceItem_Click;
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A;
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += this.selectAllToolStripMenuItem_Click;
            // 
            // TexEditorToolsStrip
            // 
            this.TexEditorToolsStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TexEditorHasherItem, this.TexEditorRaiderItem });
            this.TexEditorToolsStrip.Name = "TexEditorToolsStrip";
            this.TexEditorToolsStrip.Size = new System.Drawing.Size(46, 20);
            this.TexEditorToolsStrip.Text = "Tools";
            // 
            // TexEditorHasherItem
            // 
            this.TexEditorHasherItem.Name = "TexEditorHasherItem";
            this.TexEditorHasherItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H;
            this.TexEditorHasherItem.Size = new System.Drawing.Size(150, 22);
            this.TexEditorHasherItem.Text = "Hasher";
            this.TexEditorHasherItem.Click += this.TexEditorHasherItem_Click;
            // 
            // TexEditorRaiderItem
            // 
            this.TexEditorRaiderItem.Name = "TexEditorRaiderItem";
            this.TexEditorRaiderItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R;
            this.TexEditorRaiderItem.Size = new System.Drawing.Size(150, 22);
            this.TexEditorRaiderItem.Text = "Raider";
            this.TexEditorRaiderItem.Click += this.TexEditorRaiderItem_Click;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.EditorFindTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.TexEditorListView);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 524;
            this.splitContainer1.Size = new System.Drawing.Size(1148, 603);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // EditorFindTextBox
            // 
            this.EditorFindTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.EditorFindTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorFindTextBox.Location = new System.Drawing.Point(12, 9);
            this.EditorFindTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditorFindTextBox.Name = "EditorFindTextBox";
            this.EditorFindTextBox.PlaceholderText = "Search";
            this.EditorFindTextBox.Size = new System.Drawing.Size(513, 23);
            this.EditorFindTextBox.TabIndex = 1;
            this.EditorFindTextBox.TextChanged += this.EditorFindTextBox_TextChanged;
            // 
            // TexEditorListView
            // 
            this.TexEditorListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.TexEditorListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TexEditorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnOriginalName, this.ColumnNewName });
            this.TexEditorListView.FullRowSelect = true;
            this.TexEditorListView.Location = new System.Drawing.Point(12, 39);
            this.TexEditorListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TexEditorListView.Name = "TexEditorListView";
            this.TexEditorListView.OwnerDraw = true;
            this.TexEditorListView.Size = new System.Drawing.Size(514, 552);
            this.TexEditorListView.TabIndex = 0;
            this.TexEditorListView.UseCompatibleStateImageBehavior = false;
            this.TexEditorListView.View = System.Windows.Forms.View.Details;
            this.TexEditorListView.ColumnClick += this.TexEditorListView_ColumnClick;
            this.TexEditorListView.ColumnWidthChanging += this.TexEditorListView_ColumnWidthChanging;
            this.TexEditorListView.DrawColumnHeader += this.TexEditorListView_DrawColumnHeader;
            this.TexEditorListView.DrawItem += this.TexEditorListView_DrawItem;
            this.TexEditorListView.SelectedIndexChanged += this.TexEditorListView_SelectedIndexChanged;
            // 
            // ColumnOriginalName
            // 
            this.ColumnOriginalName.Text = "Original Name";
            this.ColumnOriginalName.Width = 238;
            // 
            // ColumnNewName
            // 
            this.ColumnNewName.Text = "New Name";
            this.ColumnNewName.Width = 238;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TexEditorPropertyGrid);
            this.splitContainer2.Panel1.Controls.Add(this.originalNameText);
            this.splitContainer2.Panel1.Controls.Add(this.openOrigFileButton);
            this.splitContainer2.Panel1.Controls.Add(this.applyOrigParamsButton);
            this.splitContainer2.Panel1.Controls.Add(this.fromFileText);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(611, 603);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += this.SplitContainer2_SplitterMoved;
            // 
            // TexEditorPropertyGrid
            // 
            this.TexEditorPropertyGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.TexEditorPropertyGrid.HelpVisible = false;
            this.TexEditorPropertyGrid.Location = new System.Drawing.Point(4, 39);
            this.TexEditorPropertyGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TexEditorPropertyGrid.Name = "TexEditorPropertyGrid";
            this.TexEditorPropertyGrid.Size = new System.Drawing.Size(594, 358);
            this.TexEditorPropertyGrid.TabIndex = 0;
            this.TexEditorPropertyGrid.PropertyValueChanged += this.TexEditorPropertyGrid_PropertyValueChanged;
            // 
            // originalNameText
            // 
            this.originalNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalNameText.Enabled = false;
            this.originalNameText.Location = new System.Drawing.Point(6, 9);
            this.originalNameText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.originalNameText.Name = "originalNameText";
            this.originalNameText.PlaceholderText = "Original Name";
            this.originalNameText.Size = new System.Drawing.Size(322, 23);
            this.originalNameText.TabIndex = 3;
            this.originalNameText.TextChanged += this.originalNameText_TextChanged;
            // 
            // openOrigFileButton
            // 
            this.openOrigFileButton.Enabled = false;
            this.openOrigFileButton.Location = new System.Drawing.Point(513, 7);
            this.openOrigFileButton.Name = "openOrigFileButton";
            this.openOrigFileButton.Size = new System.Drawing.Size(28, 27);
            this.openOrigFileButton.TabIndex = 6;
            this.openOrigFileButton.Text = "...";
            this.openOrigFileButton.UseVisualStyleBackColor = true;
            this.openOrigFileButton.Click += this.openOrigFileButton_Click;
            // 
            // applyOrigParamsButton
            // 
            this.applyOrigParamsButton.Enabled = false;
            this.applyOrigParamsButton.Location = new System.Drawing.Point(547, 7);
            this.applyOrigParamsButton.Name = "applyOrigParamsButton";
            this.applyOrigParamsButton.Size = new System.Drawing.Size(52, 27);
            this.applyOrigParamsButton.TabIndex = 5;
            this.applyOrigParamsButton.Text = "Apply";
            this.applyOrigParamsButton.UseVisualStyleBackColor = true;
            this.applyOrigParamsButton.Click += this.applyOrigParamsButton_Click;
            // 
            // fromFileText
            // 
            this.fromFileText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fromFileText.Enabled = false;
            this.fromFileText.Location = new System.Drawing.Point(336, 9);
            this.fromFileText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fromFileText.Name = "fromFileText";
            this.fromFileText.PlaceholderText = "Source File";
            this.fromFileText.Size = new System.Drawing.Size(170, 23);
            this.fromFileText.TabIndex = 4;
            this.fromFileText.TextChanged += this.fromFileText_TextChanged;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TexEditorImage);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 177);
            this.panel1.TabIndex = 1;
            // 
            // TexEditorImage
            // 
            this.TexEditorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TexEditorImage.Location = new System.Drawing.Point(-1, -1);
            this.TexEditorImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TexEditorImage.Name = "TexEditorImage";
            this.TexEditorImage.Size = new System.Drawing.Size(594, 308);
            this.TexEditorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TexEditorImage.TabIndex = 0;
            this.TexEditorImage.TabStop = false;
            // 
            // AddTextureDialog
            // 
            this.AddTextureDialog.Filter = "Direct Draw Surface Files|*.dds";
            this.AddTextureDialog.Multiselect = true;
            // 
            // TextureEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1148, 627);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.TexEditorMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MainMenuStrip = this.TexEditorMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1164, 666);
            this.Name = "TextureEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texture Editor";
            this.FormClosing += this.TextureEditor_FormClosing;
            this.TexEditorMenuStrip.ResumeLayout(false);
            this.TexEditorMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.TexEditorImage).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CustomMenuStrip TexEditorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TexEditorTexturesStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView TexEditorListView;
        private System.Windows.Forms.PropertyGrid TexEditorPropertyGrid;
        private System.Windows.Forms.PictureBox TexEditorImage;
        private System.Windows.Forms.ToolStripMenuItem TexEditorAddTextureItem;
        private System.Windows.Forms.ToolStripMenuItem TexEditorRemoveTextureItem;
        private System.Windows.Forms.ToolStripMenuItem TexEditorOptionsStrip;
        private System.Windows.Forms.ToolStripMenuItem TexEditorExportAllItem;
        private System.Windows.Forms.ToolStripMenuItem TexEditorFindReplaceItem;
        private System.Windows.Forms.ToolStripMenuItem TexEditorToolsStrip;
        private System.Windows.Forms.ToolStripMenuItem TexEditorHasherItem;
        private System.Windows.Forms.ToolStripMenuItem TexEditorRaiderItem;
        private System.Windows.Forms.ColumnHeader ColumnNewName;
        private System.Windows.Forms.OpenFileDialog AddTextureDialog;
        private System.Windows.Forms.FolderBrowserDialog AddTextureFolderDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog ExportTextureDialog;
        private System.Windows.Forms.ColumnHeader ColumnOriginalName;
        private System.Windows.Forms.ToolStripMenuItem TexEditorAddTextureFolderItem;
        private System.Windows.Forms.Button applyOrigParamsButton;
        private System.Windows.Forms.TextBox fromFileText;
        private System.Windows.Forms.TextBox originalNameText;
        private System.Windows.Forms.Button openOrigFileButton;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.TextBox EditorFindTextBox;
    }
}
