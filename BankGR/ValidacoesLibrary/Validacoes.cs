using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace BankGR.ValidacoesLibrary
{
    public class Validacoes
    {
        public static bool ValidaCPF(string vrCPF)
        {
            return new CPFValidator().Validate(vrCPF).IsValid;
        }
    }

    public class CPFValidator : AbstractValidator<string>
    {
        

        public CPFValidator()
        {
            try
            {
                RuleFor(cpf => cpf)
               .NotEmpty().WithMessage("O CPF não pode estar vazio.")
               .Length(11).WithMessage("O CPF deve conter 11 dígitos.")
               .Must(BeAValidCPF).WithMessage("O CPF é inválido.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }
           
        }

        private bool BeAValidCPF(string cpf)
        {
            try
            {
                // Remove caracteres não numéricos
                cpf = Regex.Replace(cpf, "[^0-9]", "");

                // Verifica se todos os dígitos são iguais
                if (new string(cpf[0], cpf.Length) == cpf)
                    return false;

                // Realiza os cálculos para validar o CPF
                int[] numbers = new int[11];

                for (int i = 0; i < 11; i++)
                {
                    numbers[i] = int.Parse(cpf[i].ToString());
                }

                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (10 - i) * numbers[i];
                }

                int remainder = sum % 11;
                int firstVerifier = remainder < 2 ? 0 : 11 - remainder;

                if (numbers[9] != firstVerifier)
                    return false;

                sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += (11 - i) * numbers[i];
                }

                remainder = sum % 11;
                int secondVerifier = remainder < 2 ? 0 : 11 - remainder;

                return numbers[10] == secondVerifier;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
