using System;
using System.Text.RegularExpressions;
using Domain.Entities;

namespace Domain.Documentos
{
	public class EmailValidation
    {
		public bool ValidarFormatoEmail(Cliente cliente)
		{
            // Utilizando uma expressão regular para validar o formato do e-mail
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            // Verificando se o e-mail corresponde ao padrão
            return regex.IsMatch(cliente.EmailCliente);
        }
	}
}

