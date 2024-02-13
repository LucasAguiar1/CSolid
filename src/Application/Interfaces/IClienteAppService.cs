using System;
using Domain.Entities;

namespace Application.Interfaces
{
	public interface IClienteAppService
    {
        Cliente Adicionar(Cliente obj);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente obj);
        void Remover(int id);
    }
}

