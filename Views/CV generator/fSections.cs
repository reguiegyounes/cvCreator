using CV_creator.Entity;
using CV_creator.MyMessageBox;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace CV_creator.Views.CV_generator
{
    public partial class fSections : Form
    {

        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;

        cSection section = new cSection();
        bool changeText = true;
        MSAccessDatabase db;

        int idSection;
        string operation = "";
        public fSections()
        {
            InitializeComponent();
            ChangeLayout(Properties.Settings.Default.IsArabic);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            db = new MSAccessDatabase();
            try
            {
                dgv.DataSource = section.getSections();
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
            cmbRepeatSubSection.SelectedIndex = 1;

            txtAr.RightToLeft = RightToLeft.Yes;
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

        //---------------------------------------------------------------
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
                changeText = false;
                txtID.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtEn.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                txtAr.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                txtFr.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                cmbRepeatSubSection.SelectedIndex = Convert.ToInt32(dgv.SelectedRows[0].Cells[4].Value);
                idSection = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                changeText = true;
                return;
            }
            changeText = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            operation = "add";
            btnSave.Text = Words.Add;

            btnAddTextFile.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtID.Enabled = true;
            txtAr.Enabled = true;
            txtEn.Enabled = true;
            txtFr.Enabled = true;
            cmbRepeatSubSection.Enabled = true;

            txtID.Clear();
            txtEn.Clear();
            txtAr.Clear();
            txtFr.Clear();
            txtID.Focus();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count != 0)
            {
                operation = "update";
                btnSave.Text = Words.Edit;

                btnAddTextFile.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                btnSave.Visible = true;
                btnCancel.Visible = true;

                txtID.Enabled = true;
                txtAr.Enabled = true;
                txtEn.Enabled = true;
                txtFr.Enabled = true;
                cmbRepeatSubSection.Enabled = true;

                txtID.Focus();
                txtID.SelectionStart = 0;
                txtID.SelectionLength = txtID.Text.Length;
            }
            else
            {
                new MessageOk(Words.EmptyTable, Words.Error, MessageIcon.Error).ShowDialog();
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
                        MessageYesNo message = new MessageYesNo(Words.DeleteSection + "\n" + Words.DeleteQuestion, Words.Delete, MessageIcon.Warning);
                        message.ShowDialog();
                        if (message.Resultat)
                        {
                            int length = dgv.SelectedRows.Count;
                            for (int i = 0; i < length; i++)
                            {
                                int id = Convert.ToInt32(dgv.SelectedRows[i].Cells[0].Value);
                                section.delete(id);
                            }
                            dgv.DataSource = section.getSections();
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
        private void btnAddTextFile_Click(object sender, EventArgs e)
        {
            int lastIndex = 1;
            try
            {
                MSAccessDatabase d = new MSAccessDatabase();
                DataTable dtSections = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MAX(idSection) FROM tblSections", d.Connection);
                da.Fill(dtSections);
                if (dtSections.Rows.Count != 0) lastIndex = (int)dtSections.Rows[dtSections.Rows.Count - 1][0] + 1;
            }
            catch (Exception)
            {
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = Words.Open;
            dialog.Filter = "Text files|*.txt;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string[]> list = Helper.ReadTextFileToList(dialog.FileName);
                for (int i = 0; i < list.Count; i++)
                {
                    if (db.TestConnection())
                    {
                        try
                        {
                            section.insert(lastIndex, list[i][0], list[i][2], list[i][1], true);
                            lastIndex++;
                        }
                        catch (Exception ex)
                        {
                            new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                            db.Close();
                        }
                    }
                }
                if (Properties.Settings.Default.Notafication)
                {
                    new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                }
                try
                {
                    dgv.DataSource = section.getSections();
                }
                catch (Exception ex)
                {
                    new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "add":
                    {
                        if (db.TestConnection())
                        {
                            try
                            {
                                section.insert(Convert.ToInt32(txtID.Text), txtEn.Text, txtAr.Text
                                               , txtFr.Text, Convert.ToBoolean(cmbRepeatSubSection.SelectedIndex));
                                if (Properties.Settings.Default.Notafication)
                                {
                                    new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                                }
                                dgv.DataSource = section.getSections();
                            }
                            catch (Exception ex)
                            {
                                new MessageOk(Words.ErrorFillTextBox +" "+Words.Or+" "+Words.idSection+ "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
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
                                section.update(idSection, Convert.ToInt32(txtID.Text)
                                                , txtEn.Text, txtAr.Text
                                                , txtFr.Text, Convert.ToBoolean(cmbRepeatSubSection.SelectedIndex));
                                if (Properties.Settings.Default.Notafication)
                                {
                                    new MessageOk(Words.Modified, Words.Edit, MessageIcon.Success).ShowDialog();
                                }
                                dgv.DataSource = section.getSections();
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
            btnAddTextFile.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            txtID.Enabled = false;
            txtAr.Enabled = false;
            txtEn.Enabled = false;
            txtFr.Enabled = false;
            cmbRepeatSubSection.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            operation = "";

            btnAddTextFile.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            txtID.Enabled = false;
            txtAr.Enabled = false;
            txtEn.Enabled = false;
            txtFr.Enabled = false;
            cmbRepeatSubSection.Enabled = false;

            try
            {
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
            }
            catch (Exception)
            {
                return;
            }
        }


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
