using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;

namespace WebSaude.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WebSaudeContext dbContext;
        private readonly DbSet<TEntity> entitySet;

        public Repository(WebSaudeContext context)
        {
            dbContext = context;
            entitySet = dbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> EntitySet
        {
            get { return entitySet; }
        }

        public virtual void Add(TEntity entity)
        {
            entitySet.Add(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = dbContext.Entry(entity);
            entitySet.Attach(entity);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public virtual void Delete(params object[] keys)
        {
            TEntity entity = GetById(keys);

            if (entity != null)
            {
                entitySet.Remove(entity);
            }
            dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            entitySet.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity GetById(params object[] keys)
        {
            return entitySet.Find(keys);
        }

        public TEntity First()
        {
            return entitySet.FirstOrDefault();
        }

        public TEntity Last()
        {
            return entitySet.LastOrDefault();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entitySet.AsEnumerable();
        }

        public virtual IEnumerable<TEntity> Get(List<string> relations)
        {
            switch (relations.Count())
            {
                case 1:
                    return entitySet.Include(relations[0]).AsEnumerable();
                case 2:
                    return entitySet.Include(relations[0]).Include(relations[1]).AsEnumerable();
                case 3:
                    return entitySet.Include(relations[0]).Include(relations[1]).Include(relations[2]).AsEnumerable();
                case 4:
                    return entitySet.Include(relations[0]).Include(relations[1]).Include(relations[2]).Include(relations[3]).AsEnumerable();
                case 5:
                    return entitySet.Include(relations[0]).Include(relations[1]).Include(relations[2]).Include(relations[3]).Include(relations[4]).AsEnumerable();
                case 6:
                    return entitySet.Include(relations[0]).Include(relations[1]).Include(relations[2]).Include(relations[3]).Include(relations[4]).Include(relations[5]).AsEnumerable();
                case 7:
                    return entitySet.Include(relations[0]).Include(relations[1]).Include(relations[2]).Include(relations[3]).Include(relations[4]).Include(relations[5]).Include(relations[6]).AsEnumerable();
                default:
                    return entitySet.AsEnumerable();
            }
        }

        public virtual bool ExistsById(params object[] keys)
        {
            return entitySet.Find(keys) != null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Count()
        {
            return Get().Count();
        }
    }
}
