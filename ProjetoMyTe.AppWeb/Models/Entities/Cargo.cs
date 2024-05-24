using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Descrição Inválida", AllowEmptyStrings = false)]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
        public ICollection <Colaborador>? Colaboradores{ get; set; }
    }
}
