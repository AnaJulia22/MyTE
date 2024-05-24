using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class UsuarioViewModel
    {
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor, insira apenas números.")]
        public string? Cpf { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Compare("Senha")]
        public string? ConfirmaSenha { get; set; }

        public string? Perfil { get; set; }
    }
}
