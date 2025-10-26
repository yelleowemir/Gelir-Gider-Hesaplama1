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
    public partial class KarZararGorme: Form
    {
        public KarZararGorme()
        {
            InitializeComponent();
        }
        GelirGiderDBContext db = new GelirGiderDBContext();
        private void KarZararGorme_Load(object sender, EventArgs e)
        {
            int tplglr = 0;
            int tplgdr = 0;
            dataGridView1.DataSource = db.Gelirler.ToList();
            dataGridView2.DataSource = db.Giderler.ToList();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null) 
                {
                    int gelirdeger = Convert.ToInt32(row.Cells[1].Value);
                    tplglr += gelirdeger;
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1] != null)
                {
                    int giderdeger = Convert.ToInt32(row.Cells[1].Value);
                    tplgdr += giderdeger;
                }
            }
            label2.Text = tplglr.ToString();
            label4.Text = tplgdr.ToString();
            label6.Text = (tplglr - tplgdr).ToString();
        }
    }
}
