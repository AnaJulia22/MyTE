using Microsoft.Identity.Client;

namespace MyTe.API.Models.DTO
{
    public class RegistroHorasDTO
    {
        public string? CpfColaborador {  get; set; } 
        public string? NomeColaborador { get; set; }
        public string? codigoWbs { get; set; }
        public string? WbsDescricao { get; set; }
        public string? Cargo {  get; set; }
        public DateOnly Dia { get; set; }

    }
}
