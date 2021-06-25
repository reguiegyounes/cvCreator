using CV_creator.MyMessageBox;
using CV_creator.Properties;
using CV_creator.Views.CV_generator;
using CV_creator.Views.Persons_and_CVs;
using CV_creator.Views.Settings;
using FastReport.DevComponents.DotNetBar;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CV_creator
{
    public partial class fHome : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private Form activateForm;
        private string activateFormName="";

        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;

        public fHome()
        {
            InitializeComponent();
            ChangeLayout(Properties.Settings.Default.IsArabic);
            //InitializeComponentPlus();
           
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            
            

            Helper.CreateStandartImage();
            if (Properties.Settings.Default.DirectorySaveCv == "")
            {
                DirectoryInfo i = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                Properties.Settings.Default["DirectorySaveCv"] = i.Parent.FullName + @"\" + i.Name;
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.DirectorySaveBackupCv == "")
            {
                DirectoryInfo i = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                Properties.Settings.Default["DirectorySaveBackupCv"] = i.Parent.FullName + @"\" + i.Name;
                Properties.Settings.Default.Save();
            }

            if (activateFormName != "fHomeBody")
            {
                FormHomeBodyChild();
                activateFormName = "fHomeBody";
            }
        }
        private void InitializeComponentPlus()
        {
            // Form
            this.BackColor = Theme.Secondary;
            //Panel
            panelSide.BackColor = Theme.Primary;
            panelLogo.BackColor = Theme.Primary;
            panelSideMenu.BackColor = Theme.Primary;
            panelPowerOff.BackColor = Theme.Primary;

            panelTop.BackColor = Theme.Accent;
            panelBody.BackColor = Theme.Secondary;

            //Button


            //TextBox
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
        private void ResizeFontAllControls()
        {
            _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _currentFontSize = (_currentScreenWidth * Properties.Settings.Default.OriginalFontSize) / Properties.Settings.Default.OriginalScreenWidth;

            // Resize Form
            this.Font = new Font(this.Font.Name, _currentFontSize);
            ResizeJustForm();

            // Resize Controls Custtom

        }
        private void ResizeJustForm()
        {
            _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            float width = (_currentScreenWidth * 1300) / Properties.Settings.Default.OriginalScreenWidth;
            float height = (_currentScreenWidth * 700) / Properties.Settings.Default.OriginalScreenWidth;

            // Resize Form
            this.Location = new System.Drawing.Point(50, 50);
            this.Width = (int)width;
            this.Height = (int)height;
            
        }
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ResizeForms)
            {
                ResizeFontAllControls();
            }
            else
            {
                this.Width = 1300;
                this.Height = 700;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ResizeForms)
            {
                ResizeFontAllControls();
            }
            else
            {
                this.Width = 1300;
                this.Height = 700;
            }
        }

        //
        // Change Form Body
        private void FormChild(Form form)
        {
            if (activateForm != null)
            {
                activateForm.Close();
                panelBody.Controls.Clear();
                activateFormName = "";
            }
            activateForm = form;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            activateForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChild_FormClosed);
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;
            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormHomeBodyChild()
        {
            fHomeBody form = new fHomeBody();
            form.panelBody.DoubleClick += delegate (object sender, EventArgs e)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    pictureBoxMaximize.Visible = false;
                    pictureBoxRestore.Visible = true;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    pictureBoxMaximize.Visible = true;
                    pictureBoxRestore.Visible = false;

                }
            };
            if (activateForm != null)
            {
                activateForm.Close();
                panelBody.Controls.Clear();
                activateFormName = "";
            }
            activateForm = form;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            activateForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChild_FormClosed);
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;
            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormPersonChild()
        {
            fPersons form = new fPersons();
            form.btnCreate.Click += delegate (object sender, EventArgs e)
            {
                if (form.dgv.Rows.Count != 0)
                {
                    string id = form.dgv.SelectedRows[0].Cells[0].Value.ToString();
                    string personName = form.nameEn = form.dgv.SelectedRows[0].Cells[1].Value.ToString();
                    string directoryFiles = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + @"\" + id + " " + personName;
                    Helper.CreateDlls();
                    Helper.CreateStandartImage();
                    FormCvlChild(form.idPerson, form.nameEn, form.nameAr, form.fileNameImage, directoryFiles);
                }
                else
                {
                    new MessageOk(Words.AddPersonFirst, Words.Error, MessageIcon.Error).ShowDialog();
                }
            };
            form.dgv.DoubleClick += delegate (object sender, EventArgs e)
            {
                if (form.dgv.Rows.Count != 0)
                {
                    string id = form.dgv.SelectedRows[0].Cells[0].Value.ToString();
                    string personName = form.nameEn = form.dgv.SelectedRows[0].Cells[1].Value.ToString();
                    string directoryFiles = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + @"\" + id + " " + personName;
                    Helper.CreateDlls();
                    Helper.CreateStandartImage();
                    FormCvlChild(form.idPerson, form.nameEn, form.nameAr, form.fileNameImage, directoryFiles);
                }
                else
                {
                    new MessageOk(Words.AddPersonFirst, Words.Error, MessageIcon.Error).ShowDialog();
                }
            };
            if (activateForm != null)
            {
                activateForm.Close();
                panelBody.Controls.Clear();
                activateFormName = "";
            }
            activateForm = form;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            activateForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChild_FormClosed);
            
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;
            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormCvlChild(int idPerson, string nameEn, string nameAr, string fileImage, string directoryFiles)
        {
            fCv form2 = new fCv(idPerson,nameEn,nameAr,fileImage,directoryFiles);
            

            if (Properties.Settings.Default.Language == "en")
            {
                form2.labelTitle.Text = nameEn;
                form2.pictureBoxClose.Image = Resources.back_24px;
            }
            else {
                form2.labelTitle.Text = nameAr;
                form2.pictureBoxClose.Image = Resources.next_24px;
                form2.btnSections.Image = Resources.back_to_24px;
                form2.btnSub_sections.Image = Resources.back_to_24px;
                form2.btnSelections.Image = Resources.back_to_24px;
            }
            form2.btnSections.Click += delegate (object sender, EventArgs e)
            {
                FormSectionChild();
            };
            form2.btnSub_sections.Click += delegate (object sender, EventArgs e)
            {
                FormSub_sectionChild();
            };
            form2.btnSelections.Click += delegate (object sender, EventArgs e)
            {
                FormSelectionChild();
            };

            activateForm = form2;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;

            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormSectionChild()
        {
            fSections form2 = new fSections();
            if (Properties.Settings.Default.IsArabic)
            {
                form2.pictureBoxClose.Image = Resources.next_24px;
            }
            else
            {
                form2.pictureBoxClose.Image = Resources.back_24px;
            }
            
            activateForm = form2;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;

            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormSub_sectionChild()
        {
            fSubSection form2 = new fSubSection();
            if (Properties.Settings.Default.IsArabic)
            {
                form2.pictureBoxClose.Image = Resources.next_24px;
            }
            else
            {
                form2.pictureBoxClose.Image = Resources.back_24px;
            }
            activateForm = form2;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;

            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormSelectionChild()
        {
            fSelectios form2 = new fSelectios();
            if (Properties.Settings.Default.IsArabic)
            {
                form2.pictureBoxClose.Image = Resources.next_24px;
            }
            else
            {
                form2.pictureBoxClose.Image = Resources.back_24px;
            }
            activateForm = form2;
            activateForm.TopLevel = false;
            activateForm.Dock = DockStyle.Fill;
            this.panelBody.Controls.Add(activateForm);
            this.panelBody.Tag = activateForm;

            activateForm.BringToFront();
            activateForm.Show();
        }
        private void FormChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            activateFormName = "";
        }
        
        // 
        // Show and hide SubMenu
        public void hideSubMenu()
        {
            if (panelCvGenerator.Visible == true)
            {
                panelCvGenerator.Visible = false;
            }
            if (panelSettings.Visible == true)
            {
                panelSettings.Visible = false;
            }
            if (panelLanguge.Visible == true)
            {
                panelLanguge.Visible = false;
            }
        }
        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnPersonAndCv_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fPersons")
            {
                FormPersonChild();
                activateFormName = "fPersons";
            }
        }
        private void btnCvGenerator_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCvGenerator);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSettings);
        }
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLanguge);
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
            this.RightToLeftLayout = isRightToLeft;
            RightToLeftLayoutPanel(panelTop, isRightToLeft);
            RightToLeftLayoutPanel(panelLogo, isRightToLeft);


            RightToLeftLayoutPanel(panelSideMenu, isRightToLeft);
            RightToLeftLayoutPanel(panelCvGenerator, isRightToLeft);
            RightToLeftLayoutPanel(panelSettings, isRightToLeft);
            RightToLeftLayoutPanel(panelLanguge, isRightToLeft);

            RightToLeftLayoutPanel(panelPowerOff, isRightToLeft);

            
            if (isRightToLeft)
            {
                this.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
            }
        }

        //
        // Panel Top
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBoxMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBoxMaximize.Visible = false;
            pictureBoxRestore.Visible = true;
        }
        private void pictureBoxRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBoxMaximize.Visible = true;
            pictureBoxRestore.Visible = false;
        }
        private void pictureBoxShutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBoxRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void MaximizeOrMinimize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                pictureBoxMaximize.Visible = false;
                pictureBoxRestore.Visible = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                pictureBoxMaximize.Visible = true;
                pictureBoxRestore.Visible = false;

            }
        }
        
        //
        // Sub-menu Language
        private void btnArabic_Click(object sender, EventArgs e)
        {
            bool isArabic = Properties.Settings.Default.IsArabic;
            if (!isArabic)
            {
                MessageYesNo message = new MessageYesNo(Words.QuestionChangeLanguage, "", MessageIcon.Warning);
                message.ShowDialog();
                if (message.Resultat)
                {
                    Properties.Settings.Default["Language"] = "ar";
                    Properties.Settings.Default["IsArabic"] = true;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }

        }
        private void btnEnglish_Click(object sender, EventArgs e)
        {
            bool isArabic = Properties.Settings.Default.IsArabic;
            if (isArabic)
            {
                MessageYesNo message = new MessageYesNo(Words.QuestionChangeLanguage, "", MessageIcon.Warning);
                message.ShowDialog();
                if (message.Resultat)
                {
                    Properties.Settings.Default["Language"] = "en";
                    Properties.Settings.Default["IsArabic"] = false;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }

        }

        //
        // Sub-menu Settings
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fSettingsGeneral")
            {
                FormChild(new fSettingsGeneral());
                activateFormName = "fSettingsGeneral";
            }
        }
        private void btnDatabase_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fSettingsDatabase")
            {
                FormChild(new fSettingsDatabase());
                activateFormName = "fSettingsDatabase";
            }
        }

        //
        // Sub-menu CV Generator
        private void btnSections_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fSections")
            {
                FormChild(new fSections());
                activateFormName = "fSections";
            }
        }
        private void btnSubSections_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fSubSection")
            {
                FormChild(new fSubSection());
                activateFormName = "fSubSection";
            }
        }
        private void btnSelections_Click(object sender, EventArgs e)
        {
            if (activateFormName != "fSelectios")
            {
                FormChild(new fSelectios());
                activateFormName = "fSelectios";
            }
        }
        

        //
        //
        private void panelBody_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (panelBody.Controls.Count==0)
            {
                if (activateFormName != "fHomeBody")
                {
                    FormHomeBodyChild();
                    activateFormName = "fHomeBody";
                }
            }
            
        }


        //
        //

    }
}
