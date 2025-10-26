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
    public partial class EkleGider: Form
    {
        public EkleGider()
        {
            InitializeComponent();
        }
        GelirGiderDBContext db = new GelirGiderDBContext();

        private void EkleGider_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dataSet1.GiderTurus' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.giderTurusTableAdapter.Fill(this.dataSet1.GiderTurus);
            dataGridView1.DataSource = db.Giderler.ToList();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    Gider gdr = new Gider();
                    gdr.GiderMiktari = Convert.ToInt32(textBox1.Text);
                    gdr.GiderTuruID = Convert.ToInt32(comboBox1.SelectedValue);
                    db.Giderler.Add(gdr);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.Giderler.ToList();
                    MessageBox.Show("Gider başarıyla eklendi.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lütfen geçerli bir sayı giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen gider miktarını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = new DialogResult();
            r = MessageBox.Show("Seçili değeri silmek istediğinize min misini?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
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
                    var veri = db.Giderler.Find(id);

                    if (veri != null)
                    {
                        db.Giderler.Remove(veri);
                        db.SaveChanges();

                        dataGridView1.DataSource = db.Giderler.ToList();
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
