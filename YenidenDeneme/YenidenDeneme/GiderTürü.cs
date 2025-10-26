using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YenidenDeneme
{
    public class GiderTuru
    {
        public int GiderTuruID { get; set; }
        public string Tur { get; set; }
        public List<Gider> Gider { get; set; }
    }
}
