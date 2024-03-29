﻿namespace JuraganAR
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.RichTextBox();
            this.progScrap = new System.Windows.Forms.ProgressBar();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.progExport = new System.Windows.Forms.ProgressBar();
            this.WorkerScrap = new System.ComponentModel.BackgroundWorker();
            this.WorkerExport = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogout.Location = new System.Drawing.Point(1144, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(108, 41);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAbout.Location = new System.Drawing.Point(1030, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(108, 41);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSetting.Location = new System.Drawing.Point(916, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(108, 41);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnData
            // 
            this.btnData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnData.Location = new System.Drawing.Point(802, 12);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(108, 41);
            this.btnData.TabIndex = 3;
            this.btnData.Text = "Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scrap Link - Dipisah dengan koma";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLink.Location = new System.Drawing.Point(18, 83);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(1234, 232);
            this.txtLink.TabIndex = 5;
            this.txtLink.Text = "";
            // 
            // progScrap
            // 
            this.progScrap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progScrap.ForeColor = System.Drawing.Color.LimeGreen;
            this.progScrap.Location = new System.Drawing.Point(18, 321);
            this.progScrap.Name = "progScrap";
            this.progScrap.Size = new System.Drawing.Size(1234, 23);
            this.progScrap.Step = 0;
            this.progScrap.TabIndex = 6;
            this.progScrap.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnProcess.Location = new System.Drawing.Point(18, 350);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(1234, 40);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(13, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Export Data - File Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFileName.Location = new System.Drawing.Point(18, 466);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(1234, 26);
            this.txtFileName.TabIndex = 9;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnExport.Location = new System.Drawing.Point(12, 540);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(1234, 40);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progExport
            // 
            this.progExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progExport.ForeColor = System.Drawing.Color.LimeGreen;
            this.progExport.Location = new System.Drawing.Point(12, 511);
            this.progExport.Name = "progExport";
            this.progExport.Size = new System.Drawing.Size(1234, 23);
            this.progExport.Step = 0;
            this.progExport.TabIndex = 11;
            this.progExport.Visible = false;
            // 
            // WorkerScrap
            // 
            this.WorkerScrap.WorkerReportsProgress = true;
            this.WorkerScrap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerScrap_DoWork);
            this.WorkerScrap.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WorkerScrap_ProgressChanged);
            this.WorkerScrap.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerScrap_RunWorkerCompleted);
            // 
            // WorkerExport
            // 
            this.WorkerExport.WorkerReportsProgress = true;
            this.WorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerExport_DoWork);
            this.WorkerExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WorkerExport_ProgressChanged);
            this.WorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerExport_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(26, 641);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Your IP : ";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblIP.Location = new System.Drawing.Point(100, 641);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(116, 18);
            this.lblIP.TabIndex = 13;
            this.lblIP.Text = "123.123.123.123";
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRefresh.Location = new System.Drawing.Point(231, 633);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(31, 31);
            this.lblRefresh.TabIndex = 14;
            this.lblRefresh.Text = "↺";
            this.lblRefresh.Click += new System.EventHandler(this.lblRefresh_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progExport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.progScrap);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnLogout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JuraganAR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtLink;
        private System.Windows.Forms.ProgressBar progScrap;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progExport;
        private System.ComponentModel.BackgroundWorker WorkerScrap;
        private System.ComponentModel.BackgroundWorker WorkerExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblRefresh;
    }
}