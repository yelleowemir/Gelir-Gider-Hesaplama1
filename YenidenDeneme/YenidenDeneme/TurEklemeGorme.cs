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
    public partial class TurEklemeGorme: Form
    {
        GelirGiderDBContext db = new GelirGiderDBContext();

        public bool deger; 
        public TurEklemeGorme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(deger)
            {
                GelirTuru glt = new GelirTuru();
                glt.Tur = textBox1.Text;
                db.GelirTurleri.Add(glt);
                db.SaveChanges();
                dataGridView1.DataSource = db.GelirTurleri.ToList();
            }
            else
            {
                GiderTuru gt = new GiderTuru();
                gt.Tur = textBox1.Text;
                db.GiderTurleri.Add(gt);
                db.SaveChanges();
                dataGridView1.DataSource = db.GiderTurleri.ToList();
            }
        }

        private void TurEklemeGorme_Load(object sender, EventArgs e)
        {
            if(deger)
            {
                dataGridView1.DataSource = db.GelirTurleri.ToList();

            }
            else
            {
                dataGridView1.DataSource = db.GiderTurleri.ToList();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
