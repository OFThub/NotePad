/*****************************************************************************************************************************************************************************************************
******************************************************************************************************************************************************************************************************
**
**
**                                                                          SAKARYA ÜNİVERSİTESİ
**                                                                BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                                                                     BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                                                                    NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                                                         2014-2015 BAHAR DÖNEMİ
**
**
**                                                                ÖDEV NUMARASI..........: 1
**                                                                ÖĞRENCİ ADI............: Ömer Faruk TÜRKDOĞDU
**                                                                ÖĞRENCİ NUMARASI.......: G231210002
**                                                                DERSİN ALINDIĞI GRUP...: 2.Öğretim A
**
**
******************************************************************************************************************************************************************************************************
*****************************************************************************************************************************************************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _1.ODEV
{
    public partial class Form1 : Form
    {
        DialogResult sonuc;
        private string dosyaYeri = string.Empty;
        private string oncekiMetin = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }
        private void KontrolluKaydet()
        {
            //Kaydedilen metinin üzerine bir değişiklik yapıldıysa kaydet fonksiyonuna yönlendirme yapılıyor.
            if (oncekiMetin != richTextBox1.Text)
            {
                //Değişikliklerin kaydedilmesi.
                DialogResult result = MessageBox.Show("Yaptıpınız değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    kaydetToolStripMenuItem_Click(this, EventArgs.Empty);
                }


                else if (result == DialogResult.Cancel)
                {
                    //Kaydedilmek istenmediğinden emin olunması.
                    this.DialogResult = DialogResult.No;
                    sonuc = MessageBox.Show("Yaptığınız değişiklikler silinecektir!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Değişiklik yapıldıysa metnin kaydedilmesi soruluyor.
            KontrolluKaydet();

            //Yeni dosya açılması onaylanılıyor.
            if (sonuc == DialogResult.OK)
            {
                richTextBox1.Clear();
                dosyaYeri = string.Empty;
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dosya açılması.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dosyaYeri = openFileDialog.FileName;
                string icerik = File.ReadAllText(dosyaYeri);
                richTextBox1.Text = icerik;
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gerektiğinde Farklı Kaydetme işleminin yapılması.
            if (string.IsNullOrEmpty(dosyaYeri))
            {
                DialogResult result = MessageBox.Show("Daha önce kayıtlı dosya bulunmadığından dosya farklı kaydedilecektir!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    farklıKaydetToolStripMenuItem_Click(sender, e);
                    return;
                }
            }

            //Kaydetme işlemi yapılması.
            else
            {
                File.WriteAllText(dosyaYeri, richTextBox1.Text);
                oncekiMetin = richTextBox1.Text;
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Farklı kaydetme işleminin yapılması.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                dosyaYeri = saveFileDialog.FileName;
                File.WriteAllText(dosyaYeri, richTextBox1.Text);
                oncekiMetin = richTextBox1.Text;
                MessageBox.Show("İşleminiz başarıyla gerçekleştirildi.");
            }

            //Farklı kaydetme işlemi gerçekleştirilmezse bir şey yapılmaz.
            else
            {
                sonuc = DialogResult.Cancel;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kayıt gerektiren bir şey olmadığında dosya direkt kapatılır.
            if (oncekiMetin == richTextBox1.Text)
            {
                this.Close();
            }

            //Kayıt gerektiren bir şey olduğunda kaydedilip kapatılması işlemi gerçekleştirilir.
            else
            {
                KontrolluKaydet();

                if (sonuc == DialogResult.OK)
                {
                    this.Close();
                }

                else
                {
                    sonuc = DialogResult.OK;
                }
            }
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kesme işlemi yapılır.
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kopyalama işlemi yapılır.
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yapıştırma işlemi yapılır.
            richTextBox1.Paste();
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Seçilen metnin rengi değiştirilir.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arkaplanın rengi değiştirilir.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Seçilen metnin fontu değiştirilir.
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void toolStripSplitButton11_ButtonClick(object sender, EventArgs e)
        {
            //Seçilen metin kalın font ile değiştirilir.
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
        }

        private void toolStripSplitButton12_ButtonClick(object sender, EventArgs e)
        {
            //Seçilen metin Italic font ile değiştirilir.
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
        }

        private void toolStripSplitButton13_ButtonClick(object sender, EventArgs e)
        {
            //Seçilen metnin altı çizilir.
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
        }

        //Strip Split Button'lara ait olduğu fonksiyonlar atandı.

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            yeniToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            açToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {
            kaydetToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton4_ButtonClick(object sender, EventArgs e)
        {
            farklıKaydetToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton5_ButtonClick(object sender, EventArgs e)
        {
            kesToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton6_ButtonClick(object sender, EventArgs e)
        {
            kopyalaToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton7_ButtonClick(object sender, EventArgs e)
        {
            yapıştırToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        private void toolStripSplitButton8_ButtonClick(object sender, EventArgs e)
        {
            yazıRengiToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton9_ButtonClick(object sender, EventArgs e)
        {
            zeminRengiToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton10_ButtonClick(object sender, EventArgs e)
        {
            yazıTipiToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void toolStripSplitButton14_ButtonClick(object sender, EventArgs e)
        {
            çıkışToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
