using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YenidenDeneme
{
    public class Gelir
    {
        public int GelirID { get; set; }
        public int GelirMiktari { get; set; }
        public int GelirTuruID { get; set; }
        public GelirTuru GelirTuru { get; set; }
    }
}
