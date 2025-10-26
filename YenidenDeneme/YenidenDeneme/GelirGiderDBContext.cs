using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YenidenDeneme
{
    public class GelirGiderDBContext : DbContext
    {
        public GelirGiderDBContext():base("GelirGiderDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GelirGiderDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<GelirGiderDBContext>());
        }
        public DbSet<Gider> Giderler { get; set; }
        public DbSet<Gelir> Gelirler { get; set; }
        public DbSet<GelirTuru> GelirTurleri { get; set; }
        public DbSet<GiderTuru> GiderTurleri { get; set; }




    }
}
