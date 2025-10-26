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
    public partial class Form1: Form
    {
        public bool deger;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deger = true;
            TurEklemeGorme frm = new TurEklemeGorme();
            frm.deger = deger;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deger = false;
            TurEklemeGorme frm = new TurEklemeGorme();
            frm.deger = deger;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EkleGelir frm = new EkleGelir();
            frm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EkleGider frm = new EkleGider();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KarZararGorme frm = new KarZararGorme();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult r = new DialogResult();
            r = MessageBox.Show("Bütün verileri sıfırlamak istediğinize emin misiniz","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(r==DialogResult.Yes)
            {
                GelirGiderDBContext db = new GelirGiderDBContext();
                foreach (var item in db.Gelirler)
                {
                    db.Gelirler.Remove(item);
                }

                foreach (var item in db.Giderler)
                {
                    db.Giderler.Remove(item);
                }

                db.SaveChanges();
            } 

        }
    }
}
