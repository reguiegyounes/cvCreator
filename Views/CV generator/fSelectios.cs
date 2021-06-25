using CV_creator.Entity;
using CV_creator.MyMessageBox;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CV_creator.Views.CV_generator
{
    public partial class fSelectios : Form
    {
        private float _currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        float _currentFontSize;

        cItem2 sub_section = new cItem2();
        cSection section = new cSection();
        cDetails selection = new cDetails();
        MSAccessDatabase d;
        bool changeText = true;
        string operation = "";
        int idSection;
        int idSub_section;
        int idSelection;
        public fSelectios()
        {
            d = new MSAccessDatabase();
            InitializeComponent();
            ChangeLayout(Properties.Settings.Default.IsArabic);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            try
            {
                section.fillCombo(cmbSection, Properties.Settings.Default.Language);
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }

            try
            {
                cmbSection.SelectedIndex = 0;
                idSection = Convert.ToInt32(cmbSection.SelectedValue);
            }
            catch (Exception)
            {
                return;
            }
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
                catch { return; }
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

        // tab details ----------------------------------------------------------------------------------------
        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idSection = Convert.ToInt32(cmbSection.SelectedValue);
            }
            catch (Exception)
            {
            }
            try
            {
                sub_section.fillCombo(cmbSub_section, Properties.Settings.Default.Language, idSection);
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }
        private void cmbSubSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idSub_section = Convert.ToInt32(cmbSub_section.SelectedValue);
            }
            catch (Exception)
            {
            }
            try
            {
                DataTable dt = selection.getDetails(idSub_section);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                new MessageOk(ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                changeText = false;
                idSelection = (int)dgv.SelectedRows[0].Cells[0].Value;
                txtID.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtEn.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                txtAr.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                txtFr.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                txtID.Clear();
                txtEn.Clear();
                txtAr.Clear();
                txtFr.Clear();
                changeText = true;
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

            txtAr.Enabled = true;
            txtEn.Enabled = true;
            txtFr.Enabled = true;


            txtID.Clear();
            txtEn.Clear();
            txtAr.Clear();
            txtFr.Clear();
            txtAr.Focus();
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

                txtAr.Enabled = true;
                txtEn.Enabled = true;
                txtFr.Enabled = true;


                txtAr.Focus();
                txtAr.SelectionStart = 0;
                txtAr.SelectionLength = txtAr.Text.Length;
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

                if (d.TestConnection())
                {
                    try
                    {
                        MessageYesNo message = new MessageYesNo(Words.DeleteSelection + "\n" + Words.DeleteQuestion, Words.Delete, MessageIcon.Warning);
                        message.ShowDialog();
                        if (message.Resultat)
                        {
                            int length = dgv.SelectedRows.Count;
                            for (int i = 0; i < length; i++)
                            {
                                if (dgv.SelectedRows[i].Cells[1].Value.ToString() != "" ||
                                    dgv.SelectedRows[i].Cells[2].Value.ToString() != "" ||
                                    dgv.SelectedRows[i].Cells[3].Value.ToString() != "")
                                {
                                    int id = Convert.ToInt32(dgv.SelectedRows[i].Cells[0].Value);
                                    selection.delete(id);
                                }

                            }
                        }
                        dgv.DataSource = selection.getDetails(idSub_section);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = selection.search(txtSearch.Text, idSub_section);
            }
            catch (Exception)
            {
                return;
            }
        }
        private void btnAddTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = Words.Open;
            dialog.Filter = "Text files|*.txt;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string[]> list = Helper.ReadTextFileToList(dialog.FileName);
                for (int i = 0; i < list.Count; i++)
                {
                    if (d.TestConnection())
                    {
                        try
                        {
                            selection.insert(list[i][0], list[i][2], list[i][1], idSub_section);
                        }
                        catch (Exception ex)
                        {
                            new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                        }
                    }
                }
                if (Properties.Settings.Default.Notafication)
                {
                    new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                }
                try
                {
                    dgv.DataSource = selection.getDetails(idSub_section);
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
                        if (txtEn.Text != "" ||
                            txtAr.Text != "" ||
                            txtFr.Text != "")
                        {
                            if (d.TestConnection())
                            {
                                try
                                {
                                    selection.insert(txtEn.Text, txtAr.Text
                                                   , txtFr.Text, idSub_section);
                                    if (Properties.Settings.Default.Notafication)
                                    {
                                        new MessageOk(Words.Added, Words.Add, MessageIcon.Success).ShowDialog();
                                    }
                                    dgv.DataSource = selection.getDetails(idSub_section);
                                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                                }
                                catch (Exception ex)
                                {
                                    new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                                }
                            }
                        }
                    }
                    break;
                case "update":
                    {
                        if ((txtEn.Text != "" ||
                           txtAr.Text != "" ||
                           txtFr.Text != "") &&
                           (dgv.SelectedRows[0].Cells[1].Value.ToString() != "" ||
                           dgv.SelectedRows[0].Cells[2].Value.ToString() != "" ||
                           dgv.SelectedRows[0].Cells[3].Value.ToString() != "")
                           )
                        {
                            if (d.TestConnection())
                            {
                                try
                                {
                                    selection.update(idSelection, txtEn.Text, txtAr.Text
                                                   , txtFr.Text, idSub_section);
                                    if (Properties.Settings.Default.Notafication)
                                    {
                                        new MessageOk(Words.Modified, Words.Edit, MessageIcon.Success).ShowDialog();
                                    }
                                    int index = dgv.CurrentRow.Index;
                                    dgv.DataSource = selection.getDetails(idSub_section);
                                    dgv.CurrentCell = dgv.Rows[index].Cells[0];
                                }
                                catch (Exception ex)
                                {
                                    new MessageOk(Words.ErrorFillTextBox + "\n" + ex.Message, Words.Error, MessageIcon.Error).ShowDialog();
                                }
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

            txtAr.Enabled = false;
            txtEn.Enabled = false;
            txtFr.Enabled = false;

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

            txtAr.Enabled = false;
            txtEn.Enabled = false;
            txtFr.Enabled = false;


            try
            {
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmbSub_section_Click(object sender, EventArgs e)
        {
            try
            {
                sub_section.fillCombo(cmbSub_section, Properties.Settings.Default.Language, idSection);
                idSub_section = Convert.ToInt32(cmbSub_section.SelectedValue);
                DataTable dt = selection.getDetails(idSub_section);
                dgv.DataSource = dt;
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
