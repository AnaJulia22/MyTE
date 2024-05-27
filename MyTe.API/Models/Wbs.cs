namespace MyTe.API.Models
{
    public class Wbs
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public ICollection<RegistroHoras>? RegistrosHoras { get; set; }
    }
}
