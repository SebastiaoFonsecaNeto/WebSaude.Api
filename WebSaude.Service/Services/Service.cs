using System.Collections.Generic;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Contracts.Services;

namespace WebSaude.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(params object[] keys)
        {
            TEntity entity = GetById(keys);

            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public TEntity GetById(params object[] keys)
        {
            return _repository.GetById(keys);
        }

        public TEntity First()
        {
            return _repository.First();
        }

        public TEntity Last()
        {
            return _repository.Last();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public virtual IEnumerable<TEntity> Get(List<string> relations)
        {
            return _repository.Get(relations);
        }

        public virtual bool ExistsById(params object[] keys)
        {
            return _repository.ExistsById(keys);
        }
               
        public int Count()
        {
            return _repository.Count();
        }
    }
}
