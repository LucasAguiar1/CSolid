using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;

namespace Application
{
	public class ClienteAppService: IClienteAppService
    {
       
        private readonly IClienteServices _clienteService;
		public ClienteAppService(IClienteServices clienteService)
		{
            _clienteService = clienteService;

        }

        public Cliente Adicionar(Cliente obj)
        {
  

            var c = _clienteService.Adicionar(obj);

            return c;
        }

        public Cliente Atualizar(Cliente obj)
        {
            return _clienteService.Atualizar(obj); 
        }

        public Cliente ObterPorId(int id)
        {
            var cli = _clienteService.ObterPorId(id);

            
            return cli;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
          var a = _clienteService.ObterTodos();
            
            List<Cliente> l = new List<Cliente>();
            foreach (var item in a)
            {
                l.Add(new Cliente { id= item.id, Nome = item.Nome
                    , DataCadastroCliente = item.DataCadastroCliente
                    , DataNascimentoCliente = item.DataNascimentoCliente
                    , EmailCliente = item.EmailCliente
                    ,Cpf = item.Cpf
                    , TelefoneCliente = item.TelefoneCliente});
            }

            return l; 
        }

        public void Remover(int id)
        {
            _clienteService.Remover(id);
        }
    }
}

