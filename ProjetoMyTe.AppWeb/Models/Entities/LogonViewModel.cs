using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class LogonViewModel
    {
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor, insira apenas números.")]
        public string? Cpf { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
