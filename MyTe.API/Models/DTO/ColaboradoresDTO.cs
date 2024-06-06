using System.Text.Json.Serialization;

namespace MyTe.API.Models.DTO
{
    public class ColaboradoresDTO
    {
        public int IdColaborador { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }

        [JsonIgnore]
        public string? Cargo { get; set;}
        
        
    }
}
