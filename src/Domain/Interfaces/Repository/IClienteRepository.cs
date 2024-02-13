using System;
using Domain.Entities;

namespace Domain.Repository
{
	public interface IClienteRepository : IRepository<Cliente>
	{
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
    }
}

