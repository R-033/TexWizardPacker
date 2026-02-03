namespace Binary.Prompt
{
    partial class TextureImport
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
            this.textureNameText = new System.Windows.Forms.TextBox();
            this.sourceFileLabel = new System.Windows.Forms.Label();
            this.InputButtonOK = new System.Windows.Forms.Button();
            this.InputButtonCancel = new System.Windows.Forms.Button();
            this.copyParamsToggle = new System.Windows.Forms.CheckBox();
            this.openSourceFileButton = new System.Windows.Forms.Button();
            this.sourceFilePathText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textureNameText
            // 
            this.textureNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureNameText.Location = new System.Drawing.Point(60, 12);
            this.textureNameText.Name = "textureNameText";
            this.textureNameText.Size = new System.Drawing.Size(278, 23);
            this.textureNameText.TabIndex = 0;
            // 
            // sourceFileLabel
            // 
            this.sourceFileLabel.AutoSize = true;
            this.sourceFileLabel.Location = new System.Drawing.Point(12, 84);
            this.sourceFileLabel.Name = "sourceFileLabel";
            this.sourceFileLabel.Size = new System.Drawing.Size(65, 15);
            this.sourceFileLabel.TabIndex = 1;
            this.sourceFileLabel.Text = "Source file:";
            // 
            // InputButtonOK
            // 
            this.InputButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.InputButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputButtonOK.Location = new System.Drawing.Point(140, 123);
            this.InputButtonOK.Name = "InputButtonOK";
            this.InputButtonOK.Size = new System.Drawing.Size(96, 25);
            this.InputButtonOK.TabIndex = 2;
            this.InputButtonOK.Text = "OK";
            this.InputButtonOK.UseVisualStyleBackColor = true;
            this.InputButtonOK.Click += this.InputButtonOK_Click;
            // 
            // InputButtonCancel
            // 
            this.InputButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.InputButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputButtonCancel.Location = new System.Drawing.Point(242, 123);
            this.InputButtonCancel.Name = "InputButtonCancel";
            this.InputButtonCancel.Size = new System.Drawing.Size(96, 25);
            this.InputButtonCancel.TabIndex = 2;
            this.InputButtonCancel.Text = "Cancel";
            this.InputButtonCancel.UseVisualStyleBackColor = true;
            this.InputButtonCancel.Click += this.InputButtonCancel_Click;
            // 
            // copyParamsToggle
            // 
            this.copyParamsToggle.AutoSize = true;
            this.copyParamsToggle.Checked = true;
            this.copyParamsToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyParamsToggle.Location = new System.Drawing.Point(12, 49);
            this.copyParamsToggle.Name = "copyParamsToggle";
            this.copyParamsToggle.Size = new System.Drawing.Size(208, 19);
            this.copyParamsToggle.TabIndex = 3;
            this.copyParamsToggle.Text = "Copy parameters from the original";
            this.copyParamsToggle.UseVisualStyleBackColor = true;
            this.copyParamsToggle.CheckedChanged += this.copyParamsToggle_CheckedChanged;
            // 
            // openSourceFileButton
            // 
            this.openSourceFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSourceFileButton.Location = new System.Drawing.Point(266, 80);
            this.openSourceFileButton.Name = "openSourceFileButton";
            this.openSourceFileButton.Size = new System.Drawing.Size(72, 25);
            this.openSourceFileButton.TabIndex = 4;
            this.openSourceFileButton.Text = "Open...";
            this.openSourceFileButton.UseVisualStyleBackColor = true;
            this.openSourceFileButton.Click += this.openSourceFileButton_Click;
            // 
            // sourceFilePathText
            // 
            this.sourceFilePathText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceFilePathText.Location = new System.Drawing.Point(83, 81);
            this.sourceFilePathText.Name = "sourceFilePathText";
            this.sourceFilePathText.Size = new System.Drawing.Size(177, 23);
            this.sourceFilePathText.TabIndex = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name:";
            // 
            // TextureImport
            // 
            this.AcceptButton = this.InputButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.InputButtonCancel;
            this.ClientSize = new System.Drawing.Size(350, 160);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.sourceFilePathText);
            this.Controls.Add(this.openSourceFileButton);
            this.Controls.Add(this.copyParamsToggle);
            this.Controls.Add(this.InputButtonCancel);
            this.Controls.Add(this.InputButtonOK);
            this.Controls.Add(this.sourceFileLabel);
            this.Controls.Add(this.textureNameText);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TextureImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textureNameText;
        private System.Windows.Forms.Label sourceFileLabel;
        private System.Windows.Forms.Button InputButtonOK;
        private System.Windows.Forms.Button InputButtonCancel;
        private System.Windows.Forms.CheckBox copyParamsToggle;
        private System.Windows.Forms.Button openSourceFileButton;
        private System.Windows.Forms.TextBox sourceFilePathText;
        private System.Windows.Forms.Label nameLabel;
    }
}
