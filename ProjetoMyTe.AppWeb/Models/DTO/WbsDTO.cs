using System.ComponentModel;

namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class WbsDTO
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string? Codigo { get; set; }
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }
    }
}
