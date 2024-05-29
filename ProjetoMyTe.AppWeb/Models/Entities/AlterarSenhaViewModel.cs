using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class AlterarSenhaViewModel
    {
        [Required]
        [Key]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor, insira apenas números.")]
        public string? CpfId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string? SenhaAntiga { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.aaaaaa", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha nova")]
        public string? SenhaNova { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua nova senha")]
        [Compare("SenhaNova", ErrorMessage = "A nova senha e a confirmação não são compatíveis.")]
        public string? ConfirmaSenha { get; set; }
    }
}
