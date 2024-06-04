using System.ComponentModel.DataAnnotations;
namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class LancamentoHorasDTO
    {
        [Required]
        public List<int>? WbsId { get; set; }
        [Required]
        public List<int>? Horas { get; set; }

        public LancamentoHorasDTO()
        {
            WbsId = new List<int>();
            Horas = new List<int>();
        }
    } 
}
