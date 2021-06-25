using CV_creator.Entity;
using CV_creator.MyMessageBox;
using CV_creator.Views.Report;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CV_creator.Views.Persons_and_CVs
{
    public partial class fCv : Form
    {

        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;
        bool changeText = true;
        cSection section;
        cItem2 item;
        cDetails detail;
        cCV cv;
        MSAccessDatabase db;
        int idSection;
        int indexShow = 0;
        int idItem;
        int idDetail;
        int idCvItem;
        string language = "en";
        public int idPerson;
        public string nameEn = "";
        public string nameAr = "";
        public string fileNameImage = "";
        public string directoryFiles = "";
        string typeExport = "PDF";
        string extensionExport = ".pdf";

        public fCv(int idPerson, string nameEn, string nameAr, string fileImage, string directoryFiles)
        {
            this.idPerson = idPerson;
            this.nameAr = nameAr;
            this.nameEn = nameEn;
            this.fileNameImage = fileImage;
            this.directoryFiles = directoryFiles;
            InitializeComponent();
            ChangeLayout(Properties.Settings.Default.IsArabic);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            txtEn.RightToLeft = RightToLeft.No;
            txtFr.RightToLeft = RightToLeft.No;
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

        //-----------------------------------------------------

        //
        // Events
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-------

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idSection = Convert.ToInt32(cmbSection.SelectedValue);
                item = new cItem2();
                try
                {
                    item.fillCombo(cmbItem, language, idSection, idPerson);
                }
                catch (Exception ex)
                {
                    new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                }

                if (indexShow == 1) ShowCv();

                if (cmbItem.Items.Count == 0)
                {
                    idItem = 0;
                    idDetail = 0;
                    try
                    {
                        detail.fillCombo(cmbDetail, language, idItem);
                    }
                    catch (Exception ex)
                    {
                        new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                detail = new cDetails();
                idItem = Convert.ToInt32(cmbItem.SelectedValue);
                try
                {
                    detail.fillCombo(cmbDetail, language, idItem);
                }
                catch (Exception ex)
                {
                    new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }
        private void cmbDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idDetail = Convert.ToInt32(cmbDetail.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //cmbDetail.DroppedDown = true;
            try
            {
                detail.fillCombo(cmbDetail, language, txtSearch.Text, idItem);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLanguage.SelectedIndex)
            {
                case 0:
                    {
                        language = "en";
                    }
                    break;
                case 1:
                    {
                        language = "ar";
                    }
                    break;
                case 2:
                    {
                        language = "fr";
                    }
                    break;
            }
            try
            {
                try
                {
                    section.fillCombo(cmbSection, language);
                }
                catch (Exception ex)
                {
                    new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                }
                idSection = Convert.ToInt32(cmbSection.SelectedValue);
                ShowCv();
            }
            catch (Exception)
            {
            }
        }
        private void cmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbShow.SelectedIndex)
            {
                case 0:
                    {
                        indexShow = 0;
                    }
                    break;
                case 1:
                    {
                        indexShow = 1;
                    }
                    break;
            }
            ShowCv();
        }
        public void ShowCv()
        {
            switch (indexShow)
            {
                case 0:
                    {
                        try
                        {
                            dgvCv.DataSource = cv.getCv(idPerson, language);
                            dgvCv.Columns[0].Visible = false;
                            dgvCv.Columns[6].Visible = false;
                            dgvCv.Columns[7].Visible = false;
                            dgvCv.Columns[8].Visible = false;
                            dgvCv.Columns[9].Visible = false;
                            dgvCv.Columns[10].Visible = false;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            dgvCv.DataSource = cv.getCv(idPerson, idSection, language);
                            dgvCv.Columns[0].Visible = false;
                            dgvCv.Columns[6].Visible = false;
                            dgvCv.Columns[7].Visible = false;
                            dgvCv.Columns[8].Visible = false;
                            dgvCv.Columns[9].Visible = false;
                            dgvCv.Columns[10].Visible = false;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    break;
            }
        }

        private void dgvPersons_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                changeText = false;
                switch (language)
                {
                    case "ar":
                        {
                            idCvItem = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[0].Value);
                            idDetail = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[6].Value);
                            txtAr.Text = dgvCv.SelectedRows[0].Cells[4].Value.ToString();
                            txtEn.Text = dgvCv.SelectedRows[0].Cells[9].Value.ToString();
                            txtFr.Text = dgvCv.SelectedRows[0].Cells[10].Value.ToString();
                            cmbSection.SelectedValue = dgvCv.SelectedRows[0].Cells[8].Value;
                            cmbItem.SelectedValue = dgvCv.SelectedRows[0].Cells[7].Value;
                            cmbDetail.SelectedValue = dgvCv.SelectedRows[0].Cells[6].Value;
                            idCvItem = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[0].Value);
                            idDetail = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[6].Value);
                        }
                        break;
                    case "fr":
                        {
                            idCvItem = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[0].Value);
                            idDetail = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[6].Value);
                            txtFr.Text = dgvCv.SelectedRows[0].Cells[4].Value.ToString();
                            txtEn.Text = dgvCv.SelectedRows[0].Cells[9].Value.ToString();
                            txtAr.Text = dgvCv.SelectedRows[0].Cells[10].Value.ToString();
                            cmbSection.SelectedValue = dgvCv.SelectedRows[0].Cells[8].Value;
                            cmbItem.SelectedValue = dgvCv.SelectedRows[0].Cells[7].Value;
                            cmbDetail.SelectedValue = dgvCv.SelectedRows[0].Cells[6].Value;
                        }
                        break;
                    default:
                        {
                            idCvItem = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[0].Value);
                            idDetail = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[6].Value);
                            txtEn.Text = dgvCv.SelectedRows[0].Cells[4].Value.ToString();
                            txtAr.Text = dgvCv.SelectedRows[0].Cells[9].Value.ToString();
                            txtFr.Text = dgvCv.SelectedRows[0].Cells[10].Value.ToString();
                            cmbOrder.Text = dgvCv.SelectedRows[0].Cells[5].Value.ToString();
                            cmbSection.SelectedValue = dgvCv.SelectedRows[0].Cells[8].Value;
                            cmbItem.SelectedValue = dgvCv.SelectedRows[0].Cells[7].Value;
                            cmbDetail.SelectedValue = dgvCv.SelectedRows[0].Cells[6].Value;
                        }
                        break;
                }

            }
            catch (Exception)
            {
                changeText = true;
            }
            changeText = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cmbItem.Items.Count != 0)
            {
                if (db.TestConnection())
                {
                    try
                    {
                        cv.insert(txtEn.Text, txtAr.Text, txtFr.Text, Convert.ToInt32(cmbOrder.Text), idDetail, idPerson);
                        if (Properties.Settings.Default.Notafication)
                        {
                            new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                        }
                        ShowCv();
                        item.fillCombo(cmbItem, language, idSection, idPerson);
                        try
                        {
                            cmbDetail.SelectedIndex = 0;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                    }
                }
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dgvCv.Rows.Count != 0)
            {
                if (db.TestConnection())
                {
                    try
                    {
                        idDetail = Convert.ToInt32(dgvCv.SelectedRows[0].Cells[6].Value);
                        cv.update(idCvItem, txtEn.Text, txtAr.Text, txtFr.Text, Convert.ToInt32(cmbOrder.Text), idDetail, idPerson);
                        if (Properties.Settings.Default.Notafication)
                        {
                            new MessageOk(Words.Modified, Words.Edit, MessageIcon.Success).ShowDialog();
                        }
                        ShowCv();
                    }
                    catch (Exception ex)
                    {
                        new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                    }
                }
            }
            else
            {
                new MessageOk(Words.EmptyTable, Words.Error, MessageIcon.Error).ShowDialog();
            }

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgvCv.Rows.Count != 0)
            {

                if (db.TestConnection())
                {
                    try
                    {
                        MessageYesNo message = new MessageYesNo(Words.DeleteQuestion, Words.Delete, MessageIcon.Warning);
                        message.ShowDialog();
                        if (message.Resultat)
                        {
                            int length = dgvCv.SelectedRows.Count;
                            for (int i = 0; i < length; i++)
                            {
                                int id = Convert.ToInt32(dgvCv.SelectedRows[i].Cells[0].Value);
                                cv.delete(id);
                            }
                            ShowCv();
                            item.fillCombo(cmbItem, language, idSection, idPerson);
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
                new MessageOk(Words.EmptyTable, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtAr.Clear();
            txtEn.Clear();
            txtFr.Clear();
            txtAr.Focus();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            db = new MSAccessDatabase();
            cv = new cCV();
            section = new cSection();
            language = "en";
            cmbLanguage.SelectedIndex = 0;
            cmbShow.SelectedIndex = 0;
            cmbOrder.SelectedIndex = 0;
            try
            {
                section.fillCombo(cmbSection, language);
                idSection = Convert.ToInt32(cmbSection.SelectedValue);
                dgvCv.DataSource = cv.getCv(idPerson, language);
                dgvCv.Columns[0].Visible = false;
                dgvCv.Columns[6].Visible = false;
                dgvCv.Columns[7].Visible = false;
                dgvCv.Columns[8].Visible = false;
                dgvCv.Columns[9].Visible = false;
                dgvCv.Columns[10].Visible = false;
            }
            catch (Exception)
            {

            }
            finally
            {
                foreach (Control control in panelBody.Controls)
                {
                    control.Visible = true;
                }
                btnLoadData.Visible = false;
            }
        }

        // ToolTip
        private void btnSections_MouseHover(object sender, EventArgs e)
        {
            tip.Show(Words.GoSections, btnSections);
        }
        private void btnSub_sections_MouseHover(object sender, EventArgs e)
        {
            tip.Show(Words.GoSub_sections, btnSub_sections);
        }
        private void btnSelections_MouseHover(object sender, EventArgs e)
        {
            tip.Show(Words.GoSelectios, btnSelections);
        }


        //--------------------------

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                cv.createReport(idPerson, language);
                fReport f = new fReport(idPerson, nameEn, nameAr, fileNameImage, language);
                f.Show();
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }
        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                cv.createReport(idPerson, language);
                Helper.CreateDlls();
                GenerateFile(typeExport, directoryFiles + @"\" + nameEn + " " + language + extensionExport);
            }
            catch (Exception ex)
            {
                new MessageOk(Words.ErrorPrint + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }
        private void cmbExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbExport.SelectedIndex)
            {
                case 0:
                    {
                        typeExport = "PDF";
                        extensionExport = ".pdf";
                    }
                    break;
                case 1:
                    {
                        typeExport = "WORD";
                        extensionExport = ".doc";
                    }
                    break;
                case 2:
                    {
                        typeExport = "EXCEL";
                        extensionExport = ".xls";
                    }
                    break;
            }
        }
        private void GenerateFile(string fileType, string savePath)
        {
            try
            {
                MSAccessDatabase db = new MSAccessDatabase();
                DataSetReport ds = new DataSetReport();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tblReport", db.Connection);
                da.Fill(ds, ds.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportViewer rpt = new ReportViewer();
                rpt.ProcessingMode = ProcessingMode.Local;
                switch (language)
                {
                    case "ar":
                        rpt.LocalReport.ReportEmbeddedResource = "CV_creator.Report.ReportCvAr.rdlc";
                        break;
                    default:
                        rpt.LocalReport.ReportEmbeddedResource = "CV_creator.Report.ReportCv.rdlc";
                        break;
                }
                rpt.LocalReport.DataSources.Clear();
                rpt.LocalReport.DataSources.Add(rds);
                rpt.LocalReport.EnableExternalImages = true;
                ReportParameter url_Image = new ReportParameter();
                url_Image.Name = "url_Image";
                url_Image.Values.Add(@"file:///" + fileNameImage);
                rpt.LocalReport.SetParameters(url_Image);

                switch (language)
                {
                    case "ar":
                        ReportParameter name = new ReportParameter("name", nameAr);
                        rpt.LocalReport.SetParameters(name);
                        break;
                    default:
                        ReportParameter namee = new ReportParameter("name", nameEn);
                        rpt.LocalReport.SetParameters(namee);
                        break;
                }
                rpt.LocalReport.Refresh();
                rpt.RefreshReport();
                byte[] bytes = rpt.LocalReport.Render(fileType);
                FileStream fs = new FileStream(savePath, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                System.Diagnostics.Process.Start(savePath);
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }



        // TextBox 
       
        private void txtFr_TextChanged(object sender, EventArgs e)
        {
            if (changeText)
            {
                if (checkBoxFr.Checked)
                {
                    if (checkBoxAr.Checked)
                    {
                        txtAr.Text = txtFr.Text;
                    }
                    if (checkBoxEn.Checked)
                    {
                        txtEn.Text = txtFr.Text;
                    }
                }
            }

        }
        private void txtAr_TextChanged(object sender, EventArgs e)
        {
            if (changeText)
            {
                if (checkBoxAr.Checked)
                {
                    if (checkBoxFr.Checked)
                    {
                        txtFr.Text = txtAr.Text;
                    }
                    if (checkBoxEn.Checked)
                    {
                        txtEn.Text = txtAr.Text;
                    }
                }
            }
        }
        private void txtEn_TextChanged(object sender, EventArgs e)
        {
            if (changeText)
            {
                if (checkBoxEn.Checked)
                {
                    if (checkBoxFr.Checked)
                    {
                        txtFr.Text = txtEn.Text;
                    }
                    if (checkBoxAr.Checked)
                    {
                        txtAr.Text = txtEn.Text;
                    }
                }
            }
        }
    }
}
