
using System.ComponentModel;

namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class ColaboradorDTO
    {
        [DisplayName("CPF")]
        public string? Id { get; set; }
      
        public int CargoId { get; set; }// propriedade de filtragem
        [DisplayName("Cargo")]
        public string? DescricaoCargo { get; set; }
        public bool Administrador { get; set; }
        public string? Nome { get; set; }




    }
}
