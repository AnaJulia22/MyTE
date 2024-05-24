using System.ComponentModel;

namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class RegistroHorasDTO
    {
        public int Id { get; set; }
        [DisplayName("Data/Hora do Registro")]
        public DateTime DataRegistro { get; set; }
        [DisplayName("Código WBS")]
        public string? CodigoWbs { get; set; }
        [DisplayName("WBS")]
        public string? WbsId { get; set; }
        [DisplayName("CPF")]
        public string? CpfId { get; set; }
        [DisplayName("Nome")]
        public string? NomeColaborador { get; set; }
        public DateOnly Dia { get; set; }
        [DisplayName("Qdte de Horas")]
        public int Horas { get; set; }
    }
}
