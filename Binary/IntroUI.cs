using Binary.Interact;
using Binary.Prompt;
using Binary.Properties;
using Binary.Tools;
using Binary.UI;

using CoreExtensions.Management;

using Endscript.Commands;
using Endscript.Core;
using Endscript.Enums;
using Endscript.Profiles;

using Nikki.Core;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Binary
{
    public partial class IntroUI : Form
    {
        [Serializable]
        public class TWConfig
        {
            public List<string> packs = new List<string>();
        }

        private TWConfig Config;

        public IntroUI()
        {
            this.InitializeComponent();

            this.IntroToolTip.SetToolTip(this.PictureBoxUpdates, "Check updates for TexWizard Packer");
            this.IntroToolTip.SetToolTip(this.PictureBoxTools, "Tools");
            this.IntroToolTip.SetToolTip(this.PictureBoxTheme, "Change theme");

            this.Text = $"TexWizard Packer - v{this.ProductVersion}";

            this.gameTypePicker.SelectedIndex = Math.Max(0, Configurations.Default.CurrentGame - 1);

            this.gameDirPath.Text = Configurations.Default.GameDirectory;

            this.LoadPackList();
        }

        #region Theme

        private void ToggleTheme()
        {
            Theme.Deserialize(Theme.GetThemeFile(), out var theme);

            this.BackColor = theme.Colors.MainBackColor;
            this.ForeColor = theme.Colors.MainForeColor;
            this.LabelBinary.ForeColor = theme.Colors.LabelTextColor;

            this.ToolsMenu.BackColor = theme.Colors.MainBackColor;
            this.ToolsMenu.ForeColor = theme.Colors.LabelTextColor;
            this.hasherToolStripMenuItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.hasherToolStripMenuItem.BackColor = theme.Colors.MenuItemBackColor;
            this.raiderToolStripMenuItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.raiderToolStripMenuItem.BackColor = theme.Colors.MenuItemBackColor;
            this.swatcherToolStripMenuItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.swatcherToolStripMenuItem.BackColor = theme.Colors.MenuItemBackColor;
            this.settingsToolStripMenuItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.settingsToolStripMenuItem.BackColor = theme.Colors.MenuItemBackColor;

            // Set images according to theme
            this.PictureBoxTheme.Image = theme.DarkTheme
                ? Resources.DarkTheme : Resources.LightTheme;

            this.PictureBoxTools.Image = theme.DarkTheme
                ? Resources.DarkTools : Resources.LightTools;

            this.PictureBoxUpdates.Image = Resources.Update;

            this.createNewButton.BackColor = theme.Colors.ButtonBackColor;
            this.createNewButton.ForeColor = theme.Colors.ButtonForeColor;
            this.createNewButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.openButton.BackColor = theme.Colors.ButtonBackColor;
            this.openButton.ForeColor = theme.Colors.ButtonForeColor;
            this.openButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.removeButton.BackColor = theme.Colors.ButtonBackColor;
            this.removeButton.ForeColor = theme.Colors.ButtonForeColor;
            this.removeButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.upButton.BackColor = theme.Colors.ButtonBackColor;
            this.upButton.ForeColor = theme.Colors.ButtonForeColor;
            this.upButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.downButton.BackColor = theme.Colors.ButtonBackColor;
            this.downButton.ForeColor = theme.Colors.ButtonForeColor;
            this.downButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.packList.BackColor = theme.Colors.TextBoxBackColor;
            this.packList.ForeColor = theme.Colors.TextBoxForeColor;

            this.gameDirLabel.ForeColor = theme.Colors.LabelTextColor;
            this.gameDirLabel.ForeColor = theme.Colors.LabelTextColor;
            this.gameDirLabel.ForeColor = theme.Colors.LabelTextColor;

            this.gameDirPath.BackColor = theme.Colors.TextBoxBackColor;
            this.gameDirPath.ForeColor = theme.Colors.TextBoxForeColor;

            this.gameDirOpenButton.BackColor = theme.Colors.ButtonBackColor;
            this.gameDirOpenButton.ForeColor = theme.Colors.ButtonForeColor;
            this.gameDirOpenButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.gameTypePicker.BackColor = theme.Colors.TextBoxBackColor;
            this.gameTypePicker.ForeColor = theme.Colors.TextBoxForeColor;
        }

        #endregion

        private void ModderInteract()
        {
            this.Hide();
            var start = FormStartPosition.CenterScreen;
            var state = Configurations.Default.StartMaximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;

            using (var editor = new Editor((GameINT)(this.gameTypePicker.SelectedIndex + 1), this.gameDirPath.Text, this.packList.Items[this.packList.SelectedIndex] as string) { StartPosition = start, WindowState = state })
            {

                editor.ShowDialog();

            }

            this.Show();
            this.ToggleTheme();
        }

        private void EnsureBackups(BaseProfile profile)
        {
            foreach (var sdb in profile)
            {

                var orig = sdb.FullPath;
                var back = $"{orig}.bacc";
                if (!File.Exists(back)) File.Copy(orig, back, true);

            }
        }

        private void AskForGameRun(BaseProfile profile)
        {
            var result = MessageBox.Show("Do you wish to run the game?", "Prompt",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                try
                {

                    var path = profile.Directory;
                    var game = profile.GameINT;
                    var exe = path;

                    exe += game switch
                    {
                        GameINT.Carbon => @"\NFSC.EXE",
                        GameINT.MostWanted => @"\SPEED.EXE",
                        GameINT.Prostreet => @"\NFS.EXE",
                        GameINT.Undercover => @"\NFS.EXE",
                        GameINT.Underground1 => @"\SPEED.EXE",
                        GameINT.Underground2 => @"\SPEED2.EXE",
                        _ => throw new Exception($"Game {game} is an invalid game type")
                    };

                    Process.Start(new ProcessStartInfo(exe) { WorkingDirectory = path });

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void PictureBoxTools_Click(object sender, EventArgs e)
        {
            ToolsMenu.Show(PictureBoxTools.Left + this.Left, PictureBoxTools.Top + this.Top); // offset from the edge of your button
        }

        private void PictureBoxUpdates_Click(object sender, EventArgs e)
        {
            Utils.OpenBrowser("https://github.com/r033/TexWizardPacker/releases");
        }

        private void PictureBoxAutoBackups_Click(object sender, EventArgs e)
        {
            Configurations.Default.AutoBackups = !Configurations.Default.AutoBackups;
            Configurations.Default.Save();
            this.ToggleTheme();
        }

        private void PictureBoxMaximized_Click(object sender, EventArgs e)
        {
            Configurations.Default.StartMaximized = !Configurations.Default.StartMaximized;
            Configurations.Default.Save();
            this.ToggleTheme();
        }

        private void PictureBoxTheme_Click(object sender, EventArgs e)
        {
            var themes = new ThemeSelector() { StartPosition = FormStartPosition.CenterScreen };
            themes.ShowDialog();

            if (themes.DialogResult == DialogResult.OK)
            {
                this.ToggleTheme();
            }
        }

        private void LabelBinary_Click(object sender, EventArgs e)
        {
            var about = new About() { StartPosition = FormStartPosition.CenterScreen };
            about.Show();
        }

        private void newLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LanMaker() { StartPosition = FormStartPosition.CenterScreen };
            form.Show();
        }

        private void hasherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hasher = new Hasher() { StartPosition = FormStartPosition.CenterScreen };
            hasher.Show();
        }

        private void raiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raider = new Raider() { StartPosition = FormStartPosition.CenterScreen };
            raider.Show();
        }

        private void swatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var swatcher = new Swatcher() { StartPosition = FormStartPosition.CenterScreen };
            swatcher.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new Interact.Options() { StartPosition = FormStartPosition.CenterScreen };
            settings.Show();
        }

        private void packList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gamePath = this.gameDirPath.Text;

            this.openButton.Enabled = this.packList.Enabled && this.packList.SelectedIndex >= 0 && Directory.Exists(Path.Combine(gamePath, this.packList.Items[this.packList.SelectedIndex] as string));
            this.removeButton.Enabled = this.openButton.Enabled;

            this.upButton.Enabled = this.packList.SelectedIndex > 0;
            this.downButton.Enabled = this.packList.SelectedIndex < this.packList.Items.Count - 1;
        }

        private void packList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.packList.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                this.ModderInteract();
                ForcedX.GCCollect();
            }
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            using var browser = new FolderBrowserDialog()
            {
                InitialDirectory = this.gameDirPath.Text
            };

            if (browser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string gamePath = this.gameDirPath.Text;

                    var newPath = browser.SelectedPath;

                    if (!newPath.StartsWith(gamePath))
                    {
                        MessageBox.Show("Provided directory is outside of the game directory. This is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!File.Exists(Path.Combine(newPath, "textures.bin")))
                    {
                        File.WriteAllBytes(Path.Combine(newPath, "textures.bin"), new byte[0]);
                    }

                    if (!File.Exists(Path.Combine(newPath, "meta.json")))
                    {
                        var meta = new Editor.MetaFile();
                        File.WriteAllText(Path.Combine(newPath, "meta.json"), JsonConvert.SerializeObject(meta, Formatting.Indented));
                    }

                    Config.packs.Add(Path.GetRelativePath(gamePath, newPath));

                    File.WriteAllText(Path.Combine(gamePath, "scripts", "TexWizard.json"), JsonConvert.SerializeObject(Config, Formatting.Indented));

                    this.LoadPackList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gameDirOpenButton_Click(object sender, EventArgs e)
        {
            using var browser = new FolderBrowserDialog()
            {
                InitialDirectory = this.gameDirPath.Text
            };

            if (browser.ShowDialog() == DialogResult.OK)
            {
                this.gameDirPath.Text = browser.SelectedPath;
            }
        }

        private void GameDirPath_TextChanged(object sender, System.EventArgs e)
        {
            Configurations.Default.GameDirectory = this.gameDirPath.Text;
            Configurations.Default.Save();
            this.LoadPackList();
        }

        private void gameTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configurations.Default.CurrentGame = this.gameTypePicker.SelectedIndex + 1;
            Configurations.Default.Save();

            this.ToggleTheme();
        }

        private void LoadPackList()
        {
            this.packList.Enabled = false;
            this.createNewButton.Enabled = false;
            this.openButton.Enabled = false;

            this.packList.Items.Clear();

            string gamePath = this.gameDirPath.Text;

            if (string.IsNullOrEmpty(gamePath))
            {
                this.packList.Items.Add("Input a path to your game directory above to begin.");
                return;
            }

            if (!Directory.Exists(gamePath))
            {
                this.packList.Items.Add("Invalid directory. Please make sure it's correct.");
                return;
            }

            if (!File.Exists(Path.Combine(gamePath, "scripts", "TexWizard.asi")))
            {
                try
                {
                    string dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    string twfrom = Path.Combine(dir, "TexWizard.asi");

                    if (!File.Exists(twfrom))
                    {
                        this.packList.Items.Add("scripts\\TexWizard.asi doesn't exist. Please install TexWizard script to begin.");
                        return;
                    }

                    string twto = Path.Combine(gamePath, "scripts", "TexWizard.asi");
                    Directory.CreateDirectory(Path.Combine(gamePath, "scripts"));
                    File.Copy(twfrom, twto, true);
                }
                catch (Exception ex)
                {
                    this.packList.Items.Add(ex.GetLowestMessage());
                    return;
                }
            }

            if (!File.Exists(Path.Combine(gamePath, "scripts", "TexWizard.json")))
            {
                try
                {
                    var config = new TWConfig();
                    File.WriteAllText(Path.Combine(gamePath, "scripts", "TexWizard.json"), JsonConvert.SerializeObject(config, Formatting.Indented));
                }
                catch (Exception ex)
                {
                    this.packList.Items.Add(ex.GetLowestMessage());
                    return;
                }
            }

            try
            {
                Config = (TWConfig)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(gamePath, "scripts", "TexWizard.json")), typeof(TWConfig));

                for (int i = 0; i < Config.packs.Count; i++)
                {
                    this.packList.Items.Add(Config.packs[i]);
                }
            }
            catch (Exception e)
            {
                this.packList.Items.Add("Error reading TexWizard.json: " + e.Message);
            }

            this.packList.Enabled = true;
            this.createNewButton.Enabled = true;

            if (this.packList.Items.Count > 0)
            {
                this.packList.SelectedIndex = 0;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            this.ModderInteract();
            ForcedX.GCCollect();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove this texture pack from the list?\n\nIt will be removed from TexWizard.json, but texture files will remain.", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string gamePath = this.gameDirPath.Text;

                    Config.packs.RemoveAt(this.packList.SelectedIndex);

                    File.WriteAllText(Path.Combine(gamePath, "scripts", "TexWizard.json"), JsonConvert.SerializeObject(Config, Formatting.Indented));

                    this.LoadPackList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            try
            {
                string gamePath = this.gameDirPath.Text;

                int selected = this.packList.SelectedIndex;
                var temp = Config.packs[selected];
                Config.packs[selected] = Config.packs[selected - 1];
                Config.packs[selected - 1] = temp;

                File.WriteAllText(Path.Combine(gamePath, "scripts", "TexWizard.json"), JsonConvert.SerializeObject(Config, Formatting.Indented));

                this.LoadPackList();

                this.packList.SelectedIndex = selected - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            try
            {
                string gamePath = this.gameDirPath.Text;

                int selected = this.packList.SelectedIndex;
                var temp = Config.packs[selected];
                Config.packs[selected] = Config.packs[selected + 1];
                Config.packs[selected + 1] = temp;

                File.WriteAllText(Path.Combine(gamePath, "scripts", "TexWizard.json"), JsonConvert.SerializeObject(Config, Formatting.Indented));

                this.LoadPackList();

                this.packList.SelectedIndex = selected + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
