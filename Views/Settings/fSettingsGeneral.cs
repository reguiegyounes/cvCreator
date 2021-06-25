using CV_creator.MyMessageBox;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CV_creator.Views.Settings
{
    public partial class fSettingsGeneral : Form
    {
        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;

        public fSettingsGeneral()
        {
            InitializeComponent();
            ChangeLayout(Properties.Settings.Default.IsArabic);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            txtSaveCVs.RightToLeft = RightToLeft.No;
            cmbNotafication.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.Notafication);
            cmbResolution.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.ResizeForms);
            txtSaveCVs.Text = Properties.Settings.Default.DirectorySaveCv;
        }
        //
        // Resize Form
        private void ResizeFontControls()
        {
            _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _currentFontSize = (_currentScreenWidth * Properties.Settings.Default.OriginalFontSize) / Properties.Settings.Default.OriginalScreenWidth;
            float width = (_currentScreenWidth * 1060) / Properties.Settings.Default.OriginalScreenWidth;
            float height = (_currentScreenWidth * 660) / Properties.Settings.Default.OriginalScreenWidth;

            // Resize Form

            this.Font = new Font(this.Font.Name, _currentFontSize);
            
            this.Width = (int)width;
            this.Height = (int)height;

            // Resize Controls Custtom



        }
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ResizeForms)
            {
                ResizeFontControls();
            }
            else
            {
                this.Width = 1060;
                this.Height = 660;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ResizeForms)
            {
                ResizeFontControls();
            }
            else
            {
                this.Width = 1060;
                this.Height = 660;
            }
        }

        // 
        // Right to left 
        public void RightToLeftLayoutPanel(Panel panel, bool rightToLeft)
        {
            if ((panel.RightToLeft == RightToLeft.Yes && rightToLeft)
                || (panel.RightToLeft == RightToLeft.No && !rightToLeft))
            {
                return;
            }
            else if (!rightToLeft)
            {
                panel.RightToLeft = RightToLeft.No;
            }
            else
            {
                panel.RightToLeft = RightToLeft.Yes;
            }

            foreach (Control item in panel.Controls)
            {
                try
                {
                    item.Location = new Point(panel.Size.Width - item.Size.Width - item.Location.X, item.Location.Y);

                    if (item.Dock == DockStyle.None)
                    {
                        if (item.Anchor == (AnchorStyles.Top | AnchorStyles.Right))
                        {
                            item.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        }
                        else if (item.Anchor == (AnchorStyles.Bottom | AnchorStyles.Right))
                        {
                            item.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

                        }
                        else if (item.Anchor == (AnchorStyles.Top | AnchorStyles.Left))
                        {
                            item.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        }
                        else if (item.Anchor == (AnchorStyles.Bottom | AnchorStyles.Left))
                        {
                            item.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                        }

                    }
                }
                catch { }
            }
        }
        public void ChangeLayout(bool isRightToLeft)
        {

            RightToLeftLayoutPanel(panelTop, isRightToLeft);
            RightToLeftLayoutPanel(panelBody, isRightToLeft);

            this.RightToLeftLayout = isRightToLeft;
            if (isRightToLeft)
            {
                this.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
            }
        }

        //-----------------------------------------------------
        //
        // Events
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-------

        private void cmbNotafication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotafication.SelectedIndex == 0)
            {
                Properties.Settings.Default["Notafication"] = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default["Notafication"] = true;
                Properties.Settings.Default.Save();
            }
        }

        private void btnBrowseCVs_Click(object sender, EventArgs e)
        {
            string directoryOld = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv;
            string directoryNew;
            FolderBrowserDialog f = new FolderBrowserDialog();


            if (f.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["DirectorySaveCv"] = f.SelectedPath;
                Properties.Settings.Default.Save();
                directoryNew = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv;
                if (Directory.Exists(directoryOld) && directoryOld != directoryNew)
                {
                    Directory.Move(directoryOld, directoryNew);

                }
                new MessageOk(directoryNew, Words.ChangeDirectory, MessageIcon.Information).ShowDialog();
                txtSaveCVs.Text = Properties.Settings.Default.DirectorySaveCv;
            }
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResolution.SelectedIndex == 0)
            {
                Properties.Settings.Default["ResizeForms"] = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default["ResizeForms"] = true;
                Properties.Settings.Default.Save();
            }
        }
    }
}
