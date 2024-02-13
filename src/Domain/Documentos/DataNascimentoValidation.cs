using System;
namespace Domain.Documentos
{
	public class DataNascimentoValidation
    {
		public bool VerificarDataNascimento(DateTime dataNascimento, int idadeMinima)
		{
            /*
            DateTime? dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            // Ajustar a idade se a data atual ainda não tiver ocorrido no ano de nascimento
            if (dataAtual.Month < dataNascimento.Month || (dataAtual.Month == dataNascimento.Month && dataAtual.Day < dataNascimento.Day))
            {
                idade--;
            }

            // Verificar se a idade é maior ou igual à idade mínima desejada
            return idade >= idadeMinima;
            */
            return true;
        }
	}
}

