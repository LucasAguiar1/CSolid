using System;
using Domain.Entities;

namespace Domain.Specification
{
	public class ClientePersistirDados
	{

		public  bool PersistirDadosCliente(Cliente obj)
		{
			
			if ((obj.DataNascimentoCliente == null
                || string.IsNullOrEmpty(obj.EmailCliente)
                || string.IsNullOrEmpty(obj.Nome)
                || string.IsNullOrEmpty(obj.TelefoneCliente)))
				return false; 

			return true;
		}


	}
}

