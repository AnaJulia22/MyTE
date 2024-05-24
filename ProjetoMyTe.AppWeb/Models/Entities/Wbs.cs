using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Wbs
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Código Inválido", AllowEmptyStrings = false)]
        [DisplayName("Código")]
        public string? Codigo { get; set; }
       
        [Required(ErrorMessage ="Descrição Inválida", AllowEmptyStrings = false)]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
       
        public short Tipo { get; set; }
        
    }
}
