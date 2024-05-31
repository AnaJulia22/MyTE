using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Wbs
    {
        public int Id { get; set; }
        [MinLength(4, ErrorMessage = "O nome de usuário deve ter no mínimo 4 caracteres.")]
        //[MaxLength(10, ErrorMessage = "O nome de usuário deve ter no mínimo 4 caracteres.")]
        [Required(ErrorMessage = "Insira o código", AllowEmptyStrings = false)]
        [CustomValidation(typeof(Wbs), "ValidarTamanhoMaximo")]
        [DisplayName("Código")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "Descrição Inválida", AllowEmptyStrings = false)]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [Range(1, 2, ErrorMessage = "Por favor, selecione uma opção")]
        public short Tipo { get; set; }

        public static ValidationResult? ValidarTamanhoMaximo(string value, ValidationContext context)
        {
            if (value != null && value.Length > 10)
            {
                return new ValidationResult("O tamanho máximo é 10 caracteres.", new List<string> { context.MemberName! });
            }

            return ValidationResult.Success;
        }
    }
}