namespace CV_creator.Views.Settings
{
    partial class fSettingsGeneral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSettingsGeneral));
            this.panelBody = new System.Windows.Forms.Panel();
            this.txtSaveCVs = new System.Windows.Forms.TextBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.cmbNotafication = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseCVs = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.panelBody.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            resources.ApplyResources(this.panelBody, "panelBody");
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panelBody.Controls.Add(this.txtSaveCVs);
            this.panelBody.Controls.Add(this.cmbResolution);
            this.panelBody.Controls.Add(this.cmbNotafication);
            this.panelBody.Controls.Add(this.label2);
            this.panelBody.Controls.Add(this.label3);
            this.panelBody.Controls.Add(this.label1);
            this.panelBody.Controls.Add(this.btnBrowseCVs);
            this.panelBody.Name = "panelBody";
            // 
            // txtSaveCVs
            // 
            resources.ApplyResources(this.txtSaveCVs, "txtSaveCVs");
            this.txtSaveCVs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtSaveCVs.ForeColor = System.Drawing.Color.White;
            this.txtSaveCVs.Name = "txtSaveCVs";
            this.txtSaveCVs.ReadOnly = true;
            // 
            // cmbResolution
            // 
            resources.ApplyResources(this.cmbResolution, "cmbResolution");
            this.cmbResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolution.ForeColor = System.Drawing.Color.White;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Items.AddRange(new object[] {
            resources.GetString("cmbResolution.Items"),
            resources.GetString("cmbResolution.Items1")});
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.SelectedIndexChanged += new System.EventHandler(this.cmbResolution_SelectedIndexChanged);
            // 
            // cmbNotafication
            // 
            resources.ApplyResources(this.cmbNotafication, "cmbNotafication");
            this.cmbNotafication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.cmbNotafication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotafication.ForeColor = System.Drawing.Color.White;
            this.cmbNotafication.FormattingEnabled = true;
            this.cmbNotafication.Items.AddRange(new object[] {
            resources.GetString("cmbNotafication.Items"),
            resources.GetString("cmbNotafication.Items1")});
            this.cmbNotafication.Name = "cmbNotafication";
            this.cmbNotafication.SelectedIndexChanged += new System.EventHandler(this.cmbNotafication_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnBrowseCVs
            // 
            resources.ApplyResources(this.btnBrowseCVs, "btnBrowseCVs");
            this.btnBrowseCVs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBrowseCVs.FlatAppearance.BorderSize = 0;
            this.btnBrowseCVs.ForeColor = System.Drawing.Color.White;
            this.btnBrowseCVs.Name = "btnBrowseCVs";
            this.btnBrowseCVs.UseVisualStyleBackColor = false;
            this.btnBrowseCVs.Click += new System.EventHandler(this.btnBrowseCVs_Click);
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.ForeColor = System.Drawing.Color.White;
            this.panelTop.Name = "panelTop";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Name = "labelTitle";
            // 
            // pictureBoxClose
            // 
            resources.ApplyResources(this.pictureBoxClose, "pictureBoxClose");
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::CV_creator.Properties.Resources.close_24px;
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // fSettingsGeneral
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSettingsGeneral";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseCVs;
        private System.Windows.Forms.Panel panelTop;
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.ComboBox cmbNotafication;
        private System.Windows.Forms.TextBox txtSaveCVs;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResolution;
        public System.Windows.Forms.Label label3;
    }
}