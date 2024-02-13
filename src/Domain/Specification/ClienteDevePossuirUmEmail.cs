using System;
using Domain.Entities;
using Domain.Repository;

namespace Domain.Specification
{
	public class ClienteDevePossuirUmEmail
	{
        private readonly IClienteRepository _clienteRepository;

		public ClienteDevePossuirUmEmail(IClienteRepository clienteRepository)
		{
            _clienteRepository = clienteRepository;

        }

		public bool ValidaEmailPorCliente(Cliente cliente)
		{
			var retorno = _clienteRepository.ObterPorEmail(cliente.EmailCliente);
			if (retorno.id != 0)
			{
				cliente.Mensagens.Add("Email já cadastrado para um cliente");
				return false;
			}
			return true;
		}
	}
}

