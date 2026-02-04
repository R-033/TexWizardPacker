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
using Nikki.Utils;
using Nikki.Utils.EA;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private TPKBlock TPK { get; }
		private readonly List<Form> _openforms;
		private readonly string _tpkpath;
		public List<string> Commands { get; }
		private int _last_column_clicked = -1;

        private Color HighlightColor { get; set; }

        private Editor editor;

        public TextureEditor(Editor parent, TPKBlock tpk, string path)
		{
            this.editor = parent;
			this.InitializeComponent();
			this.TPK = tpk;
			this._tpkpath = path;
			this._openforms = new List<Form>();
			this.Commands = new List<string>();
			this.Text = $"Texture Editor : {this.TPK.CollectionName}";
			this.TexEditorImage.BackColor = Color.FromArgb(0, 0, 0, 0);
			this.TexEditorImage.BorderStyle = BorderStyle.FixedSingle;
			this.TexEditorImage.Width = this.panel1.Width;
			this.TexEditorImage.Height = this.panel1.Height;
			this.TexEditorListView.Columns[^1].Width = -2;
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
			this.TexEditorCopyTextureItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorCopyTextureItem.ForeColor = theme.Colors.MenuItemForeColor;
			this.TexEditorExportAllItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorExportAllItem.ForeColor = theme.Colors.MenuItemForeColor;
			this.TexEditorFindReplaceItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorFindReplaceItem.ForeColor = theme.Colors.MenuItemForeColor;
			this.TexEditorHasherItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorHasherItem.ForeColor = theme.Colors.MenuItemForeColor;
			this.TexEditorRaiderItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorRaiderItem.ForeColor = theme.Colors.MenuItemForeColor;
			this.TexEditorRemoveTextureItem.BackColor = theme.Colors.MenuItemBackColor;
			this.TexEditorRemoveTextureItem.ForeColor = theme.Colors.MenuItemForeColor;

            // Highlight color
            this.HighlightColor = theme.DarkTheme
                ? Color.FromArgb(70, 0, 20) 
                : Color.FromArgb(255, 100, 100);
        }

        #endregion

        #region Methods

        private void LoadListView(int index = -1)
		{
			this.TexEditorListView.Items.Clear();
			var list = this.TPK.GetTextures();
			this.TexEditorListView.BeginUpdate();

			foreach (var texture in list)
			{
                string originalName = "-----";
                string newName = texture.BinKey != texture.CollectionName.BinHash() ? $"0x{texture.BinKey:X8}" : texture.CollectionName;

                for (int i = 0; i < editor.Meta.textures.Count; i++)
                {
                    if (editor.Meta.textures[i][1].BinHash() == texture.BinKey)
                    {
                        originalName = editor.Meta.textures[i][0];
                        newName = editor.Meta.textures[i][1];
                        break;
                    }
                }

                var item = new ListViewItem
                {
                    Text = originalName
                };

                if (editor.IsTexturePack && (originalName == "-----" || originalName == newName))
                {
                    item.BackColor = HighlightColor;
                }

                item.SubItems.Add(newName);

				this.TexEditorListView.Items.Add(item);

			}

			this.TexEditorListView.EndUpdate();

			if (index < 0 || index >= this.TexEditorListView.Items.Count) return;

			this.TexEditorListView.Items[index].Selected = true;
			this.TexEditorListView.Select();
			this.TexEditorListView.HideSelection = false;
			this.TexEditorListView.Items[index].EnsureVisible();
		}

		private void ToggleMenuStripControls()
		{
            this.TexEditorRemoveTextureItem.Enabled = this.TexEditorListView.SelectedItems.Count > 0;
            this.TexEditorCopyTextureItem.Enabled = this.TexEditorListView.SelectedItems.Count == 1;
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
                    if (loadedAuxFile != sourceFile)
                    {
                        loadedAuxFile = sourceFile;

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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            auxProfile = null;
                        }
                    }
                }

                var newName = "_" + textureName; // todo

                if (!editor.IsTexturePack)
                {
                    newName = textureName;
                }

                var prevTexture = this.TPK.FindTexture(newName.BinHash(), KeyType.BINKEY);

                if (prevTexture != null)
                {
                    prevTexture.Reload(filePath);
                    this.GenerateReplaceTextureCommand(newName, filePath);
                }
                else
                {
                    this.TPK.AddTexture(newName, filePath);
                    this.GenerateAddTextureCommand(newName, filePath);
                }

                bool copied = false;

                if (copyParams)
                {
                    if (auxProfile != null)
                    {
                        Texture origTex = FindAuxTexture(textureName);

                        if (origTex != null)
                        {
                            var newTex = this.TPK.FindTexture(newName.BinHash(), KeyType.BINKEY);

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

                            copied = true;
                        }
                    }
                }

                if (!copied)
                {
                    if (copyParams && auxProfile != null)
                    {
                        couldntFindThese.Add(textureName);
                    }

                    this.TPK.FindTexture(newName.BinHash(), KeyType.BINKEY).RenderingOrder = 0;
                    this.GenerateUpdateTextureCommand(newName, "RenderingOrder", "0");
                }

                if (editor.IsTexturePack)
                {
                    bool found = false;

                    for (int j = 0; j < editor.Meta.textures.Count; j++)
                    {
                        if (editor.Meta.textures[j][0].BinHash() == textureName.BinHash())
                        {
                            editor.Meta.textures[j][1] = newName;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        editor.Meta.textures.Add(new string[] { textureName, newName });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Menu Strip

        private void TexEditorAddTextureItem_Click(object sender, EventArgs e)
		{
			if (this.AddTextureDialog.ShowDialog() == DialogResult.OK)
			{
                if (this.AddTextureDialog.FileNames.Length > 1)
                {
                    using var input = new TextureImport($"({this.AddTextureDialog.FileNames.Length} textures)", editor.GamePath, editor.GameType, true);

                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        var couldntFindThese = new List<string>();

                        foreach (var fileName in this.AddTextureDialog.FileNames)
                        {
                            this.ImportTexture(Path.GetFileNameWithoutExtension(fileName), fileName, input.SourceFile, input.CopyParams, couldntFindThese);
                        }

                        if (this.TexEditorListView.SelectedIndices.Count > 0)
                        {
                            this.LoadListView(this.TexEditorListView.SelectedIndices[0]);
                        }
                        else
                        {
                            this.LoadListView();
                        }

                        if (couldntFindThese.Count > 0)
                        {
                            if (couldntFindThese.Count > 10)
                            {
                                MessageBox.Show("Couldn't find " + couldntFindThese.Count + " original textures in " + loadedAuxFile + ". Used default parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string message = "Couldn't find these textures in " + loadedAuxFile + ":\n\n";

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
                    var initial = Path.GetFileNameWithoutExtension(this.AddTextureDialog.FileName);
                    using var input = new TextureImport(initial, editor.GamePath, editor.GameType, false);

                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        var couldntFindThese = new List<string>();

                        this.ImportTexture(input.Value, this.AddTextureDialog.FileName, input.SourceFile, input.CopyParams, couldntFindThese);

                        if (this.TexEditorListView.SelectedIndices.Count > 0)
                        {
                            this.LoadListView(this.TexEditorListView.SelectedIndices[0]);
                        }
                        else
                        {
                            this.LoadListView();
                        }

                        if (couldntFindThese.Count > 0)
                        {
                            MessageBox.Show("Couldn't find the original texture in " + loadedAuxFile + ". Used default parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
				    this.TPK.RemoveTexture(key, KeyType.BINKEY);
				    this.GenerateRemoveTextureCommand($"0x{this.TexEditorListView.Items[index].SubItems[1].Text.BinHash():X8}");

                    if (this.TPK.TextureCount == 0)
				    {

					    this.LoadListView();
					    this.TexEditorPropertyGrid.SelectedObject = null;
					    this.DisposeImage();
					    this.ToggleMenuStripControls();
					    return;
				    }
                }

				if (this.TexEditorListView.SelectedIndices[0] == 0) this.LoadListView(0);
				else this.LoadListView(this.TexEditorListView.SelectedIndices[0] - 1);

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
		}

		private void TexEditorCopyTextureItem_Click(object sender, EventArgs e)
		{
			using var input = new Input("Enter name of the new texture");

			while (true) // use loop instead of recursion to prevent stack overflow
			{

				if (input.ShowDialog() == DialogResult.OK)
				{

					try
					{

						var index = this.TexEditorListView.SelectedIndices[0];
						var key = this.GetSelectedKey();
						this.TPK.CloneTexture(input.Value, key, KeyType.BINKEY);
						this.GenerateCopyTextureCommand($"0x{this.TexEditorListView.Items[index].SubItems[1].Text.BinHash():X8}", input.Value);
						this.LoadListView(index);
						break;

					}
					catch (Exception ex)
					{

						MessageBox.Show(ex.GetLowestMessage(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					}

				}
				else
				{

					break;

				}

			}
		}

		private void TexEditorExportAllItem_Click(object sender, EventArgs e)
		{
			using var browser = new FolderBrowserDialog()
			{
				AutoUpgradeEnabled = false,
				Description = "Select directory where selected textures should be exported.",
				RootFolder = Environment.SpecialFolder.MyComputer,
				ShowNewFolderButton = true,
			};

			if (browser.ShowDialog() == DialogResult.OK)
			{
                foreach (int index in this.TexEditorListView.SelectedIndices)
                {
                    var key = this.TexEditorListView.Items[index].SubItems[1].Text.BinHash();
                    var texture = this.TPK.FindTexture(key, KeyType.BINKEY);
                    var name = texture.BinKey == texture.CollectionName.BinHash() ? texture.CollectionName : $"0x{texture.BinKey:X8}";

                    for (int j = 0; j < editor.Meta.textures.Count; j++)
                    {
                        if (editor.Meta.textures[j][1].BinHash() == texture.BinKey)
                        {
                            name = editor.Meta.textures[j][0];
                            break;
                        }
                    }

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

					for (int i = 0; i < this.TPK.TextureCount; ++i)
					{

						var texture = this.TPK.Textures[i];
						var key = $"0x{texture.BinKey:X8}";
						var oname = texture.CollectionName;
						if (oname.Contains(' ')) oname = $"\"{oname}\"";

						if (texture.BinKey != texture.CollectionName.BinHash()) continue;
						var cname = Regex.Replace(texture.CollectionName, input.Value, with.Value, options);
						if (cname == texture.CollectionName) continue;

						texture.CollectionName = cname;

                        string originalName = "-----";
                        string newName = texture.CollectionName;

                        for (int j = 0; j < editor.Meta.textures.Count; j++)
                        {
                            if (editor.Meta.textures[j][1].BinHash() == texture.BinKey)
                            {
                                originalName = editor.Meta.textures[j][0];
                                newName = editor.Meta.textures[j][1];
                                break;
                            }
                        }

                        this.TexEditorListView.Items[i].SubItems[0].Text = originalName;
						this.TexEditorListView.Items[i].SubItems[1].Text = newName;

						this.GenerateUpdateTextureCommand(oname, "CollectionName", cname);

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
			if (this.TexEditorListView.SelectedItems.Count == 0)
			{
                previewItem = null;
                this.TexEditorPropertyGrid.SelectedObject = null;
				this.DisposeImage();
				this.panel1.AutoScroll = false;
				this.TexEditorImage.Width = this.panel1.Width;
				this.TexEditorImage.Height = this.panel1.Height;
				this.ToggleMenuStripControls();
				return;

			}

			var item = this.TexEditorListView.SelectedItems[0];

            if (previewItem == item)
            {
                return;
            }

            previewItem = item;

            var key = item.SubItems[1].Text.BinHash();

            var texture = this.TPK.FindTexture(key, KeyType.BINKEY);

			if (texture == null) return;

			this.TexEditorPropertyGrid.SelectedObject = texture;

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

			this.ToggleMenuStripControls();
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

			switch (e.Column)
			{
				case 1: // BinKey
					this.TPK.SortTexturesByType(false);

					if (this._last_column_clicked == 1)
					{

						this.TPK.Textures.Reverse();
						this._last_column_clicked = -1;

					}
					else this._last_column_clicked = 1;
						
					if (index == 0) index = this.TPK.GetTextureIndex(key, KeyType.BINKEY);
					this.LoadListView(index);
					break;

				case 2: // CollectionName
					this.TPK.SortTexturesByType(true);
					
					if (this._last_column_clicked == 2)
					{

						this.TPK.Textures.Reverse();
						this._last_column_clicked = -1;

					}
					else this._last_column_clicked = 2;

					if (index == 0) index = this.TPK.GetTextureIndex(key, KeyType.BINKEY);
					this.LoadListView(index);
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

                string originalName = "-----";
                string newName = name;

                for (int j = 0; j < editor.Meta.textures.Count; j++)
                {
                    if (editor.Meta.textures[j][1].BinHash() == name.BinHash())
                    {
                        originalName = editor.Meta.textures[j][0];
                        newName = editor.Meta.textures[j][1];
                        break;
                    }
                }

                this.TexEditorListView.SelectedItems[0].SubItems[0].Text = originalName;
                this.TexEditorListView.SelectedItems[0].SubItems[1].Text = newName;
				this.TexEditorPropertyGrid.Refresh();

			}

			this.GenerateUpdateTextureCommand(key, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
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

		private void GenerateUpdateTextureCommand(string key, string property, string value)
		{
			if (property.Contains(' ')) property = $"\"{property}\"";
			if (value.Contains(' ')) property = $"\"{value}\"";
			var command = $"{eCommandType.update_texture} {this._tpkpath} {key} {property} {value}";
			this.Commands.Add(command);
		}

		private void GenerateAddTextureCommand(string name, string file)
		{
			if (name.Contains(' ')) name = $"\"{name}\"";
			if (file.Contains(' ')) file = $"\"{file}\"";
			var command = $"{eCommandType.add_texture} {this._tpkpath} {name} {file}";
			this.Commands.Add(command);
		}

		private void GenerateRemoveTextureCommand(string key)
		{
			var command = $"{eCommandType.remove_texture} {this._tpkpath} {key}";
			this.Commands.Add(command);
		}

		private void GenerateCopyTextureCommand(string key, string name)
		{
			var command = $"{eCommandType.copy_texture} {this._tpkpath} {key} {name}";
			this.Commands.Add(command);
		}

		private void GenerateReplaceTextureCommand(string key, string file)
		{
			if (file.Contains(' ')) file = $"\"{file}\"";
			var command = $"{eCommandType.replace_texture} {this._tpkpath} {key} {file}";
			this.Commands.Add(command);
		}

		private void GenerateBindTexturesCommand(SerializeType type, string directory)
		{
			string import = type.ToString().ToLowerInvariant();
			if (directory.Contains(' ')) directory = $"\"{directory}\"";
			var command = $"{eCommandType.bind_textures} {import} {this._tpkpath} {directory}";
			this.Commands.Add(command);
		}

		#endregion
	}
}
