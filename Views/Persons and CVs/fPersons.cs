using CV_creator.Entity;
using CV_creator.MyMessageBox;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CV_creator.Views.Persons_and_CVs
{
    public partial class fPersons : Form
    {
        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;
        public string operation = "";
        public string sourceImage = "";
        public string fileNameImage = "";
        cPerson person = new cPerson();
        MSAccessDatabase db = new MSAccessDatabase();
        public int idPerson;
        public string nameEn = "";
        public string nameAr = "";

        public fPersons()
        {
            Helper.CreateStandartImage();
            InitializeComponent();

            ChangeLayout(Properties.Settings.Default.IsArabic);

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            txtFullNameEn.RightToLeft = RightToLeft.No;
            try
            {
                dgv.DataSource = person.getPersons();
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
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
            this.Location = new System.Drawing.Point(50, 50);
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




        //-------------------------------------------------------
        private void SaveFilesPerson(string sourceFileName, string personName)
        {
            int id = Properties.Settings.Default.IndexLastPerson;
            string directory = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + @"\" + id + " " + personName;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            Helper.CopyFile(sourceFileName, directory, personName);
        }
        private string getFileNameImageNewPerson(string sourceFileName, string personName)
        {
            int id = Properties.Settings.Default.IndexLastPerson;
            string directory = @"\" + id + " " + personName + @"\";
            var f = new FileInfo(sourceFileName);
            return directory + personName + f.Extension;
        }
        private string getFileNameImageUpdatePerson(string sourceFileName, string personName)
        {
            string directory = @"\" + idPerson + " " + personName + @"\";
            var f = new FileInfo(sourceFileName);
            return directory + personName + f.Extension;
        }
        //------------------------------------------------------------------------------------------------

        private string DirectoryNewPersonIN(string personName)
        {
            int id = Properties.Settings.Default.IndexLastPerson;
            string directory = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + @"\" + id + " " + personName;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
        private string DirectoryCurrentPersonIN()
        {
            string directory = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + @"\" + idPerson + " " + nameEn;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
        private string getImageCurrentPerson()
        {
            string fileName = dgv.SelectedRows[0].Cells[4].Value.ToString();
            fileName = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + fileName;
            if (!File.Exists(fileName))
            {
                fileName = AppDomain.CurrentDomain.BaseDirectory + @"\Images\Standart_image.png";
            }
            return fileName;
        }
        private string DirectoryPersonOUT()
        {
            string directory = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        //-----------------------------------------------------------------------------------


        //
        // Events
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-------

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idPerson = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                txtID.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtFullNameEn.Text = nameEn = dgv.SelectedRows[0].Cells[1].Value.ToString();
                txtFullNameAr.Text = nameAr = dgv.SelectedRows[0].Cells[2].Value.ToString();
                labelTime.Visible = true;
                labelTime.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                fileNameImage = dgv.SelectedRows[0].Cells[4].Value.ToString();
                fileNameImage = getImageCurrentPerson();
                byte[] bytes = File.ReadAllBytes(fileNameImage);
                MemoryStream ms = new MemoryStream(bytes);
                picture.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            operation = "add";
            txtFullNameAr.Enabled = true;
            txtFullNameEn.Enabled = true;
            picture.Enabled = true;
            btnSave.Text = Words.Add;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            labelTime.Visible = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Enabled = false;

            txtID.Clear();
            txtFullNameAr.Clear();
            txtFullNameEn.Clear();
            txtFullNameEn.Focus();
            sourceImage = "";
            picture.Image = Properties.Resources.user;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count != 0)
            {
                operation = "update";
                sourceImage = "";

                txtFullNameAr.Enabled = true;
                txtFullNameEn.Enabled = true;
                picture.Enabled = true;
                btnSave.Text = Words.Edit;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                labelTime.Visible = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCreate.Enabled = false;

                txtFullNameEn.Focus();
                txtFullNameEn.SelectionStart = 0;
                txtFullNameEn.SelectionLength = txtFullNameEn.Text.Length;
            }
            else
            {
                new MessageOk(Words.AddPersonFirst, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count != 0)
            {
                if (db.TestConnection())
                {
                    try
                    {
                        MessageYesNo message = new MessageYesNo(Words.DeletePerson + "\n" + Words.DeleteQuestion, Words.Delete, MessageIcon.Warning);
                        message.ShowDialog();
                        if (message.Resultat)
                        {
                            int length = dgv.SelectedRows.Count;
                            for (int i = 0; i < length; i++)
                            {
                                int id = Convert.ToInt32(dgv.SelectedRows[i].Cells[0].Value);
                                person.delete(id);
                            }

                            dgv.DataSource = person.getPersons();
                        }
                    }
                    catch (Exception)
                    {
                        new MessageOk(Words.ErrorDelete, Words.Error, MessageIcon.Error).ShowDialog();
                    }
                }
            }
            else
            {
                new MessageOk(Words.AddPersonFirst, Words.Error, MessageIcon.Error).ShowDialog();
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            operation = "";
            txtFullNameAr.Enabled = false;
            txtFullNameEn.Enabled = false;
            picture.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            //labelTime.Visible = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCreate.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "add":
                    {
                        if (db.TestConnection())
                        {
                            if (txtFullNameEn.Text != "" && txtFullNameAr.Text != "")
                            {
                                try
                                {
                                    person.insert(txtFullNameEn.Text, txtFullNameAr.Text, "", DateTime.Now.Date.ToShortDateString());
                                    int id = Properties.Settings.Default.IndexLastPerson;
                                    if (sourceImage == "")
                                    {
                                        DirectoryNewPersonIN(txtFullNameEn.Text);
                                        fileNameImage = @"\Images\Standart_image.png";
                                        person.update(id, txtFullNameEn.Text, txtFullNameAr.Text, fileNameImage);
                                    }
                                    else
                                    {
                                        fileNameImage = getFileNameImageNewPerson(sourceImage, txtFullNameEn.Text);
                                        person.update(id, txtFullNameEn.Text, txtFullNameAr.Text, fileNameImage);
                                        SaveFilesPerson(sourceImage, txtFullNameEn.Text);
                                    }
                                    if (Properties.Settings.Default.Notafication)
                                    {
                                        new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                                    }

                                    dgv.DataSource = person.getPersons();
                                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                                    sourceImage = "";
                                }
                                catch (Exception ex)
                                {
                                    new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();

                                }
                            }
                            else
                            {
                                new MessageOk(Words.ErrorFillTextBox, Words.Error, MessageIcon.Error).ShowDialog();
                                return;
                            }
                        }
                    }
                    break;
                case "update":
                    {
                        if (db.TestConnection())
                        {
                            try
                            {
                                string FileImageCurrent = dgv.SelectedRows[0].Cells[4].Value.ToString();
                                string directoryCurrentPersonIN = DirectoryCurrentPersonIN();
                                string directoryNewPerson = "";

                                if (nameEn != txtFullNameEn.Text)
                                {
                                    //Rename Directory
                                    directoryNewPerson = DirectoryPersonOUT() + @"\" + idPerson + " " + txtFullNameEn.Text;
                                    Directory.Move(directoryCurrentPersonIN, directoryNewPerson);
                                    directoryCurrentPersonIN = directoryNewPerson;
                                    // Rename image
                                    string FileImageOld = dgv.SelectedRows[0].Cells[4].Value.ToString();
                                    if (FileImageCurrent != @"\Images\Standart_image.png")
                                    {
                                        var f = new FileInfo(FileImageOld);
                                        FileImageCurrent = getFileNameImageUpdatePerson(FileImageOld, txtFullNameEn.Text);
                                        FileImageOld = directoryNewPerson + @"\" + nameEn + f.Extension;
                                        if (File.Exists(FileImageOld))
                                        {
                                            File.Move(FileImageOld, DirectoryPersonOUT() + FileImageCurrent);
                                        }

                                    }
                                }

                                if (sourceImage != "")
                                {
                                    fileNameImage = getFileNameImageUpdatePerson(sourceImage, txtFullNameEn.Text);
                                    person.update(idPerson, txtFullNameEn.Text, txtFullNameAr.Text, fileNameImage);
                                    FileImageCurrent = DirectoryPersonOUT() + FileImageCurrent;
                                    if (File.Exists(FileImageCurrent))
                                    {
                                        File.Delete(FileImageCurrent);
                                    }
                                    fileNameImage = DirectoryPersonOUT() + fileNameImage;
                                    File.Copy(sourceImage, fileNameImage, true);
                                }
                                else
                                {
                                    string directory = Properties.Settings.Default.DirectorySaveCv + @"\" + Properties.Settings.Default.FolderNameCv + FileImageCurrent;
                                    if (!File.Exists(directory))
                                    {
                                        FileImageCurrent = @"\Images\Standart_image.png";
                                    }
                                    person.update(idPerson, txtFullNameEn.Text, txtFullNameAr.Text, FileImageCurrent);
                                }


                                if (Properties.Settings.Default.Notafication)
                                {
                                    new MessageOk(Words.Modified, Words.Edit, MessageIcon.Success).ShowDialog();
                                }
                                int index = dgv.CurrentRow.Index;
                                dgv.DataSource = person.getPersons();
                                dgv.CurrentCell = dgv.Rows[index].Cells[0];
                                sourceImage = "";
                            }
                            catch (Exception ex)
                            {
                                new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();

                            }
                        }
                    }
                    break;
            }
            operation = "";
            txtFullNameAr.Enabled = false;
            txtFullNameEn.Enabled = false;
            picture.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            labelTime.Visible = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCreate.Enabled = true;


        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count != 0)
            {

            }
            else
            {
                new MessageOk(Words.AddPersonFirst, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }

        private void picture_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = Words.Open;
            dialog.Filter = "Image files|*.jpeg;*.jpg;*.gif;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceImage = dialog.FileName;
                byte[] bytes = File.ReadAllBytes(sourceImage);
                MemoryStream ms = new MemoryStream(bytes);
                picture.Image = Image.FromStream(ms);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = person.search(txtSearch.Text);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
