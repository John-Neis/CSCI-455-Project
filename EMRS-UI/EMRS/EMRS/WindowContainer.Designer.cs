namespace EMRS
{
    partial class WindowContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowContainer));
            this.label1 = new System.Windows.Forms.Label();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.CPatientButton = new System.Windows.Forms.PictureBox();
            this.IPrescriptionsButton = new System.Windows.Forms.PictureBox();
            this.SymptomButton = new System.Windows.Forms.PictureBox();
            this.EPrescriptionsButton = new System.Windows.Forms.PictureBox();
            this.PDiagnosesButton = new System.Windows.Forms.PictureBox();
            this.ArchiveButton = new System.Windows.Forms.PictureBox();
            this.PPrescriptionsButton = new System.Windows.Forms.PictureBox();
            this.caduceusBox = new System.Windows.Forms.PictureBox();
            this.minimizeBox = new System.Windows.Forms.PictureBox();
            this.exitBox = new System.Windows.Forms.PictureBox();
            this.PNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PAgeLabel = new System.Windows.Forms.Label();
            this.PSexLabel = new System.Windows.Forms.Label();
            this.PAddressLabel = new System.Windows.Forms.Label();
            this.bodyPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPatientButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPrescriptionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymptomButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPrescriptionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDiagnosesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPrescriptionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caduceusBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(620, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Electronic Medical Record System";
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.DarkGreen;
            this.bodyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bodyPanel.Controls.Add(this.sidePanel);
            this.bodyPanel.Controls.Add(this.IPrescriptionsButton);
            this.bodyPanel.Controls.Add(this.SymptomButton);
            this.bodyPanel.Controls.Add(this.EPrescriptionsButton);
            this.bodyPanel.Controls.Add(this.PDiagnosesButton);
            this.bodyPanel.Controls.Add(this.ArchiveButton);
            this.bodyPanel.Controls.Add(this.PPrescriptionsButton);
            this.bodyPanel.Location = new System.Drawing.Point(0, 41);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(1280, 679);
            this.bodyPanel.TabIndex = 5;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidePanel.Controls.Add(this.tableLayoutPanel1);
            this.sidePanel.Controls.Add(this.CPatientButton);
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(300, 679);
            this.sidePanel.TabIndex = 6;
            // 
            // CPatientButton
            // 
            this.CPatientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPatientButton.Image = global::EMRS.Properties.Resources.Change_Patient_Option_Button;
            this.CPatientButton.Location = new System.Drawing.Point(40, 577);
            this.CPatientButton.Name = "CPatientButton";
            this.CPatientButton.Size = new System.Drawing.Size(220, 63);
            this.CPatientButton.TabIndex = 0;
            this.CPatientButton.TabStop = false;
            this.CPatientButton.Click += new System.EventHandler(this.CPatientButton_Click);
            // 
            // IPrescriptionsButton
            // 
            this.IPrescriptionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IPrescriptionsButton.Image = global::EMRS.Properties.Resources.IPrescription_Option_Button;
            this.IPrescriptionsButton.Location = new System.Drawing.Point(323, 387);
            this.IPrescriptionsButton.Name = "IPrescriptionsButton";
            this.IPrescriptionsButton.Size = new System.Drawing.Size(300, 200);
            this.IPrescriptionsButton.TabIndex = 5;
            this.IPrescriptionsButton.TabStop = false;
            this.IPrescriptionsButton.Click += new System.EventHandler(this.IPrescriptionsButton_Click);
            // 
            // SymptomButton
            // 
            this.SymptomButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SymptomButton.Image = global::EMRS.Properties.Resources.Symptom_Option_Button;
            this.SymptomButton.Location = new System.Drawing.Point(323, 34);
            this.SymptomButton.Name = "SymptomButton";
            this.SymptomButton.Size = new System.Drawing.Size(300, 200);
            this.SymptomButton.TabIndex = 4;
            this.SymptomButton.TabStop = false;
            this.SymptomButton.Click += new System.EventHandler(this.SymptomButton_Click);
            // 
            // EPrescriptionsButton
            // 
            this.EPrescriptionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EPrescriptionsButton.Image = global::EMRS.Properties.Resources.EPrescription_Option_Button;
            this.EPrescriptionsButton.Location = new System.Drawing.Point(639, 387);
            this.EPrescriptionsButton.Name = "EPrescriptionsButton";
            this.EPrescriptionsButton.Size = new System.Drawing.Size(300, 200);
            this.EPrescriptionsButton.TabIndex = 3;
            this.EPrescriptionsButton.TabStop = false;
            this.EPrescriptionsButton.Click += new System.EventHandler(this.EPrescriptionsButton_Click);
            // 
            // PDiagnosesButton
            // 
            this.PDiagnosesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PDiagnosesButton.Image = global::EMRS.Properties.Resources.PDiagnoses_Option_Button;
            this.PDiagnosesButton.Location = new System.Drawing.Point(639, 34);
            this.PDiagnosesButton.Name = "PDiagnosesButton";
            this.PDiagnosesButton.Size = new System.Drawing.Size(300, 200);
            this.PDiagnosesButton.TabIndex = 2;
            this.PDiagnosesButton.TabStop = false;
            this.PDiagnosesButton.Click += new System.EventHandler(this.PDiagnosesButton_Click);
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchiveButton.Image = global::EMRS.Properties.Resources.Archive_Option_Button;
            this.ArchiveButton.Location = new System.Drawing.Point(955, 387);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(300, 200);
            this.ArchiveButton.TabIndex = 1;
            this.ArchiveButton.TabStop = false;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // PPrescriptionsButton
            // 
            this.PPrescriptionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PPrescriptionsButton.Image = global::EMRS.Properties.Resources.PPrescriptions_Option_Button;
            this.PPrescriptionsButton.Location = new System.Drawing.Point(955, 34);
            this.PPrescriptionsButton.Name = "PPrescriptionsButton";
            this.PPrescriptionsButton.Size = new System.Drawing.Size(300, 200);
            this.PPrescriptionsButton.TabIndex = 0;
            this.PPrescriptionsButton.TabStop = false;
            this.PPrescriptionsButton.Click += new System.EventHandler(this.PPrescriptionsButton_Click);
            // 
            // caduceusBox
            // 
            this.caduceusBox.Image = global::EMRS.Properties.Resources.Caduceus_logo;
            this.caduceusBox.Location = new System.Drawing.Point(1239, 1);
            this.caduceusBox.Name = "caduceusBox";
            this.caduceusBox.Size = new System.Drawing.Size(40, 40);
            this.caduceusBox.TabIndex = 4;
            this.caduceusBox.TabStop = false;
            // 
            // minimizeBox
            // 
            this.minimizeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minimizeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBox.Image = global::EMRS.Properties.Resources.Minimize;
            this.minimizeBox.Location = new System.Drawing.Point(41, 1);
            this.minimizeBox.Name = "minimizeBox";
            this.minimizeBox.Size = new System.Drawing.Size(40, 40);
            this.minimizeBox.TabIndex = 1;
            this.minimizeBox.TabStop = false;
            this.minimizeBox.Click += new System.EventHandler(this.minimizeBox_Click);
            // 
            // exitBox
            // 
            this.exitBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBox.ErrorImage = global::EMRS.Properties.Resources.Exit;
            this.exitBox.ImageLocation = "0,0";
            this.exitBox.InitialImage = global::EMRS.Properties.Resources.Exit;
            this.exitBox.Location = new System.Drawing.Point(1, 1);
            this.exitBox.Name = "exitBox";
            this.exitBox.Size = new System.Drawing.Size(40, 40);
            this.exitBox.TabIndex = 0;
            this.exitBox.TabStop = false;
            this.exitBox.Click += new System.EventHandler(this.exitBox_Click);
            // 
            // PNameLabel
            // 
            this.PNameLabel.AutoSize = true;
            this.PNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PNameLabel.Location = new System.Drawing.Point(4, 1);
            this.PNameLabel.Name = "PNameLabel";
            this.PNameLabel.Size = new System.Drawing.Size(212, 128);
            this.PNameLabel.TabIndex = 1;
            this.PNameLabel.Text = "Current Patient:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PAddressLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PSexLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PAgeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PNameLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 518);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PAgeLabel
            // 
            this.PAgeLabel.AutoSize = true;
            this.PAgeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAgeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PAgeLabel.Location = new System.Drawing.Point(4, 130);
            this.PAgeLabel.Name = "PAgeLabel";
            this.PAgeLabel.Size = new System.Drawing.Size(212, 128);
            this.PAgeLabel.TabIndex = 2;
            this.PAgeLabel.Text = "Patient Age:";
            // 
            // PSexLabel
            // 
            this.PSexLabel.AutoSize = true;
            this.PSexLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PSexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSexLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PSexLabel.Location = new System.Drawing.Point(4, 259);
            this.PSexLabel.Name = "PSexLabel";
            this.PSexLabel.Size = new System.Drawing.Size(212, 128);
            this.PSexLabel.TabIndex = 3;
            this.PSexLabel.Text = "Patient Sex:";
            // 
            // PAddressLabel
            // 
            this.PAddressLabel.AutoSize = true;
            this.PAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAddressLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PAddressLabel.Location = new System.Drawing.Point(4, 388);
            this.PAddressLabel.Name = "PAddressLabel";
            this.PAddressLabel.Size = new System.Drawing.Size(212, 129);
            this.PAddressLabel.TabIndex = 4;
            this.PAddressLabel.Text = "Patient Address:";
            // 
            // WindowContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.caduceusBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minimizeBox);
            this.Controls.Add(this.exitBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowContainer";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowContainer_MouseDown);
            this.bodyPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CPatientButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPrescriptionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SymptomButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPrescriptionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDiagnosesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPrescriptionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caduceusBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox exitBox;
        private System.Windows.Forms.PictureBox minimizeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox caduceusBox;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.PictureBox IPrescriptionsButton;
        private System.Windows.Forms.PictureBox SymptomButton;
        private System.Windows.Forms.PictureBox EPrescriptionsButton;
        private System.Windows.Forms.PictureBox PDiagnosesButton;
        private System.Windows.Forms.PictureBox ArchiveButton;
        private System.Windows.Forms.PictureBox PPrescriptionsButton;
        private System.Windows.Forms.PictureBox CPatientButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label PAddressLabel;
        private System.Windows.Forms.Label PSexLabel;
        private System.Windows.Forms.Label PAgeLabel;
        private System.Windows.Forms.Label PNameLabel;
    }
}

