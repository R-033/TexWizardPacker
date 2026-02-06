using Binary.Properties;

using Nikki.Core;

using System;
using System.IO;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;



namespace Binary.Prompt
{
    public partial class TextureImport : Form
    {
        public string Value { get; private set; } = String.Empty;
        public string SourceFile { get; private set; } = String.Empty;
        public bool CopyParams { get; private set; } = false;
        public bool AutoSource { get; private set; } = false;

        private string gamePath;

        public TextureImport(string initial, string gamePath, string sourceFile, bool batchImport)
        {
            this.InitializeComponent();
            this.ToggleTheme();
            this.textureNameText.Text = initial ?? String.Empty;
            this.gamePath = gamePath;

            this.nameLabel.Enabled = !batchImport;
            this.textureNameText.Enabled = !batchImport;

            this.sourceFilePathText.Text = sourceFile;

            if (sourceFile == "(multiple)")
            {
                this.AutoSource = true;
                this.sourceFileLabel.Enabled = false;
                this.sourceFilePathText.Enabled = false;
                this.openSourceFileButton.Enabled = false;
            }
        }

        private void ToggleTheme()
        {
            Theme.Deserialize(Theme.GetThemeFile(), out var theme);

            this.BackColor = theme.Colors.MainBackColor;
            this.ForeColor = theme.Colors.MainForeColor;
            this.InputButtonOK.BackColor = theme.Colors.ButtonBackColor;
            this.InputButtonOK.ForeColor = theme.Colors.ButtonForeColor;
            this.InputButtonOK.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;
            this.InputButtonCancel.BackColor = theme.Colors.ButtonBackColor;
            this.InputButtonCancel.ForeColor = theme.Colors.ButtonForeColor;
            this.InputButtonCancel.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;
            this.openSourceFileButton.BackColor = theme.Colors.ButtonBackColor;
            this.openSourceFileButton.ForeColor = theme.Colors.ButtonForeColor;
            this.openSourceFileButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;
            this.textureNameText.BackColor = theme.Colors.TextBoxBackColor;
            this.textureNameText.ForeColor = theme.Colors.TextBoxForeColor;
            this.sourceFilePathText.BackColor = theme.Colors.TextBoxBackColor;
            this.sourceFilePathText.ForeColor = theme.Colors.TextBoxForeColor;
            this.sourceFileLabel.ForeColor = theme.Colors.LabelTextColor;
            this.nameLabel.ForeColor = theme.Colors.LabelTextColor;
        }

        private void InputButtonOK_Click(object sender, EventArgs e)
        {
            this.Value = this.textureNameText.Text;
            this.SourceFile = this.sourceFilePathText.Text;
            this.CopyParams = this.copyParamsToggle.Checked;
            this.Close();
        }

        private void InputButtonCancel_Click(object sender, EventArgs e) => this.Close();

        private void copyParamsToggle_CheckedChanged(object sender, EventArgs e)
        {
            this.sourceFileLabel.Enabled = this.copyParamsToggle.Checked && !this.AutoSource;
            this.sourceFilePathText.Enabled = this.copyParamsToggle.Checked && !this.AutoSource;
            this.openSourceFileButton.Enabled = this.copyParamsToggle.Checked && !this.AutoSource;
        }

        private void openSourceFileButton_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Bundle File|*.bun;*.bin;*.lzc|All Files|*.*",
                Multiselect = false,
                Title = "Pick source file",
                InitialDirectory = gamePath
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var newPath = dialog.FileName;

                if (!newPath.StartsWith(this.gamePath))
                {
                    MessageBox.Show("Provided file is outside of the game directory. This is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.sourceFilePathText.Text = Path.GetRelativePath(this.gamePath, newPath);
            }
        }
    }
}
