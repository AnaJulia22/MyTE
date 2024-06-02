using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.DTO
{
    public class LancamentoHorasDTO
    {
        [Required]
        public int WbsId { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia1 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia2 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia3 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia4 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia5 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia6 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia7 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia8 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia9 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia10 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia11 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia12 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia13 { get; set; }
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia14 { get; set; } = 0;
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia15 { get; set; } = 0;
        [Range(0, 8, ErrorMessage = "O valor deve estar entre 0 e 8.")]
        [Required]
        public int HorasDia16 { get; set; } = 0;
        

    }
}
