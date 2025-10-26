using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YenidenDeneme
{
    public partial class EkleGelir: Form
    {
        GelirGiderDBContext db = new GelirGiderDBContext();
        public EkleGelir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                try
                {
                    Gelir g = new Gelir();
                    g.GelirMiktari = Convert.ToInt32(textBox2.Text);
                    g.GelirTuruID = Convert.ToInt32(comboBox1.SelectedValue);
                    db.Gelirler.Add(g);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.Gelirler.ToList();
                    MessageBox.Show("Gelir başarıyla eklendi");
                }
                catch(FormatException)
                {
                    MessageBox.Show("Lütfen geçerli bir sayı giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Lütfen gelir miktarını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EkleGelir_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dataSet1.GelirTurus' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.gelirTurusTableAdapter.Fill(this.dataSet1.GelirTurus);
            dataGridView1.DataSource = db.Gelirler.ToList();

            

        }
        

        

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = new DialogResult();
            r = MessageBox.Show("Seçili değeri silmek istediğinize min misini?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Lütfen silmek için bir satır seçiniz.");
                        return;
                    }

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    var veri = db.Gelirler.Find(id);

                    if (veri != null)
                    {
                        db.Gelirler.Remove(veri);
                        db.SaveChanges();

                        dataGridView1.DataSource = db.Gelirler.ToList();
                        MessageBox.Show("Kayıt başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt bulunamadı!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }

        }
    }
}
