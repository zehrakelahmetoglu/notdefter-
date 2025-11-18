using System;
using System.IO;
using System.Windows.Forms;

namespace notdefterı
{
    public partial class Form1 : Form
    {
        string dosyaYolu = "";

        public Form1()
        {
            InitializeComponent();
        }

        // --- DOSYA MENÜSÜ ---
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            dosyaYolu = "";
            this.Text = "Yeni Belge - Not Defteri";
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                dosyaYolu = ofd.FileName;
                this.Text = Path.GetFileName(dosyaYolu) + " - Not Defteri";
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dosyaYolu))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Metin Dosyaları|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, richTextBox1.Text);
                    dosyaYolu = sfd.FileName;
                    this.Text = Path.GetFileName(dosyaYolu) + " - Not Defteri";
                }
            }
            else
            {
                File.WriteAllText(dosyaYolu, richTextBox1.Text);
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Metin Dosyaları|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                dosyaYolu = sfd.FileName;
                this.Text = Path.GetFileName(dosyaYolu) + " - Not Defteri";
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
   

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void düzenEditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biçimFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yardımHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void richTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                richTextBox1.Paste();
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.Font; // mevcut fontu göster
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = richTextBox1.ForeColor; // mevcut rengi göster
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
       "Not Defteri Uygulaması\n" +
       "Versiyon 1.0\n" +
       "Hazırlayan: Zehra",
       "Hakkında",
       MessageBoxButtons.OK,
       MessageBoxIcon.Information
   );
        }
    }
}
