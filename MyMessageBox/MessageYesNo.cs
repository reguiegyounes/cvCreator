using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CV_creator.MyMessageBox
{
    public partial class MessageYesNo : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;
        private string _text = "";
        private string _title = "";
        public bool Resultat = false;

        public MessageYesNo(string text, string title, Image messageIcon)
        {

            InitializeComponent();
            _text = txt.Text = text;
            _title = label1.Text = title;
            pictureBox.Image = messageIcon;

            ChangeLayout(Properties.Settings.Default.IsArabic);


            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);


            txt.Text = text;
        }
        public MessageYesNo(string text)
        {

            InitializeComponent();

            _text = txt.Text = text;
            _title = label1.Text = "";

            ChangeLayout(Properties.Settings.Default.IsArabic);


            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);



        }


        //
        // Move Form
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Opacity = .90;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                this.Opacity = .99;
            }
        }

        //
        // Resize Form
        private void ResizeFontControls()
        {
            _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _currentFontSize = (_currentScreenWidth * Properties.Settings.Default.OriginalFontSize) / Properties.Settings.Default.OriginalScreenWidth;
            float width = (_currentScreenWidth * 450) / Properties.Settings.Default.OriginalScreenWidth;
            float height = (_currentScreenWidth * 250) / Properties.Settings.Default.OriginalScreenWidth;

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
                this.Width = 450;
                this.Height = 250;
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
                this.Width = 450;
                this.Height = 250;
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
            RightToLeftLayoutPanel(panelBottom, isRightToLeft);
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



        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Resultat = false;
            this.Close();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            Resultat = false;
            this.Close();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            Resultat = true;
            this.Close();
        }
    }
}
