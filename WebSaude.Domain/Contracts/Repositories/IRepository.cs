using System;
using System.Collections.Generic;

namespace WebSaude.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        int Count();
        void Delete(params object[] keys);
        void Delete(TEntity entity);
        bool ExistsById(params object[] keys);
        TEntity First();
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(List<string> relations);
        TEntity GetById(params object[] keys);
        TEntity Last();
        void Update(TEntity entity);
    }
}
