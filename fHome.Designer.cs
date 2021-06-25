using System.Windows.Forms;

namespace CV_creator
{
    partial class fHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHome));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxRestore = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxMaximize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelLanguge = new System.Windows.Forms.Panel();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnArabic = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelCvGenerator = new System.Windows.Forms.Panel();
            this.btnSelections = new System.Windows.Forms.Button();
            this.btnSubSections = new System.Windows.Forms.Button();
            this.btnSections = new System.Windows.Forms.Button();
            this.btnCvGenerator = new System.Windows.Forms.Button();
            this.btnPersonAndCv = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelPowerOff = new System.Windows.Forms.Panel();
            this.pictureBoxRestart = new System.Windows.Forms.PictureBox();
            this.pictureBoxShutdown = new System.Windows.Forms.PictureBox();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.panelSide.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.panelLanguge.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelCvGenerator.SuspendLayout();
            this.panelPowerOff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShutdown)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.pictureBoxRestore);
            this.panelTop.Controls.Add(this.pictureBoxMinimize);
            this.panelTop.Controls.Add(this.pictureBoxMaximize);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // pictureBoxRestore
            // 
            resources.ApplyResources(this.pictureBoxRestore, "pictureBoxRestore");
            this.pictureBoxRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRestore.Image = global::CV_creator.Properties.Resources.restore_down_24px;
            this.pictureBoxRestore.Name = "pictureBoxRestore";
            this.pictureBoxRestore.TabStop = false;
            this.pictureBoxRestore.Click += new System.EventHandler(this.pictureBoxRestore_Click);
            // 
            // pictureBoxMinimize
            // 
            resources.ApplyResources(this.pictureBoxMinimize, "pictureBoxMinimize");
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = global::CV_creator.Properties.Resources.minimize_24px;
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            // 
            // pictureBoxMaximize
            // 
            resources.ApplyResources(this.pictureBoxMaximize, "pictureBoxMaximize");
            this.pictureBoxMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMaximize.Image = global::CV_creator.Properties.Resources.maximize_button_24px;
            this.pictureBoxMaximize.Name = "pictureBoxMaximize";
            this.pictureBoxMaximize.TabStop = false;
            this.pictureBoxMaximize.Click += new System.EventHandler(this.pictureBoxMaximize_Click);
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
            // panelSide
            // 
            resources.ApplyResources(this.panelSide, "panelSide");
            this.panelSide.Controls.Add(this.panelSideMenu);
            this.panelSide.Controls.Add(this.panelLogo);
            this.panelSide.Controls.Add(this.panelPowerOff);
            this.panelSide.Name = "panelSide";
            // 
            // panelSideMenu
            // 
            resources.ApplyResources(this.panelSideMenu, "panelSideMenu");
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panelSideMenu.Controls.Add(this.panelLanguge);
            this.panelSideMenu.Controls.Add(this.btnLanguage);
            this.panelSideMenu.Controls.Add(this.panelSettings);
            this.panelSideMenu.Controls.Add(this.btnSettings);
            this.panelSideMenu.Controls.Add(this.panelCvGenerator);
            this.panelSideMenu.Controls.Add(this.btnCvGenerator);
            this.panelSideMenu.Controls.Add(this.btnPersonAndCv);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.DoubleClick += new System.EventHandler(this.MaximizeOrMinimize);
            // 
            // panelLanguge
            // 
            this.panelLanguge.Controls.Add(this.btnEnglish);
            this.panelLanguge.Controls.Add(this.btnArabic);
            resources.ApplyResources(this.panelLanguge, "panelLanguge");
            this.panelLanguge.Name = "panelLanguge";
            // 
            // btnEnglish
            // 
            this.btnEnglish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.FlatAppearance.BorderSize = 0;
            this.btnEnglish.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnEnglish.ForeColor = System.Drawing.Color.White;
            this.btnEnglish.Image = global::CV_creator.Properties.Resources.usa_15px;
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.UseVisualStyleBackColor = false;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnArabic
            // 
            this.btnArabic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnArabic.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnArabic, "btnArabic");
            this.btnArabic.FlatAppearance.BorderSize = 0;
            this.btnArabic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnArabic.ForeColor = System.Drawing.Color.White;
            this.btnArabic.Image = global::CV_creator.Properties.Resources.algeria_15px;
            this.btnArabic.Name = "btnArabic";
            this.btnArabic.UseVisualStyleBackColor = false;
            this.btnArabic.Click += new System.EventHandler(this.btnArabic_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnLanguage, "btnLanguage");
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            this.btnLanguage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLanguage.ForeColor = System.Drawing.Color.White;
            this.btnLanguage.Image = global::CV_creator.Properties.Resources.language_24px;
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.UseVisualStyleBackColor = false;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnDatabase);
            this.panelSettings.Controls.Add(this.btnGeneral);
            resources.ApplyResources(this.panelSettings, "panelSettings");
            this.panelSettings.Name = "panelSettings";
            // 
            // btnDatabase
            // 
            this.btnDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDatabase, "btnDatabase");
            this.btnDatabase.FlatAppearance.BorderSize = 0;
            this.btnDatabase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnDatabase.ForeColor = System.Drawing.Color.White;
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.UseVisualStyleBackColor = false;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnGeneral, "btnGeneral");
            this.btnGeneral.FlatAppearance.BorderSize = 0;
            this.btnGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnGeneral.ForeColor = System.Drawing.Color.White;
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.UseVisualStyleBackColor = false;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::CV_creator.Properties.Resources.settings_24px;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelCvGenerator
            // 
            this.panelCvGenerator.Controls.Add(this.btnSelections);
            this.panelCvGenerator.Controls.Add(this.btnSubSections);
            this.panelCvGenerator.Controls.Add(this.btnSections);
            resources.ApplyResources(this.panelCvGenerator, "panelCvGenerator");
            this.panelCvGenerator.Name = "panelCvGenerator";
            // 
            // btnSelections
            // 
            this.btnSelections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnSelections.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSelections, "btnSelections");
            this.btnSelections.FlatAppearance.BorderSize = 0;
            this.btnSelections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnSelections.ForeColor = System.Drawing.Color.White;
            this.btnSelections.Name = "btnSelections";
            this.btnSelections.UseVisualStyleBackColor = false;
            this.btnSelections.Click += new System.EventHandler(this.btnSelections_Click);
            // 
            // btnSubSections
            // 
            this.btnSubSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnSubSections.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSubSections, "btnSubSections");
            this.btnSubSections.FlatAppearance.BorderSize = 0;
            this.btnSubSections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnSubSections.ForeColor = System.Drawing.Color.White;
            this.btnSubSections.Name = "btnSubSections";
            this.btnSubSections.UseVisualStyleBackColor = false;
            this.btnSubSections.Click += new System.EventHandler(this.btnSubSections_Click);
            // 
            // btnSections
            // 
            this.btnSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(67)))), ((int)(((byte)(75)))));
            this.btnSections.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSections, "btnSections");
            this.btnSections.FlatAppearance.BorderSize = 0;
            this.btnSections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(152)))), ((int)(((byte)(234)))));
            this.btnSections.ForeColor = System.Drawing.Color.White;
            this.btnSections.Name = "btnSections";
            this.btnSections.UseVisualStyleBackColor = false;
            this.btnSections.Click += new System.EventHandler(this.btnSections_Click);
            // 
            // btnCvGenerator
            // 
            this.btnCvGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCvGenerator.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnCvGenerator, "btnCvGenerator");
            this.btnCvGenerator.FlatAppearance.BorderSize = 0;
            this.btnCvGenerator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCvGenerator.ForeColor = System.Drawing.Color.White;
            this.btnCvGenerator.Image = global::CV_creator.Properties.Resources.file_settings_24px;
            this.btnCvGenerator.Name = "btnCvGenerator";
            this.btnCvGenerator.UseVisualStyleBackColor = false;
            this.btnCvGenerator.Click += new System.EventHandler(this.btnCvGenerator_Click);
            // 
            // btnPersonAndCv
            // 
            this.btnPersonAndCv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnPersonAndCv.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnPersonAndCv, "btnPersonAndCv");
            this.btnPersonAndCv.FlatAppearance.BorderSize = 0;
            this.btnPersonAndCv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPersonAndCv.ForeColor = System.Drawing.Color.White;
            this.btnPersonAndCv.Image = global::CV_creator.Properties.Resources.applicant_24px;
            this.btnPersonAndCv.Name = "btnPersonAndCv";
            this.btnPersonAndCv.UseVisualStyleBackColor = false;
            this.btnPersonAndCv.Click += new System.EventHandler(this.btnPersonAndCv_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.DoubleClick += new System.EventHandler(this.MaximizeOrMinimize);
            // 
            // panelPowerOff
            // 
            this.panelPowerOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panelPowerOff.Controls.Add(this.pictureBoxRestart);
            this.panelPowerOff.Controls.Add(this.pictureBoxShutdown);
            resources.ApplyResources(this.panelPowerOff, "panelPowerOff");
            this.panelPowerOff.Name = "panelPowerOff";
            this.panelPowerOff.DoubleClick += new System.EventHandler(this.MaximizeOrMinimize);
            // 
            // pictureBoxRestart
            // 
            resources.ApplyResources(this.pictureBoxRestart, "pictureBoxRestart");
            this.pictureBoxRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRestart.Image = global::CV_creator.Properties.Resources.restartGreen_24px;
            this.pictureBoxRestart.Name = "pictureBoxRestart";
            this.pictureBoxRestart.TabStop = false;
            this.pictureBoxRestart.Click += new System.EventHandler(this.pictureBoxRestart_Click);
            // 
            // pictureBoxShutdown
            // 
            resources.ApplyResources(this.pictureBoxShutdown, "pictureBoxShutdown");
            this.pictureBoxShutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxShutdown.Image = global::CV_creator.Properties.Resources.shutdownRed_24px;
            this.pictureBoxShutdown.Name = "pictureBoxShutdown";
            this.pictureBoxShutdown.TabStop = false;
            this.pictureBoxShutdown.Click += new System.EventHandler(this.pictureBoxShutdown_Click);
            // 
            // panelBody
            // 
            resources.ApplyResources(this.panelBody, "panelBody");
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panelBody.Name = "panelBody";
            this.panelBody.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelBody_ControlRemoved);
            this.panelBody.DoubleClick += new System.EventHandler(this.MaximizeOrMinimize);
            // 
            // fHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fHome";
            this.Opacity = 0.99D;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.panelSide.ResumeLayout(false);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLanguge.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelCvGenerator.ResumeLayout(false);
            this.panelPowerOff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShutdown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnPersonAndCv;
        private System.Windows.Forms.Panel panelLanguge;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnArabic;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panelCvGenerator;
        private System.Windows.Forms.Button btnSelections;
        private System.Windows.Forms.Button btnSubSections;
        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.Button btnCvGenerator;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMaximize;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxRestore;
        private System.Windows.Forms.Panel panelPowerOff;
        private System.Windows.Forms.PictureBox pictureBoxShutdown;
        private PictureBox pictureBoxRestart;
        public Panel panelBody;
    }
}

