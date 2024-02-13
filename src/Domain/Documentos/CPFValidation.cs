using System;
using Domain.Entities;

namespace Domain.Documentos
{
	public class CPFValidation
	{

        public bool ValidarCPF(Cliente cliente)
        {
            // Remover caracteres não numéricos
            string cpfNumerico = new string(cliente.Cpf.Where(char.IsDigit).ToArray());

            // Verificar se o CPF tem 11 dígitos
            if (cpfNumerico.Length != 11)
            {
                return false;
            }

            // Verificar se todos os dígitos são iguais (CPF inválido)
            if (cpfNumerico.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfNumerico[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Verificar se o primeiro dígito verificador está correto
            if (digitoVerificador1 != int.Parse(cpfNumerico[9].ToString()))
            {
                return false;
            }

            // Calcular o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfNumerico[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verificar se o segundo dígito verificador está correto
            return digitoVerificador2 == int.Parse(cpfNumerico[10].ToString());
        }

    }
}

