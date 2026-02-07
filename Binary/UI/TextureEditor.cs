using Binary.Interact;
using Binary.Prompt;
using Binary.Properties;
using Binary.Tools;

using CoreExtensions.Management;
using CoreExtensions.Text;

using Endscript.Core;
using Endscript.Enums;
using Endscript.Helpers;
using Endscript.Profiles;

using ILWrapper.Enums;

using Nikki.Reflection.Enum;
using Nikki.Support.Shared.Class;
using Nikki.Support.Shared.Parts.TPKParts;
using Nikki.Utils;
using Nikki.Utils.EA;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Binary.UI
{
    public partial class TextureEditor : Form
    {
        private TPKBlock[] TPK { get; }
        private readonly List<Form> _openforms;
        private readonly string[] _tpkpath;
        public List<string> Commands { get; }
        private int _last_column_clicked = -1;

        private Color HighlightColor { get; set; }

        private Editor editor;

        private string searchQuery;

        Timer changeDelayTimer = null;

        public TextureEditor(Editor parent, TPKBlock[] tpk, string[] path)
        {
            this.editor = parent;
            this.InitializeComponent();
            this.TPK = tpk;
            this._tpkpath = path;
            this._openforms = new List<Form>();
            this.Commands = new List<string>();
            if (this.TPK.Length == 1)
            {
                this.Text = $"Texture Editor : {this.TPK[0].CollectionName}";
            }
            else
            {
                this.Text = $"Texture Editor : {this.TPK.Length} TPKs";
            }
            this.TexEditorImage.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.TexEditorImage.BorderStyle = BorderStyle.FixedSingle;
            this.TexEditorImage.Width = this.panel1.Width;
            this.TexEditorImage.Height = this.panel1.Height;
            this.TexEditorListView.Columns[^1].Width = -2;
            this.splitContainer2.SplitterDistance = Configurations.Default.TexSplitterDistance;
            this.TexEditorAddTextureItem.Enabled = this.TPK.Length == 1;
            this.TexEditorAddTextureFolderItem.Enabled = this.TPK.Length == 1;
            this.ToggleTheme();
            this.LoadListView();
            this.ToggleMenuStripControls();

        }

        #region Theme

        private void ToggleTheme()
        {
            Theme.Deserialize(Theme.GetThemeFile(), out var theme);

            // Primary colors and controls
            this.BackColor = theme.Colors.MainBackColor;
            this.ForeColor = theme.Colors.MainForeColor;

            // Image
            this.panel1.BackgroundImage = theme.DarkTheme
                ? Resources.DarkTransparent : Resources.LightTransparent;

            // List view
            this.TexEditorListView.BackColor = theme.Colors.PrimBackColor;
            this.TexEditorListView.ForeColor = theme.Colors.PrimForeColor;

            // Property grid
            this.TexEditorPropertyGrid.BackColor = theme.Colors.PrimBackColor;
            this.TexEditorPropertyGrid.CategorySplitterColor = theme.Colors.ButtonBackColor;
            this.TexEditorPropertyGrid.CategoryForeColor = theme.Colors.TextBoxForeColor;
            this.TexEditorPropertyGrid.CommandsBackColor = theme.Colors.PrimBackColor;
            this.TexEditorPropertyGrid.CommandsForeColor = theme.Colors.PrimForeColor;
            this.TexEditorPropertyGrid.CommandsBorderColor = theme.Colors.PrimBackColor;
            this.TexEditorPropertyGrid.DisabledItemForeColor = theme.Colors.LabelTextColor;
            this.TexEditorPropertyGrid.LineColor = theme.Colors.ButtonBackColor;
            this.TexEditorPropertyGrid.SelectedItemWithFocusBackColor = theme.Colors.FocusedBackColor;
            this.TexEditorPropertyGrid.SelectedItemWithFocusForeColor = theme.Colors.FocusedForeColor;
            this.TexEditorPropertyGrid.ViewBorderColor = theme.Colors.RegBorderColor;
            this.TexEditorPropertyGrid.ViewBackColor = theme.Colors.PrimBackColor;
            this.TexEditorPropertyGrid.ViewForeColor = theme.Colors.PrimForeColor;

            // Menu strip and menu items
            this.TexEditorMenuStrip.MenuStripGradientBegin = theme.Colors.MenuStripGradientBegin;
            this.TexEditorMenuStrip.MenuStripGradientEnd = theme.Colors.MenuStripGradientEnd;
            this.TexEditorMenuStrip.MenuStripForeColor = theme.Colors.LabelTextColor;
            this.TexEditorMenuStrip.MenuBorder = theme.Colors.MenuBorder;
            this.TexEditorMenuStrip.MenuItemBorder = theme.Colors.MenuItemBorder;
            this.TexEditorMenuStrip.MenuItemPressedGradientBegin = theme.Colors.MenuItemPressedGradientBegin;
            this.TexEditorMenuStrip.MenuItemPressedGradientMiddle = theme.Colors.MenuItemPressedGradientMiddle;
            this.TexEditorMenuStrip.MenuItemPressedGradientEnd = theme.Colors.MenuItemPressedGradientEnd;
            this.TexEditorMenuStrip.MenuItemSelected = theme.Colors.MenuItemSelected;
            this.TexEditorMenuStrip.MenuItemSelectedGradientBegin = theme.Colors.MenuItemSelectedGradientBegin;
            this.TexEditorMenuStrip.MenuItemSelectedGradientEnd = theme.Colors.MenuItemSelectedGradientEnd;
            this.TexEditorMenuStrip.ImageMarginGradientBegin = theme.Colors.MenuItemPressedGradientBegin;
            this.TexEditorMenuStrip.ImageMarginGradientMiddle = theme.Colors.MenuItemPressedGradientMiddle;
            this.TexEditorMenuStrip.ImageMarginGradientEnd = theme.Colors.MenuItemPressedGradientEnd;
            this.TexEditorAddTextureItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorAddTextureItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorAddTextureFolderItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorAddTextureFolderItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorExportAllItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorExportAllItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorFindReplaceItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorFindReplaceItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorFindReplaceItem2.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorFindReplaceItem2.ForeColor = theme.Colors.MenuItemForeColor;
            this.selectAllToolStripMenuItem.BackColor = theme.Colors.MenuItemBackColor;
            this.selectAllToolStripMenuItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorHasherItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorHasherItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorRaiderItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorRaiderItem.ForeColor = theme.Colors.MenuItemForeColor;
            this.TexEditorRemoveTextureItem.BackColor = theme.Colors.MenuItemBackColor;
            this.TexEditorRemoveTextureItem.ForeColor = theme.Colors.MenuItemForeColor;

            this.originalNameText.BackColor = theme.Colors.TextBoxBackColor;
            this.originalNameText.ForeColor = theme.Colors.TextBoxForeColor;

            this.fromFileText.BackColor = theme.Colors.TextBoxBackColor;
            this.fromFileText.ForeColor = theme.Colors.TextBoxForeColor;

            this.openOrigFileButton.BackColor = theme.Colors.ButtonBackColor;
            this.openOrigFileButton.ForeColor = theme.Colors.ButtonForeColor;
            this.openOrigFileButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.applyOrigParamsButton.BackColor = theme.Colors.ButtonBackColor;
            this.applyOrigParamsButton.ForeColor = theme.Colors.ButtonForeColor;
            this.applyOrigParamsButton.FlatAppearance.BorderColor = theme.Colors.ButtonFlatColor;

            this.EditorFindTextBox.BackColor = theme.Colors.TextBoxBackColor;
            this.EditorFindTextBox.ForeColor = theme.Colors.TextBoxForeColor;

            // Highlight color
            this.HighlightColor = theme.DarkTheme
                ? Color.FromArgb(70, 0, 20)
                : Color.FromArgb(255, 100, 100);
        }

        #endregion

        #region Methods

        private void EditorFindTextBox_TextChanged(object sender, EventArgs e)
        {
            searchQuery = this.EditorFindTextBox.Text;

            this.LoadListView();
        }

        /*private void ChangeSelection(int[] indices)
        {
            for (int i = 0; i < this.TexEditorListView.Items.Count; i++)
            {
                ListViewItem item = this.TexEditorListView.Items[i];
                item.Selected = indices.Contains(i);
                if (item.Selected)
                {
                    item.EnsureVisible();
                }
            }
        }*/

        private void LoadListView()
        {
            this.TexEditorListView.Items.Clear();
            List<Texture> list = new List<Texture>();
            foreach (var tpk in this.TPK)
            {
                list.AddRange(tpk.GetTextures());
            }
            this.TexEditorListView.BeginUpdate();

            bool doSearch = !string.IsNullOrEmpty(searchQuery);
            string[] searchTokens = null;
            if (doSearch)
            {
                searchTokens = searchQuery.Split(' ');
            }

            foreach (var texture in list)
            {
                string originalName = "-----";
                string newName = texture.BinKey != texture.CollectionName.BinHash() ? $"0x{texture.BinKey:X8}" : texture.CollectionName;

                editor.Meta.GetBothNames(texture.BinKey, ref originalName, ref newName);

                if (doSearch)
                {
                    bool fits = true;

                    for (int i = 0; i < searchTokens.Length; i++)
                    {
                        if (!originalName.Contains(searchTokens[i], StringComparison.InvariantCultureIgnoreCase) && !newName.Contains(searchTokens[i], StringComparison.InvariantCultureIgnoreCase))
                        {
                            continue;
                        }
                    }

                    if (!fits)
                    {
                        continue;
                    }
                }

                var item = new ListViewItem
                {
                    Text = originalName
                };

                item.SubItems.Add(newName);

                this.TexEditorListView.Items.Add(item);

            }

            this.TexEditorListView.EndUpdate();
        }

        private void ToggleMenuStripControls()
        {
            this.TexEditorRemoveTextureItem.Enabled = this.TexEditorListView.SelectedItems.Count > 0;
            this.TexEditorExportAllItem.Enabled = this.TexEditorListView.SelectedItems.Count > 0;
        }

        private uint GetSelectedKey()
        {
            return this.TexEditorListView.SelectedItems.Count == 0
                ? UInt32.MaxValue
                : (this.TexEditorListView.SelectedItems[0].SubItems[1].Text.BinHash());
        }

        private void DisposeImage()
        {
            if (this.TexEditorImage.Image != null)
            {

                var disposer = this.TexEditorImage.Image;
                this.TexEditorImage.Image = null;
                disposer.Dispose();

            }
        }

        #endregion

        private static string loadedAuxFile;
        private static BaseProfile auxProfile;

        private static Texture FindAuxTexture(string textureName)
        {
            foreach (var sdb in auxProfile)
            {
                foreach (var manager in sdb.Database.Managers)
                {
                    foreach (var collection in manager)
                    {
                        if (collection is TPKBlock tpk)
                        {
                            var result = tpk.FindTexture(textureName.BinHash(), KeyType.BINKEY);

                            if (result != null)
                            {
                                return result;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private bool LoadAuxFile(string sourceFile)
        {
            if (loadedAuxFile == sourceFile)
            {
                return true;
            }

            loadedAuxFile = sourceFile;
            auxProfile = null;
            ForcedX.GCCollect();

            try
            {
                if (File.Exists(Path.Combine(editor.GamePath, sourceFile)))
                {
                    auxProfile = BaseProfile.NewProfile(editor.GameType, editor.GamePath);

                    var launch = new Launch();

                    launch.Usage = eUsage.Modder.ToString();
                    launch.Game = editor.GameType.ToString();
                    launch.Directory = editor.GamePath;

                    launch.Files = new List<string>() { sourceFile };

                    auxProfile.Load(launch);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                auxProfile = null;
                ForcedX.GCCollect();

                return false;
            }
        }

        private Texture FindTexture(uint key)
        {
            foreach (var tpk in this.TPK)
            {
                var tex = tpk.FindTexture(key, KeyType.BINKEY);

                if (tex != null)
                {
                    return tex;
                }
            }

            return null;
        }

        private bool CopyAuxParams(string origName, string newName)
        {
            if (auxProfile == null)
            {
                return false;
            }

            Texture origTex = FindAuxTexture(origName);

            if (origTex != null)
            {
                Texture newTex = this.FindTexture(newName.BinHash());

                newTex.ClassKey = origTex.ClassKey;
                newTex.MipmapBiasType = origTex.MipmapBiasType;
                newTex.BiasLevel = origTex.BiasLevel;
                newTex.AlphaUsageType = origTex.AlphaUsageType;
                newTex.AlphaBlendType = origTex.AlphaBlendType;
                newTex.ApplyAlphaSort = origTex.ApplyAlphaSort;
                newTex.ScrollType = origTex.ScrollType;
                newTex.RenderingOrder = origTex.RenderingOrder;
                newTex.TileableUV = origTex.TileableUV;
                newTex.OffsetS = origTex.OffsetS;
                newTex.OffsetT = origTex.OffsetT;
                newTex.ScaleS = origTex.ScaleS;
                newTex.ScaleT = origTex.ScaleT;
                newTex.ScrollTimestep = origTex.ScrollTimestep;
                newTex.ScrollSpeedS = origTex.ScrollSpeedS;
                newTex.ScrollSpeedT = origTex.ScrollSpeedT;
                newTex.Flags = origTex.Flags;

                // todo gen commands?

                return true;
            }

            return false;
        }

        private void ImportTexture(string textureName, string filePath, string sourceFile, bool copyParams, List<string> couldntFindThese)
        {
            try
            {
                if (!Comp.IsDDSTexture(filePath, out string error))
                {
                    throw new Exception(error);
                }

                if (copyParams)
                {
                    this.LoadAuxFile(sourceFile);
                }

                var newName = "_" + textureName;

                if (!editor.IsTexturePack)
                {
                    newName = textureName;
                }

                var prevTexture = this.FindTexture(newName.BinHash());

                if (prevTexture != null)
                {
                    prevTexture.Reload(filePath);
                    this.GenerateReplaceTextureCommand(newName, filePath, 0);
                }
                else
                {
                    this.TPK[0].AddTexture(newName, filePath);
                    this.GenerateAddTextureCommand(newName, filePath, 0);
                }

                bool copied = false;

                if (copyParams)
                {
                    copied = this.CopyAuxParams(textureName, newName);
                }

                if (!copied)
                {
                    if (copyParams && auxProfile != null)
                    {
                        couldntFindThese.Add(textureName);
                    }

                    this.FindTexture(newName.BinHash()).RenderingOrder = 0;
                    this.GenerateUpdateTextureCommand(newName, "RenderingOrder", "0", 0);
                }

                if (editor.IsTexturePack)
                {
                    editor.Meta.AddTexture(textureName, newName, copied ? loadedAuxFile : string.Empty);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Menu Strip

        private void ImportMultipleTextures(string[] textures)
        {
            string sourceFile = string.Empty;

            switch (editor.GameType)
            {
                case Nikki.Core.GameINT.Carbon:
                    sourceFile = "TRACKS\\STREAML5RA.BUN";
                    break;
                case Nikki.Core.GameINT.MostWanted:
                    sourceFile = "TRACKS\\STREAML2RA.BUN";
                    break;
                case Nikki.Core.GameINT.Underground2:
                    sourceFile = "TRACKS\\STREAML4RA.BUN";
                    break;
                case Nikki.Core.GameINT.Underground1:
                    sourceFile = "TRACKS\\STREAML1RA.BUN";
                    break;
                case Nikki.Core.GameINT.Prostreet:
                    sourceFile = "TRACKS\\STREAML6R_FE.BUN";
                    break;
                case Nikki.Core.GameINT.Undercover:
                    sourceFile = "TRACKS\\STREAML8R_MW2.BUN";
                    break;
            }

            if (textures.Length > 1)
            {
                string preferredSourceFile = string.Empty;

                for (int i = 0; i < textures.Length; i++)
                {
                    var initial = Path.GetFileNameWithoutExtension(textures[i]);

                    var preferredSourceFile2 = this.editor.Meta.GetLink(initial);

                    if (i == 0)
                    {
                        preferredSourceFile = preferredSourceFile2;
                        continue;
                    }

                    if (preferredSourceFile2 != preferredSourceFile)
                    {
                        preferredSourceFile = "(multiple)";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(preferredSourceFile))
                {
                    sourceFile = preferredSourceFile;
                }

                using var input = new TextureImport($"({textures.Length} textures)", editor.GamePath, sourceFile, true);

                if (input.ShowDialog() == DialogResult.OK)
                {
                    var couldntFindThese = new List<string>();

                    foreach (var fileName in textures)
                    {
                        string fileSourceFile = input.SourceFile;
                        bool copyParams = input.CopyParams;

                        if (input.AutoSource)
                        {
                            fileSourceFile = this.editor.Meta.GetLink(Path.GetFileNameWithoutExtension(fileName));

                            if (string.IsNullOrEmpty(fileSourceFile))
                            {
                                copyParams = false;
                            }
                        }

                        this.ImportTexture(Path.GetFileNameWithoutExtension(fileName), fileName, fileSourceFile, copyParams, couldntFindThese);
                    }

                    this.LoadListView();

                    if (couldntFindThese.Count > 0)
                    {
                        if (couldntFindThese.Count > 10)
                        {
                            MessageBox.Show("Couldn't find " + couldntFindThese.Count + " original textures in " + (input.AutoSource ? "source files" : loadedAuxFile) + ". Used default parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string message = "Couldn't find these textures in " + (input.AutoSource ? "source files" : loadedAuxFile) + ":\n\n";

                            foreach (var tex in couldntFindThese)
                            {
                                message += tex + "\n";
                            }

                            message += "\nUsed default parameters.";

                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                var initial = Path.GetFileNameWithoutExtension(textures[0]);

                var preferredSourceFile = this.editor.Meta.GetLink(initial);

                if (!string.IsNullOrEmpty(preferredSourceFile))
                {
                    sourceFile = preferredSourceFile;
                }

                using var input = new TextureImport(initial, editor.GamePath, sourceFile, false);

                if (input.ShowDialog() == DialogResult.OK)
                {
                    var couldntFindThese = new List<string>();

                    this.ImportTexture(input.Value, textures[0], input.SourceFile, input.CopyParams, couldntFindThese);

                    this.LoadListView();

                    if (couldntFindThese.Count > 0)
                    {
                        MessageBox.Show("Couldn't find the original texture in " + loadedAuxFile + ". Used default parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            ForcedX.GCCollect();
        }

        private void TexEditorAddTextureItem_Click(object sender, EventArgs e)
        {
            if (this.AddTextureDialog.ShowDialog() == DialogResult.OK)
            {
                this.ImportMultipleTextures(this.AddTextureDialog.FileNames);
            }
        }

        private void TexEditorAddTextureFolderItem_Click(object sender, EventArgs e)
        {
            if (this.AddTextureFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var folderPath = this.AddTextureFolderDialog.SelectedPath;

                var textures = new List<string>();

                this.LookForTextures(folderPath, textures);

                List<string> duplicates = new List<string>();

                foreach (var texture in textures)
                {
                    var filename = Path.GetFileName(texture);

                    if (duplicates.Contains(filename))
                    {
                        continue;
                    }

                    foreach (var texture2 in textures)
                    {
                        if (texture == texture2)
                        {
                            continue;
                        }

                        var filename2 = Path.GetFileName(texture2);

                        if (filename == filename2)
                        {
                            duplicates.Add(filename);
                            break;
                        }
                    }
                }

                if (duplicates.Count > 0)
                {
                    if (duplicates.Count > 10)
                    {
                        MessageBox.Show("Found " + duplicates.Count + " duplicates in subfolders. Please remove them when importing a folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string message = "These textures have duplicates:\n\n";

                        foreach (var tex in duplicates)
                        {
                            message += tex + "\n";
                        }

                        message += "\nPlease remove duplicates from subfolders when importing the folder.";

                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.ImportMultipleTextures(textures.ToArray());
                }
            }
        }

        private void LookForTextures(string directoryPath, List<string> textures)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(directoryPath))
                {
                    this.LookForTextures(dir, textures);
                }

                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    string ext = Path.GetExtension(file);

                    if (ext.Equals(".dds", StringComparison.OrdinalIgnoreCase))
                    {
                        textures.Add(file);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        private void TexEditorRemoveTextureItem_Click(object sender, EventArgs e)
        {
            try
            {
                var arr = new int[this.TexEditorListView.SelectedIndices.Count];

                for (int i = 0; i < this.TexEditorListView.SelectedIndices.Count; i++)
                {
                    arr[i] = this.TexEditorListView.SelectedIndices[i];
                }

                arr = arr.OrderByDescending(x => x).ToArray();

                foreach (int index in arr)
                {
                    var key = this.TexEditorListView.Items[index].SubItems[1].Text.BinHash();
                    var tpkIndex = 0;

                    for (int i = 0; i < this.TPK.Length; i++)
                    {
                        var tpk = this.TPK[i];

                        if (tpk.FindTexture(key, KeyType.BINKEY) != null)
                        {
                            tpk.RemoveTexture(key, KeyType.BINKEY);
                            tpkIndex = i;
                            break;
                        }
                    }
                    this.GenerateRemoveTextureCommand($"0x{this.TexEditorListView.Items[index].SubItems[1].Text.BinHash():X8}", tpkIndex);

                    this.editor.Meta.DeleteTexture(key);

                    var totalTextureCount = 0;

                    foreach (var tpk in this.TPK)
                    {
                        totalTextureCount += tpk.TextureCount;
                    }

                    if (totalTextureCount == 0)
                    {
                        this.LoadListView();
                        this.TexEditorPropertyGrid.SelectedObject = null;
                        this.DisposeImage();
                        this.ToggleMenuStripControls();
                        return;
                    }
                }

                this.LoadListView();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.TexEditorListView.Items)
            {
                item.Selected = true;
            }
        }

        private void TexEditorExportAllItem_Click(object sender, EventArgs e)
        {
            using var browser = new FolderBrowserDialog()
            {
                AutoUpgradeEnabled = true,
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = true,
            };

            if (browser.ShowDialog() == DialogResult.OK)
            {
                foreach (int index in this.TexEditorListView.SelectedIndices)
                {
                    var key = this.TexEditorListView.Items[index].SubItems[1].Text.BinHash();
                    var texture = this.FindTexture(key);
                    var name = texture.BinKey == texture.CollectionName.BinHash() ? texture.CollectionName : $"0x{texture.BinKey:X8}";

                    this.editor.Meta.GetOrigName(key, ref name);

                    var path = Path.Combine(browser.SelectedPath, name) + ".dds";
                    var data = texture.GetDDSArray(false);
                    using var bw = new BinaryWriter(File.Open(path, FileMode.Create));
                    bw.Write(data);
                }

                MessageBox.Show($"Selected textures have been exported", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void TexEditorFindReplaceItem_Click(object sender, EventArgs e)
        {
            if (this.TexEditorListView.Items.Count == 0) return;

            using var with = new Input("Enter string to replace with");
            using var input = new Input("Enter string to search for",
                                        new Predicate<string>(_ => !String.IsNullOrEmpty(_)),
                                        "Input string cannot be null or empty");

            if (input.ShowDialog() == DialogResult.OK && with.ShowDialog() == DialogResult.OK)
            {

                using var check = new Check("Make case-sensitive replace?", false);

                if (check.ShowDialog() == DialogResult.OK)
                {

                    var options = check.Value
                        ? RegexOptions.Multiline | RegexOptions.CultureInvariant
                        : RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

                    this.TexEditorListView.BeginUpdate();

                    for (int j = 0; j < this.TPK.Length; j++)
                    {
                        var tpk = this.TPK[j];

                        for (int i = 0; i < tpk.TextureCount; ++i)
                        {
                            var texture = tpk.Textures[i];
                            var key = $"0x{texture.BinKey:X8}";
                            var oname = texture.CollectionName;
                            if (oname.Contains(' ')) oname = $"\"{oname}\"";

                            if (texture.BinKey != texture.CollectionName.BinHash()) continue;
                            var cname = Regex.Replace(texture.CollectionName, input.Value, with.Value, options);
                            if (cname == texture.CollectionName) continue;

                            var origName = this.editor.Meta.GetOrigName(texture.BinKey);
                            var oldName = texture.CollectionName;
                            var link = this.editor.Meta.GetLink(origName);

                            texture.CollectionName = cname;

                            this.editor.Meta.ChangeTextureNewName(origName, oldName, cname, link);

                            this.TexEditorListView.Items[i].SubItems[1].Text = cname;

                            this.GenerateUpdateTextureCommand(oname, "CollectionName", cname, j);
                        }
                    }

                    this.TexEditorListView.EndUpdate();
                    this.TexEditorPropertyGrid.Refresh();

                }

            }
        }

        private void TexEditorFindReplaceItem2_Click(object sender, EventArgs e)
        {
            if (this.TexEditorListView.Items.Count == 0) return;

            using var with = new Input("Enter string to replace with");
            using var input = new Input("Enter string to search for",
                                        new Predicate<string>(_ => !String.IsNullOrEmpty(_)),
                                        "Input string cannot be null or empty");

            if (input.ShowDialog() == DialogResult.OK && with.ShowDialog() == DialogResult.OK)
            {

                using var check = new Check("Make case-sensitive replace?", false);

                if (check.ShowDialog() == DialogResult.OK)
                {

                    var options = check.Value
                        ? RegexOptions.Multiline | RegexOptions.CultureInvariant
                        : RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

                    this.TexEditorListView.BeginUpdate();

                    for (int j = 0; j < this.TPK.Length; j++)
                    {
                        var tpk = this.TPK[j];

                        for (int i = 0; i < tpk.TextureCount; ++i)
                        {
                            var texture = tpk.Textures[i];
                            var key = $"0x{texture.BinKey:X8}";
                            var oname = this.editor.Meta.GetOrigName(texture.BinKey);
                            if (oname.Contains(' ')) oname = $"\"{oname}\"";

                            var cname = Regex.Replace(this.editor.Meta.GetOrigName(texture.BinKey), input.Value, with.Value, options);
                            if (cname == this.editor.Meta.GetOrigName(texture.BinKey)) continue;

                            var origName = this.editor.Meta.GetOrigName(texture.BinKey);
                            var newName = texture.CollectionName;
                            var link = this.editor.Meta.GetLink(origName);

                            texture.CollectionName = cname;

                            this.editor.Meta.ChangeTextureOrigName(cname, newName, link);

                            this.TexEditorListView.Items[i].SubItems[0].Text = cname;
                        }
                    }

                    this.TexEditorListView.EndUpdate();
                    this.TexEditorPropertyGrid.Refresh();

                }

            }
        }

        private void TexEditorHasherItem_Click(object sender, EventArgs e)
        {
            var hasher = new Hasher() { StartPosition = FormStartPosition.CenterScreen };
            this._openforms.Add(hasher);
            hasher.Show();
        }

        private void TexEditorRaiderItem_Click(object sender, EventArgs e)
        {
            var raider = new Raider() { StartPosition = FormStartPosition.CenterScreen };
            this._openforms.Add(raider);
            raider.Show();
        }

        #endregion

        #region List View

        ListViewItem previewItem;

        private void TexEditorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.changeDelayTimer == null)
            {
                this.changeDelayTimer = new Timer();
                this.changeDelayTimer.Tick += this.ChangeDelayTimerTick;
                this.changeDelayTimer.Interval = 200;
            }
            this.changeDelayTimer.Enabled = false;
            this.changeDelayTimer.Enabled = true;
        }

        private void ChangeDelayTimerTick(object sender, EventArgs e)
        {
            this.changeDelayTimer.Enabled = false;
            this.changeDelayTimer.Dispose();
            this.changeDelayTimer = null;

            if (this.TexEditorListView.SelectedItems.Count == 0)
            {
                previewItem = null;
                this.TexEditorPropertyGrid.SelectedObject = null;
                this.DisposeImage();
                this.panel1.AutoScroll = false;
                this.TexEditorImage.Width = this.panel1.Width;
                this.TexEditorImage.Height = this.panel1.Height;
                this.ToggleMenuStripControls();
                this.originalNameText.Enabled = false;
                this.originalNameText.Text = "";
                this.fromFileText.Enabled = false;
                this.fromFileText.Text = "";
                this.openOrigFileButton.Enabled = false;
                this.applyOrigParamsButton.Enabled = false;
                return;
            }

            previewItem = this.TexEditorListView.SelectedItems[0];

            var key = previewItem.SubItems[1].Text.BinHash();

            var texture = this.FindTexture(key);

            this.TexEditorPropertyGrid.SelectedObject = this.TexEditorListView.SelectedItems.Count == 1 ? texture : null;

            if (texture != null && this.TexEditorListView.SelectedItems.Count == 1 && this.splitContainer2.SplitterDistance < this.splitContainer2.Height - 20)
            {
                try
                {

                    var data = texture.GetDDSArray(true);
                    var image = new ILWrapper.Image(data);

                    using var ms = new MemoryStream();
                    image.Save(ms, ImageType.PNG);

                    this.DisposeImage();

                    this.TexEditorImage.BorderStyle = BorderStyle.None;
                    this.TexEditorImage.Image = Image.FromStream(ms);
                    this.TexEditorImage.BorderStyle = BorderStyle.FixedSingle;
                    this.panel1.AutoScroll = true;

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Unable to preview texture: {ex.GetLowestMessage()}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                this.DisposeImage();
                this.panel1.AutoScroll = false;
                this.TexEditorImage.Width = this.panel1.Width;
                this.TexEditorImage.Height = this.panel1.Height;
            }

            this.ToggleMenuStripControls();

            var origName = this.editor.Meta.GetOrigName(key);
            var link = this.editor.Meta.GetLink(origName);

            foreach (ListViewItem selected in this.TexEditorListView.SelectedItems)
            {
                var key2 = selected.SubItems[1].Text.BinHash();
                var origName2 = this.editor.Meta.GetOrigName(key2);
                var link2 = this.editor.Meta.GetLink(origName2);

                if (origName2 != origName)
                {
                    origName = "---";
                }

                if (link2 != link)
                {
                    link = "---";
                }
            }

            this.originalNameText.Enabled = this.editor.IsTexturePack && this.TexEditorListView.SelectedItems.Count == 1;
            this.originalNameText.Text = origName;

            this.fromFileText.Enabled = this.editor.IsTexturePack;
            this.fromFileText.Text = link;

            this.openOrigFileButton.Enabled = this.editor.IsTexturePack;
        }

        private void TexEditorListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.TexEditorListView.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void TexEditorListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Theme.Deserialize(Path.Combine("Themes", Configurations.Default.ThemeFile), out var theme);
            var brush = new SolidBrush(theme.Colors.TextBoxBackColor);
            e.Graphics.FillRectangle(brush, e.Bounds);
            e.DrawText();
        }

        private void TexEditorListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void TexEditorListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            uint key;
            int index;

            if (this.TexEditorPropertyGrid.SelectedObject is null)
            {

                key = 0xFFFFFFFF;
                index = -1;

            }
            else
            {

                key = ((Texture)this.TexEditorPropertyGrid.SelectedObject).BinKey;
                index = 0;

            }

            TPKBlock tpk = null;

            if (this.TPK.Length == 1)
            {
                tpk = this.TPK[0];
            }
            else
            {
                foreach (var tpk2 in this.TPK)
                {
                    if (tpk2.FindTexture(key, KeyType.BINKEY) != null)
                    {
                        tpk = tpk2;
                        break;
                    }
                }
            }

            switch (e.Column)
            {
                case 1: // BinKey
                    tpk.SortTexturesByType(false);

                    if (this._last_column_clicked == 1)
                    {

                        tpk.Textures.Reverse();
                        this._last_column_clicked = -1;

                    }
                    else this._last_column_clicked = 1;

                    if (index == 0) index = tpk.GetTextureIndex(key, KeyType.BINKEY);
                    this.LoadListView();
                    break;

                case 2: // CollectionName
                    tpk.SortTexturesByType(true);

                    if (this._last_column_clicked == 2)
                    {

                        tpk.Textures.Reverse();
                        this._last_column_clicked = -1;

                    }
                    else this._last_column_clicked = 2;

                    if (index == 0) index = tpk.GetTextureIndex(key, KeyType.BINKEY);
                    this.LoadListView();
                    break;

                default:
                    break;

            }
        }

        #endregion

        #region Events

        private void TexEditorPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var key = $"0x{this.TexEditorListView.SelectedItems[0].SubItems[1].Text.BinHash():X8}";

            if (e.ChangedItem.Label == nameof(Texture.ClassName) ||
                e.ChangedItem.Label == nameof(Texture.ClassKey) ||
                e.ChangedItem.Label == nameof(Texture.MipmapBiasInt) ||
                e.ChangedItem.Label == nameof(Texture.MipmapBiasType))
            {

                this.TexEditorPropertyGrid.Refresh();

            }
            else if (e.ChangedItem.Label == nameof(Texture.CollectionName))
            {
                var name = e.ChangedItem.Value.ToString();

                this.editor.Meta.ChangeTextureNewName(this.TexEditorListView.SelectedItems[0].SubItems[0].Text, this.TexEditorListView.SelectedItems[0].SubItems[1].Text, name, this.fromFileText.Text);

                this.TexEditorListView.SelectedItems[0].SubItems[1].Text = name;
                this.TexEditorPropertyGrid.Refresh();

            }

            int tpkIndex = 0;

            if (this.TPK.Length > 1)
            {
                for (int i = 0; i < this.TPK.Length; i++)
                {
                    if (this.TPK[i].FindTexture(this.TexEditorListView.SelectedItems[0].SubItems[1].Text.BinHash(), KeyType.BINKEY) != null)
                    {
                        tpkIndex = i;
                    }
                }
            }

            this.GenerateUpdateTextureCommand(key, e.ChangedItem.Label, e.ChangedItem.Value.ToString(), tpkIndex);
        }

        private void TextureEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DisposeImage();

            foreach (var form in this._openforms)
            {

                try { form.Close(); }
                catch { }

            }
        }

        #endregion

        #region Commands

        private void GenerateUpdateTextureCommand(string key, string property, string value, int tpkIndex)
        {
            if (property.Contains(' ')) property = $"\"{property}\"";
            if (value.Contains(' ')) property = $"\"{value}\"";
            var command = $"{eCommandType.update_texture} {this._tpkpath[tpkIndex]} {key} {property} {value}";
            this.Commands.Add(command);
        }

        private void GenerateAddTextureCommand(string name, string file, int tpkIndex)
        {
            if (name.Contains(' ')) name = $"\"{name}\"";
            if (file.Contains(' ')) file = $"\"{file}\"";
            var command = $"{eCommandType.add_texture} {this._tpkpath[tpkIndex]} {name} {file}";
            this.Commands.Add(command);
        }

        private void GenerateRemoveTextureCommand(string key, int tpkIndex)
        {
            var command = $"{eCommandType.remove_texture} {this._tpkpath[tpkIndex]} {key}";
            this.Commands.Add(command);
        }

        private void GenerateReplaceTextureCommand(string key, string file, int tpkIndex)
        {
            if (file.Contains(' ')) file = $"\"{file}\"";
            var command = $"{eCommandType.replace_texture} {this._tpkpath[tpkIndex]} {key} {file}";
            this.Commands.Add(command);
        }

        #endregion

        private void openOrigFileButton_Click(object sender, EventArgs e)
        {
            if (!this.editor.IsTexturePack || this.TexEditorListView.SelectedItems.Count == 0)
            {
                return;
            }

            using var dialog = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Bundle File|*.bun;*.bin;*.lzc|All Files|*.*",
                Multiselect = false,
                Title = "Pick source file",
                InitialDirectory = editor.GamePath
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var newPath = dialog.FileName;

                if (!newPath.StartsWith(editor.GamePath))
                {
                    MessageBox.Show("Provided file is outside of the game directory. This is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.fromFileText.Text = Path.GetRelativePath(editor.GamePath, newPath);
            }
        }

        private void applyOrigParamsButton_Click(object sender, EventArgs e)
        {
            if (!this.editor.IsTexturePack || this.TexEditorListView.SelectedItems.Count == 0)
            {
                return;
            }

            if (!this.LoadAuxFile(this.fromFileText.Text))
            {
                return;
            }

            List<string> couldntFindThese = new List<string>();

            foreach (ListViewItem selected in this.TexEditorListView.SelectedItems)
            {
                if (selected.SubItems[0].Text == "-----")
                {
                    continue;
                }

                if (!this.CopyAuxParams(selected.SubItems[0].Text, selected.SubItems[1].Text))
                {
                    couldntFindThese.Add(selected.SubItems[0].Text);
                }
            }

            if (couldntFindThese.Count > 0)
            {
                if (couldntFindThese.Count > 10)
                {
                    MessageBox.Show("Couldn't find " + couldntFindThese.Count + " original textures in " + loadedAuxFile + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string message = "Couldn't find these textures in " + loadedAuxFile + ":\n";

                    foreach (var tex in couldntFindThese)
                    {
                        message += "\n" + tex;
                    }

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void originalNameText_TextChanged(object sender, EventArgs e)
        {
            this.applyOrigParamsButton.Enabled = this.editor.IsTexturePack && !string.IsNullOrEmpty(this.originalNameText.Text) && !string.IsNullOrEmpty(this.fromFileText.Text) && File.Exists(Path.Combine(editor.GamePath, this.fromFileText.Text));

            if (!this.editor.IsTexturePack || this.TexEditorListView.SelectedItems.Count != 1)
            {
                return;
            }

            if (this.originalNameText.Text == "---")
            {
                return;
            }

            this.editor.Meta.ChangeTextureOrigName(this.originalNameText.Text, this.TexEditorListView.SelectedItems[0].SubItems[1].Text, this.fromFileText.Text == "---" ? this.editor.Meta.GetLink(this.editor.Meta.GetOrigName(this.TexEditorListView.SelectedItems[0].SubItems[1].Text)) : this.fromFileText.Text);

            this.TexEditorListView.SelectedItems[0].SubItems[0].Text = this.originalNameText.Text;
        }

        private void fromFileText_TextChanged(object sender, EventArgs e)
        {
            this.applyOrigParamsButton.Enabled = this.editor.IsTexturePack && !string.IsNullOrEmpty(this.originalNameText.Text) && !string.IsNullOrEmpty(this.fromFileText.Text) && File.Exists(Path.Combine(editor.GamePath, this.fromFileText.Text));

            if (!this.editor.IsTexturePack || this.TexEditorListView.SelectedItems.Count == 0)
            {
                return;
            }

            if (this.fromFileText.Text == "---")
            {
                return;
            }

            foreach (ListViewItem selected in this.TexEditorListView.SelectedItems)
            {
                if (selected.SubItems[0].Text == "-----")
                {
                    continue;
                }

                this.editor.Meta.ChangeTextureLink(selected.SubItems[0].Text, this.fromFileText.Text);
            }
        }

        private void SplitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Configurations.Default.TexSplitterDistance = this.splitContainer2.SplitterDistance;

            this.TexEditorListView_SelectedIndexChanged(sender, new EventArgs());
        }
    }
}
