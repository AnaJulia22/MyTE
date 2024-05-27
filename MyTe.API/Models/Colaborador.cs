namespace MyTe.API.Models
{
    public class Colaborador
    {
        public string? Id { get; set; }
        public int CargoId { get; set; }
        public string? Nome { get; set; }
        public Cargo? CargoAtuacao { get; set; } 
        public ICollection<RegistroHoras>? RegistrosHoras { get; set; }
    }
}
