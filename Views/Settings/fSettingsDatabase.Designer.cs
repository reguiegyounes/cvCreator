namespace CV_creator.Views.Settings
{
    partial class fSettingsDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSettingsDatabase));
            this.panelBody = new System.Windows.Forms.Panel();
            this.txtSaveBackup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnExportCvGenerator = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
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
            this.panelBody.Controls.Add(this.txtSaveBackup);
            this.panelBody.Controls.Add(this.label2);
            this.panelBody.Controls.Add(this.btnRestore);
            this.panelBody.Controls.Add(this.btnExportCvGenerator);
            this.panelBody.Controls.Add(this.btnBackup);
            this.panelBody.Controls.Add(this.btnBrowse);
            this.panelBody.Name = "panelBody";
            // 
            // txtSaveBackup
            // 
            resources.ApplyResources(this.txtSaveBackup, "txtSaveBackup");
            this.txtSaveBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtSaveBackup.ForeColor = System.Drawing.Color.White;
            this.txtSaveBackup.Name = "txtSaveBackup";
            this.txtSaveBackup.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnRestore
            // 
            resources.ApplyResources(this.btnRestore, "btnRestore");
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnExportCvGenerator
            // 
            resources.ApplyResources(this.btnExportCvGenerator, "btnExportCvGenerator");
            this.btnExportCvGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExportCvGenerator.FlatAppearance.BorderSize = 0;
            this.btnExportCvGenerator.ForeColor = System.Drawing.Color.White;
            this.btnExportCvGenerator.Name = "btnExportCvGenerator";
            this.btnExportCvGenerator.UseVisualStyleBackColor = false;
            this.btnExportCvGenerator.Click += new System.EventHandler(this.btnExportCvGenerator_Click);
            // 
            // btnBackup
            // 
            resources.ApplyResources(this.btnBackup, "btnBackup");
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
            // fSettingsDatabase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSettingsDatabase";
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
        private System.Windows.Forms.TextBox txtSaveBackup;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panelTop;
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        public System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Button btnExportCvGenerator;
    }
}