using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models
{
    public class WbsClient
    {
        [DisplayName("Código")]
        public string? codigoWbs { get; set; }
        [DisplayName("Descrição")]
        public string? WbsDescricao { get; set; }
        [DisplayName("Horas totais")]
        public int Hora { get; set; }
        [DisplayName("Data de registro")]
        public DateTime DataRegistro { get; set; }
    }
}
