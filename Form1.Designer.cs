namespace SilentHillOrigins_PS2_RWSAudioExtract
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_RwsPathBox = new TextBox();
            m_btn1 = new Button();
            label1 = new Label();
            m_MainPanel = new Panel();
            m_ScanFolder = new Button();
            m_BtnCredits = new Button();
            label2 = new Label();
            m_btnFindMFAudio = new Button();
            m_MFAudio_path = new TextBox();
            m_BtnProcessAll = new Button();
            m_FileSize = new Label();
            m_FileSizeLabel = new Label();
            m_Frequency = new Label();
            m_FrequencyLabel = new Label();
            m_FileName = new Label();
            m_FileNameLabel = new Label();
            m_DataListBox = new ListBox();
            m_BtnProcessOneFile = new Button();
            m_BtnAnalyze = new Button();
            m_ofd = new OpenFileDialog();
            m_folderBD = new FolderBrowserDialog();
            m_ofd_MFAudio = new OpenFileDialog();
            m_MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // m_RwsPathBox
            // 
            m_RwsPathBox.Location = new Point(98, 5);
            m_RwsPathBox.Name = "m_RwsPathBox";
            m_RwsPathBox.ReadOnly = true;
            m_RwsPathBox.Size = new Size(545, 23);
            m_RwsPathBox.TabIndex = 1;
            // 
            // m_btn1
            // 
            m_btn1.Location = new Point(649, 5);
            m_btn1.Name = "m_btn1";
            m_btn1.Size = new Size(120, 23);
            m_btn1.TabIndex = 2;
            m_btn1.Text = "Find .RWS";
            m_btn1.UseVisualStyleBackColor = true;
            m_btn1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 3;
            label1.Text = ".RWS file path:";
            // 
            // m_MainPanel
            // 
            m_MainPanel.Controls.Add(m_ScanFolder);
            m_MainPanel.Controls.Add(m_BtnCredits);
            m_MainPanel.Controls.Add(label2);
            m_MainPanel.Controls.Add(m_btnFindMFAudio);
            m_MainPanel.Controls.Add(m_MFAudio_path);
            m_MainPanel.Controls.Add(m_BtnProcessAll);
            m_MainPanel.Controls.Add(m_FileSize);
            m_MainPanel.Controls.Add(m_FileSizeLabel);
            m_MainPanel.Controls.Add(m_Frequency);
            m_MainPanel.Controls.Add(m_FrequencyLabel);
            m_MainPanel.Controls.Add(m_FileName);
            m_MainPanel.Controls.Add(m_FileNameLabel);
            m_MainPanel.Controls.Add(m_DataListBox);
            m_MainPanel.Controls.Add(m_BtnProcessOneFile);
            m_MainPanel.Controls.Add(m_BtnAnalyze);
            m_MainPanel.Controls.Add(label1);
            m_MainPanel.Controls.Add(m_btn1);
            m_MainPanel.Controls.Add(m_RwsPathBox);
            m_MainPanel.Location = new Point(0, -1);
            m_MainPanel.Name = "m_MainPanel";
            m_MainPanel.Size = new Size(781, 561);
            m_MainPanel.TabIndex = 4;
            // 
            // m_ScanFolder
            // 
            m_ScanFolder.Location = new Point(648, 87);
            m_ScanFolder.Name = "m_ScanFolder";
            m_ScanFolder.Size = new Size(120, 40);
            m_ScanFolder.TabIndex = 18;
            m_ScanFolder.Text = "Analyze folder";
            m_ScanFolder.UseVisualStyleBackColor = true;
            m_ScanFolder.Click += m_ScanFolder_Click;
            // 
            // m_BtnCredits
            // 
            m_BtnCredits.Location = new Point(652, 505);
            m_BtnCredits.Name = "m_BtnCredits";
            m_BtnCredits.Size = new Size(117, 34);
            m_BtnCredits.TabIndex = 17;
            m_BtnCredits.Text = "Credits";
            m_BtnCredits.UseVisualStyleBackColor = true;
            m_BtnCredits.Click += m_BtnCredits_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 40);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 16;
            label2.Text = "MFAudio path:";
            // 
            // m_btnFindMFAudio
            // 
            m_btnFindMFAudio.Location = new Point(649, 36);
            m_btnFindMFAudio.Name = "m_btnFindMFAudio";
            m_btnFindMFAudio.Size = new Size(120, 23);
            m_btnFindMFAudio.TabIndex = 15;
            m_btnFindMFAudio.Text = "Find MFAudio";
            m_btnFindMFAudio.UseVisualStyleBackColor = true;
            m_btnFindMFAudio.Click += m_btnFindMFAudio_Click;
            // 
            // m_MFAudio_path
            // 
            m_MFAudio_path.Location = new Point(98, 36);
            m_MFAudio_path.Name = "m_MFAudio_path";
            m_MFAudio_path.ReadOnly = true;
            m_MFAudio_path.Size = new Size(545, 23);
            m_MFAudio_path.TabIndex = 14;
            // 
            // m_BtnProcessAll
            // 
            m_BtnProcessAll.Enabled = false;
            m_BtnProcessAll.Location = new Point(356, 502);
            m_BtnProcessAll.Name = "m_BtnProcessAll";
            m_BtnProcessAll.Size = new Size(200, 40);
            m_BtnProcessAll.TabIndex = 13;
            m_BtnProcessAll.Text = "Extract all files and convert to .wav";
            m_BtnProcessAll.UseVisualStyleBackColor = true;
            m_BtnProcessAll.Click += button1_Click_1;
            // 
            // m_FileSize
            // 
            m_FileSize.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            m_FileSize.Location = new Point(414, 183);
            m_FileSize.Name = "m_FileSize";
            m_FileSize.Size = new Size(355, 25);
            m_FileSize.TabIndex = 12;
            m_FileSize.Text = "XXXXX";
            // 
            // m_FileSizeLabel
            // 
            m_FileSizeLabel.AutoSize = true;
            m_FileSizeLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            m_FileSizeLabel.Location = new Point(356, 183);
            m_FileSizeLabel.Name = "m_FileSizeLabel";
            m_FileSizeLabel.Size = new Size(52, 25);
            m_FileSizeLabel.TabIndex = 11;
            m_FileSizeLabel.Text = "Size:";
            // 
            // m_Frequency
            // 
            m_Frequency.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            m_Frequency.Location = new Point(463, 158);
            m_Frequency.Name = "m_Frequency";
            m_Frequency.Size = new Size(200, 25);
            m_Frequency.TabIndex = 10;
            m_Frequency.Text = "XXXXX";
            // 
            // m_FrequencyLabel
            // 
            m_FrequencyLabel.AutoSize = true;
            m_FrequencyLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            m_FrequencyLabel.Location = new Point(356, 158);
            m_FrequencyLabel.Name = "m_FrequencyLabel";
            m_FrequencyLabel.Size = new Size(110, 25);
            m_FrequencyLabel.TabIndex = 9;
            m_FrequencyLabel.Text = "Frequency:";
            // 
            // m_FileName
            // 
            m_FileName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            m_FileName.Location = new Point(463, 133);
            m_FileName.Name = "m_FileName";
            m_FileName.Size = new Size(306, 25);
            m_FileName.TabIndex = 8;
            m_FileName.Text = "Unknown";
            // 
            // m_FileNameLabel
            // 
            m_FileNameLabel.AutoSize = true;
            m_FileNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            m_FileNameLabel.Location = new Point(356, 133);
            m_FileNameLabel.Name = "m_FileNameLabel";
            m_FileNameLabel.Size = new Size(101, 25);
            m_FileNameLabel.TabIndex = 7;
            m_FileNameLabel.Text = "File name:";
            // 
            // m_DataListBox
            // 
            m_DataListBox.FormattingEnabled = true;
            m_DataListBox.ItemHeight = 15;
            m_DataListBox.Location = new Point(14, 133);
            m_DataListBox.Name = "m_DataListBox";
            m_DataListBox.Size = new Size(336, 409);
            m_DataListBox.TabIndex = 6;
            m_DataListBox.SelectedIndexChanged += m_DataListBox_SelectedIndexChanged;
            // 
            // m_BtnProcessOneFile
            // 
            m_BtnProcessOneFile.Enabled = false;
            m_BtnProcessOneFile.Location = new Point(463, 234);
            m_BtnProcessOneFile.Name = "m_BtnProcessOneFile";
            m_BtnProcessOneFile.Size = new Size(200, 40);
            m_BtnProcessOneFile.TabIndex = 5;
            m_BtnProcessOneFile.Text = "Extract file and convert to .wav";
            m_BtnProcessOneFile.UseVisualStyleBackColor = true;
            m_BtnProcessOneFile.Click += m_BtnProcessOneFile_Click;
            // 
            // m_BtnAnalyze
            // 
            m_BtnAnalyze.Enabled = false;
            m_BtnAnalyze.Location = new Point(78, 87);
            m_BtnAnalyze.Name = "m_BtnAnalyze";
            m_BtnAnalyze.Size = new Size(200, 40);
            m_BtnAnalyze.TabIndex = 4;
            m_BtnAnalyze.Text = "Analyze file ";
            m_BtnAnalyze.UseVisualStyleBackColor = true;
            m_BtnAnalyze.Click += m_BtnAnalyze_Click;
            // 
            // m_ofd
            // 
            m_ofd.FileName = "openFileDialog1";
            m_ofd.Filter = "RenderWare Stream|*.rws";
            // 
            // m_ofd_MFAudio
            // 
            m_ofd_MFAudio.FileName = "openFileDialog1";
            m_ofd_MFAudio.Filter = "MFAudio executable|MFAudio.exe";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 557);
            Controls.Add(m_MainPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Silent Hill: Origins (PS2) - Sound Extractor";
            m_MainPanel.ResumeLayout(false);
            m_MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox m_RwsPathBox;
        private Button m_btn1;
        private Label label1;
        private Panel m_MainPanel;
        private OpenFileDialog m_ofd;
        private Button m_BtnProcessOneFile;
        private Button m_BtnAnalyze;
        private ListBox m_DataListBox;
        private Label m_FileNameLabel;
        private Label m_Frequency;
        private Label m_FrequencyLabel;
        private Label m_FileName;
        private Label m_FileSize;
        private Label m_FileSizeLabel;
        private Button m_BtnProcessAll;
        private FolderBrowserDialog m_folderBD;
        private Label label2;
        private Button m_btnFindMFAudio;
        private TextBox m_MFAudio_path;
        private OpenFileDialog m_ofd_MFAudio;
        private Button m_BtnCredits;
        private Button m_ScanFolder;
    }
}
