using System;
using Domain.Entities;
using Domain.Repository;
using Infra.Context;

namespace Infra.RepositoryCrud
{
	public abstract class  Repository<TEntity> : IRepository<TEntity> where TEntity : class 
	{
        protected ConexaoBanco BD; 
		public Repository(ConexaoBanco context)
		{
            BD = context;
           

        }

        public abstract TEntity Adicionar(TEntity obj);


        public abstract TEntity Atualizar(TEntity obj);


        public abstract void Dispose();


        public abstract TEntity ObterPorId(int id);


        public abstract IEnumerable<TEntity> ObterTodos();


        public abstract void Remover(int id);
       
    }
}

