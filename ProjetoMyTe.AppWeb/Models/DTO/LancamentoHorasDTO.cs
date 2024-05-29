using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class LancamentoHorasDTO
    {
        [Required]
        public int WbsId { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia1 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia2 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia3 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia4 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia5 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia6 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia7 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia8 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia9 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia10 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia11 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia12 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia13 { get; set; }
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia14 { get; set; } = 0;
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia15 { get; set; } = 0;
        [Required]
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        public int HorasDia16 { get; set; } = 0;
        

    }
}
