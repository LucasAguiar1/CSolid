using System;
using System.ComponentModel.DataAnnotations;
using Domain.Specification;
using Domain.Validation.Clientes;

namespace Domain.Entities
{
	public class Cliente
	{
		public Cliente()
		{
            Mensagens = new List<string>();
        }

		public int id { get; set; }
		public  string? Nome { get; set; }

		public  string? EmailCliente { get; set; }
		public  string? TelefoneCliente { get; set; }
		public  DateTime? DataCadastroCliente { get; set; }
		public DateTime? DataNascimentoCliente { get; set; }
        public bool validationResult { get; set; }
		public string? Cpf { get; set; }

		public bool IsValid()
		{
			validationResult = new ClienteDadosValidation().pers(this);
            return validationResult;
        }

		public ICollection<string> Mensagens { get; set; }

    }
}

