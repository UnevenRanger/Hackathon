using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class textEditor : Form
    {
        private int TabCount = 0;
        private int currentCharacter;
        private bool bold = false;
        private bool italic = false;
        private bool strike = false;
        private bool underline = false;
        private bool uppercase = false;
        private bool lowercase = false;

        public textEditor()
        {
            InitializeComponent();

            AddTab();
        }

        #region Methods

        #region Tabs 
        private void AddTab()
        {
            RichTextBox Body = new RichTextBox(); Body.Name = "Body"; Body.Dock = DockStyle.Fill; Body.ContextMenuStrip = contextMenuStrip1;
            TabPage NewPage = new TabPage();
            TabCount += 1;
            string DocumentText = "Document " + TabCount;
            NewPage.Name = DocumentText;
            NewPage.Text = DocumentText;
            NewPage.Controls.Add(Body);
            tabControl1.TabPages.Add(NewPage);
        }

        
        private void RemoveTab()
        {
            if (tabControl1.TabPages.Count != 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AddTab();
            }

        }
        private void RemoveAllTabs()
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(Page);
            }
            AddTab();
        }
        private void RemoveAllTabsButThis()
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                if (Page.Name != tabControl1.SelectedTab.Name)
                {
                    tabControl1.TabPages.Remove(Page);
                }
            }
        }
        #endregion

        #region SaveAndOpen 
        private void Save()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf"; saveFileDialog1.Title = "Save";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void SaveAs()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*";
            saveFileDialog1.Title = "Save As";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void Open()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.Length > 9)
                {
                    GetCurrentDocument.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }
        #endregion

        #region TextStyles

        private void Bold(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void Italic(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void Strike(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Strikeout;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void Underline(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void Captialise()
        {
            RichTextBox richTextBox = GetCurrentDocument;

            string copy = richTextBox.SelectedText;

            copy = copy.ToUpper();

            richTextBox.SelectedText = copy;
        }

        private void SmallCase()
        {
            RichTextBox richTextBox = GetCurrentDocument;

            string copy = richTextBox.SelectedText;

            copy = copy.ToLower();

            richTextBox.SelectedText = copy;
        }

        private void IncreaseFont(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Bold;
                }
                else if(richTextBox.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Italic;
                }
                else if (richTextBox.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Strikeout;
                }
                else if (richTextBox.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Underline;
                }
                else
                {
                    newFontStyle = FontStyle.Regular;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size + 1,
                   newFontStyle
                );
            }
        }

        private void DecreaseFont(RichTextBox textBox)
        {
            RichTextBox richTextBox = textBox;

            if (richTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Bold;
                }
                else if (richTextBox.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Italic;
                }
                else if (richTextBox.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Strikeout;
                }
                else if (richTextBox.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Underline;
                }
                else
                {
                    newFontStyle = FontStyle.Regular;
                }

                richTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size - 1,
                   newFontStyle
                );
            }
        }

        private void TextColour(string colour)
        {
            RichTextBox richTextBox = GetCurrentDocument;

            if (colour == "black")
            {
                richTextBox.ForeColor = Color.Black;
            }
            else if (colour == "white")
            {
                richTextBox.ForeColor = Color.White;
            }

            else if (colour == "red")
            {
                richTextBox.ForeColor = Color.Firebrick;
            }
        }

        private void HighlightColour(string colour)
        {
            RichTextBox richTextBox = GetCurrentDocument;

            if(colour == "green")
            {
                richTextBox.BackColor = Color.LimeGreen;
            }
            else if(colour == "blue")
            {
                richTextBox.BackColor = Color.SkyBlue;
            }

            else if(colour == "purple")
            {
                richTextBox.BackColor = Color.MediumPurple;
            }
        }

        private void Cut()
        {
            RichTextBox richTextBox = GetCurrentDocument;

            richTextBox.Cut();
        }

        private void Copy()
        {
            RichTextBox richTextBox = GetCurrentDocument;

            richTextBox.Copy();
        }

        private void Paste()
        {
            RichTextBox richTextBox = GetCurrentDocument;
            
            richTextBox.Paste();
        }

        #endregion

        #region Properties 
        private RichTextBox GetCurrentDocument
        {
            get
            {
                return (RichTextBox)tabControl1.SelectedTab.Controls["Body"];
            }
        }
        #endregion

        #endregion

        #region Listeners

        private void Body_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox) sender;

            if(e.KeyCode == Keys.V && e.Modifiers == Keys.LControlKey)
            {
                Paste();
            }

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.LControlKey)
            {
                Copy();
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void RemoveTabButton_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            Bold(richTextBox);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            Italic(richTextBox);
        }

        private void strikeOutButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            Strike(richTextBox);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            Underline(richTextBox);
        }

        private void uppercaseButton_Click(object sender, EventArgs e)
        {
            Captialise();
        }

        private void lowercaseButton_Click(object sender, EventArgs e)
        {
            SmallCase();
        }

        private void increaseSizeButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            IncreaseFont(richTextBox);
        }

        private void decreaseSizeButton_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetCurrentDocument;
            DecreaseFont(richTextBox);
        }

        private void GreenHighlight_Click(object sender, EventArgs e)
        {
            HighlightColour("green");
        }

        private void BlueHighlight_Click(object sender, EventArgs e)
        {
            HighlightColour("blue");
        }

        private void RedHighlight_Click(object sender, EventArgs e)
        {
            HighlightColour("purple");
        }

        private void Black_Click(object sender, EventArgs e)
        {
            TextColour("black");
        }

        private void White_Click(object sender, EventArgs e)
        {
            TextColour("white");
        }

        private void Red_Click(object sender, EventArgs e)
        {
            TextColour("red");
        }

        #endregion

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            HighlightColour("purple");
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }
    }
}