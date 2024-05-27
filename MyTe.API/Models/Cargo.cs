using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTe.API.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Colaborador>? Colaboradores { get; set; }
    }
}
