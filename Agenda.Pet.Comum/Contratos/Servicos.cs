using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Pet.Comum.Contratos
{
    [Table("Servicos")]
    public partial class Servicos
    {

        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome do servico é obrigatório")]
        [StringLength(80)]
        public string NomeServico { get; set; }

        //public virtual ICollection<PratosDTO> Pratos { get; set; }

    }
}
