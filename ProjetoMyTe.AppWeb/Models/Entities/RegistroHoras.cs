using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class RegistroHoras
    {
        public int Id { get; set; }
        [DisplayName("Data/Hora do Registro")]
        public DateTime DataRegistro { get; set; }
        [DisplayName("WBS")]
        public int WbsId { get; set; }
        [DisplayName("CPF")]
        public string? CpfId { get; set; }
        public DateTime Dia { get; set; }
        [DisplayName("Horas")]
        public int Horas { get; set; }
        public Wbs? Wbs { get; set; }
        public Colaborador? Cpf { get; set; }

    }
}
