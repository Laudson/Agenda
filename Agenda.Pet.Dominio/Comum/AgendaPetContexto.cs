using Agenda.Pet.Comum.Contratos;
using System.Data.Entity;

namespace Agenda.Pet.Dominio.Comum
{
    public class AgendaPetContexto : DbContext
    {
        public AgendaPetContexto()
            : base("name=AgendaPet")
        {
        }

        public virtual DbSet<Servicos> Servico { get; set; }
    }
}