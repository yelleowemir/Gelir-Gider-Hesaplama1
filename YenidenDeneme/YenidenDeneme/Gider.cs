using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YenidenDeneme
{
    public class Gider
    {
        public int GiderID { get; set; }

        public int GiderMiktari { get; set; }
        public int GiderTuruID { get; set; }
        public GiderTuru GiderTuru { get; set; }
    }
}
