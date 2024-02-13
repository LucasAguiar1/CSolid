using System;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Domain.Specification;

namespace Domain.Services
{
	public class ClienteService : IClienteServices
    {
        //aqui nao vou no banco faco validavoes e retorno para a app e ai decide e vai ou nao no banco.

        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
		{
            _clienteRepository = clienteRepository; 

        }

        public Cliente Adicionar(Cliente obj)
        {
            if (!obj.IsValid())
                return obj;
            var cpf = new ClienteAptoParaCadastro().ValidarCPF(obj);
            var email = new ClienteAptoParaCadastro().ValidarEmail(obj);
           // if (!(cpf || !email))
            //    return obj;
            
            var existEmail = new ClienteDevePossuirUmEmail(_clienteRepository).ValidaEmailPorCliente(obj);
            var existUmcPF = new ClienteDevePossuirUmCPF(_clienteRepository).ValidaCPFCliente(obj);
            if (obj.Mensagens.Count > 0)
                return obj;
           return _clienteRepository.Adicionar(obj);
        }

        public Cliente Atualizar(Cliente obj)
        {
            if (!obj.IsValid())
                return obj;
            var cpf = new ClienteAptoParaCadastro().ValidarCPF(obj);
 
            var email = new ClienteAptoParaCadastro().ValidarEmail(obj);
            if ((cpf && email != true))
                return obj;

            return  _clienteRepository.Atualizar(obj);
        }

        public void Dispose()
        {
           
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(int id)
        {
           return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
           return _clienteRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _clienteRepository.Remover(id);
        }
    }
}

