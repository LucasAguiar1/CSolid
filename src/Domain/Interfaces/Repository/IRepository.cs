using System;
namespace Domain.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class 
	{
		//essa interface é uma inteface generia onde so aceita classe

		TEntity Adicionar(TEntity obj);
		TEntity ObterPorId(int id);
		IEnumerable<TEntity> ObterTodos();
		TEntity Atualizar(TEntity obj);
		void Remover(int id);
	}
}

