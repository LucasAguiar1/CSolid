using System;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
	public interface IClienteServices : IDisposable
	{
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
        Cliente Atualizar(Cliente cliente);
        void Remover(int id);
    }
}

