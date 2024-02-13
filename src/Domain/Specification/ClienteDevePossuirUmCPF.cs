using System;
using Domain.Entities;
using Domain.Repository;

namespace Domain.Specification
{
	public class ClienteDevePossuirUmCPF
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirUmCPF(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool ValidaCPFCliente(Cliente cliente)
        {
            var retorno = _clienteRepository.ObterPorCpf(cliente.Cpf);
            if (retorno.id != 0)
            {
                cliente.Mensagens.Add("CPF já cadsatrado");
                return false;
            }
            return true;
        }
    }
}

