using System;
using System.Diagnostics;

namespace SilentHillOrigins_PS2_RWSAudioExtract
{
    public partial class Form1 : Form
    {
        private readonly byte[] HEADER_CHECK_A = [0x09, 0x08, 0x00, 0x00];
        private readonly byte[] HEADER_CHECK_B = [0x65, 0x00, 0x02, 0x1C,
                                                  0x0A, 0x08, 0x00, 0x00,
                                                  0x54, 0x00, 0x00, 0x00,
                                                  0x37, 0x00, 0x02, 0x1C];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_ofd.ShowDialog() == DialogResult.OK)
            {
                m_RwsPathBox.Text = m_ofd.FileName;
                m_folderBD.InitialDirectory = m_ofd.InitialDirectory;
                ClearDataVisual();
            }
        }

        private void m_BtnAnalyze_Click(object sender, EventArgs e)
        {
            ExtractSonyAdpcmWorker.DisplayValues(m_RwsPathBox.Text, false);
            m_DataListBox.Items.Clear();
            m_DataListBox.Items.AddRange(RawData_Array.GetListOfData());

            if ((string)m_DataListBox.Items[0] != "NO DATA")
                m_BtnProcessAll.Enabled = true;

            m_BtnProcessOneFile.Enabled = false;
        }

        private void m_DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RawData data = RawData_Array.GetDataForFile(m_DataListBox.SelectedIndex);
            m_FileName.Text = data.Name;
            m_Frequency.Text = data.Frequency.ToString() + "Hz";
            m_FileSize.Text = GetSize(data.Size);

            if (data.Data != null)
                m_BtnProcessOneFile.Enabled = true;
        }

        private void ClearDataVisual()
        {
            m_BtnAnalyze.Enabled = true;
            m_BtnProcessOneFile.Enabled = m_BtnProcessAll.Enabled = false;
            m_DataListBox.Items.Clear();
            m_FileName.Text = "Unknown";
            m_Frequency.Text = "XXXXX";
            m_FileSize.Text = "XXXXX";
        }

        private static string GetSize(uint size)
        {
            if (size < 1024) return $"{size} Bytes";
            else if (size < 1048576) return $"{size / 1024f} Kilobytes";
            else return $"{size / 1048576f} Megabytes";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path;
            if (m_folderBD.ShowDialog() == DialogResult.OK)
                path = m_folderBD.SelectedPath;
            else
            {
                MessageBox.Show("You must select a folder for saving!", "Error: Need folder for save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (RawData data in RawData_Array.GetAllData())
            {
                int sampleRate = data.Frequency;

                if (data.Frequency < 11025)
                {
                    MessageBox.Show($"Audio file: {data.Name} has sample rate {data.Frequency}Hz.\nMinimum rate for MFAudio is 11050Hz. An audio will be resamaple to 11050Hz.", "Low sample rate warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sampleRate = 11025;
                }

                using (FileStream stream = File.Create($"{path}\\{data.Name}.vag"))
                {
                    stream.Write(ExtractSonyAdpcmWorker.createVagHeader(data));
                    stream.Write(data.Data);
                    stream.Dispose();
                }

                string argument = $"/OTWAVU /OF{sampleRate} /OC1 \"{m_folderBD.SelectedPath}\\{data.Name}.vag\" \"{m_folderBD.SelectedPath}\\{data.Name}.wav\"";

                ProcessStartInfo processInfo = new ProcessStartInfo(m_ofd_MFAudio.FileName, argument);
                Process process = Process.Start(processInfo);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                process.WaitForExit();
                process.Close();
            }
        }

        private void m_BtnProcessOneFile_Click(object sender, EventArgs e)
        {
            string path;

            if (m_folderBD.ShowDialog() == DialogResult.OK)
                path = m_folderBD.SelectedPath;
            else
            {
                MessageBox.Show("You must select a folder for saving!", "Error: Need folder for save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!m_ofd_MFAudio.CheckFileExists)
            {
                MessageBox.Show("MFAudio.exe doesn't exist in current directory.\nPlease, check path to MFAudio.exe and try again",
                    "Error: Missing MFAudio.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RawData data = RawData_Array.GetDataForFile(m_DataListBox.SelectedIndex);
            using (FileStream stream = File.Create($"{path}\\{data.Name}.vag"))
            {
                stream.Write(ExtractSonyAdpcmWorker.createVagHeader(RawData_Array.GetDataForFile(m_DataListBox.SelectedIndex)));
                stream.Write(data.Data);
                stream.Dispose();
            }

            string argument = $"/OTWAVU /OF{data.Frequency} /OC1 \"{m_folderBD.SelectedPath}\\{data.Name}.vag\" \"{m_folderBD.SelectedPath}\\{data.Name}.wav\"";

            ProcessStartInfo processInfo = new ProcessStartInfo(m_ofd_MFAudio.FileName, argument);
            Process process = Process.Start(processInfo);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            process.WaitForExit();
            process.Close();
        }

        private void m_btnFindMFAudio_Click(object sender, EventArgs e)
        {
            if (m_ofd_MFAudio.ShowDialog() == DialogResult.OK)
            {
                m_MFAudio_path.Text = m_ofd_MFAudio.FileName;
            }
        }

        private void m_BtnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Made by Ilya 'Lune' Tarpischev\nThanks to all RenderWare Community, PS2 Researchers and Silent Hill fans.\nAll rights reserved by Konami.\n\n2025", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void m_ScanFolder_Click(object sender, EventArgs e)
        { 
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("You need to choose folder for scanning", "Error: No folder has chosen",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearDataVisual();
            m_DataListBox.Items.Clear();

            foreach (string fileName in Directory.GetFiles(dialog.SelectedPath))
            {
                if (fileName.Substring(fileName.Length - 4) != ".rws")
                    continue;

                FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

                byte[] headerA = new byte[4];
                byte[] headerB = new byte[16];

                stream.Read(headerA, 0, 4);
                stream.Seek(8, SeekOrigin.Begin);
                stream.Read(headerB, 0, 16);

                if (!headerA.SequenceEqual(HEADER_CHECK_A) || !headerB.SequenceEqual(HEADER_CHECK_B))
                {
                    stream.Dispose();
                    continue;
                }
                    

                stream.Dispose();
                ExtractSonyAdpcmWorker.DisplayValues(fileName, true);
                
            }

            m_DataListBox.Items.AddRange(RawData_Array.GetListOfData());
            if ((string)m_DataListBox.Items[0] != "NO DATA")
                m_BtnProcessAll.Enabled = true;
        }
    }
}
