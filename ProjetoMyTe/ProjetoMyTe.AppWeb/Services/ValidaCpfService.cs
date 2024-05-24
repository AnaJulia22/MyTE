using System.ComponentModel.DataAnnotations;

public class ValidaCpfService : ValidationAttribute
{
    protected ValidationResult? IsValid(string cpf)
    {
        // Faz a validação do CPF
        if (!ValidaCPF(cpf))
        {
            return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }

    // Método para validar o CPF
    private bool ValidaCPF(string cpf)
    {
        // Remover caracteres não numéricos do CPF
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Verificar se o CPF possui 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verificar se todos os dígitos do CPF são iguais (caso seja, não é válido)
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcular e verificar os dígitos verificadores
        int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string cpfTemporario = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpfTemporario[i].ToString()) * multiplicadoresPrimeiroDigito[i];
        }

        int resto = soma % 11;
        int primeiroDigito = resto < 2 ? 0 : 11 - resto;

        if (int.Parse(cpf[9].ToString()) != primeiroDigito)
            return false;

        cpfTemporario += primeiroDigito;
        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpfTemporario[i].ToString()) * multiplicadoresSegundoDigito[i];
        }

        resto = soma % 11;
        int segundoDigito = resto < 2 ? 0 : 11 - resto;

        return int.Parse(cpf[10].ToString()) == segundoDigito;
    }
}


