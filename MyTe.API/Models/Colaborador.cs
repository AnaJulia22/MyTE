using System.Text.Json.Serialization;

namespace MyTe.API.Models
{
    public class Colaborador
    {
        public string? Id { get; set; }
        public int CargoId { get; set; }
        public string? Nome { get; set; }
        [JsonIgnore]
        public Cargo? CargoAtuacao { get; set; }
        [JsonIgnore]
        public ICollection<RegistroHoras>? RegistrosHoras { get; set; }
    }
}
