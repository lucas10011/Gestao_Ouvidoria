using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gestao_Ouvidoria.Models
{
    public class OuvidoriaContext : DbContext
    {
        public OuvidoriaContext() : base("Name=Ouvidoria_db")
        {
            Database.SetInitializer<OuvidoriaContext>(
                new CreateDatabaseIfNotExists<OuvidoriaContext>());
            Database.Initialize(false);

            Database.Log = d => System.Diagnostics.Debug.WriteLine(d);
        }

        public DbSet<Manifestacao> Manifestacoes { get; set; }

    }
}