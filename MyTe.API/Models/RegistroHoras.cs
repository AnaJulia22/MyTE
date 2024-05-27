namespace MyTe.API.Models
{
    public class RegistroHoras
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public int WbsId { get; set; }
        public string? CpfId { get; set; }
        public DateOnly Dia { get; set; }
        public int Horas { get; set; }
        public Wbs? Wbs { get; set; }
        public Colaborador? Cpf { get; set; }
    }
}
